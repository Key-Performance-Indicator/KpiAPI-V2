using BCrypt.Net;
using Kpi.Core.Authentications;
using Kpi.Core.DTOs.Users;
using Kpi.Core.Helpers;
using Kpi.Core.Models;
using Kpi.Core.Repositories;
using Kpi.Core.Services;
using Kpi.Service.Authentications;
using Microsoft.Extensions.Options;
using NLayer.Repository;

namespace Kpi.Service.Services.User
{

    public class UserService : IUserService
    {
        private AppDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly IUserRolesProjectRepository _userRolesProjectRepository;
        public UserService(
            AppDbContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings, IUserRepository userRepository, IUserRolesProjectRepository userRolesProjectRepository)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
            _userRolesProjectRepository = userRolesProjectRepository;

        }
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _userRepository.GetUserByUserName(model.UserName);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                return null;

            var roleList = await _userRolesProjectRepository.GetByRolesByUserId(user.Id);

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user, roleList);

            return new AuthenticateResponse(user, jwtToken);
        }
        public async Task<Core.Models.User> RegisterAsync(RegisterRequest model)
        {
            // Kullanıcı kontrol 
            if (await _userRepository.GetUserByUserName(model.Username) != null)
                throw new ApplicationException("Bu kullanıcı adı zaten kullanımda.");
            
            if (model.PasswordConfirm != model.Password)
                throw new ApplicationException("Şifre uyuşmuyor");
            //Hash Password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var newUser = new Core.Models.User
            {
                Username = model.Username,
                PasswordHash = hashedPassword,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            var res = await _userRepository.AddUserAsync(newUser);
            if (res != null)
                return null;
            return newUser;
        }

        public async Task<List<Role>> GetRolesByUserID(int userId)
        {
            return await _userRolesProjectRepository.GetByRolesByUserId(userId);
        }

        public async Task<List<Core.Models.User>> GetAll()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<Core.Models.User> GetById(int id)
        {
            var user =await _userRepository.GetUserById(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
