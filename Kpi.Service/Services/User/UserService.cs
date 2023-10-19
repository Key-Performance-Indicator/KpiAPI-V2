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
        public UserService(
            AppDbContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _userRepository.GetUserByUserName(model.UserName);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                return null;

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken);
        }
        public Core.Models.User Register(RegisterRequest model)
        {
            // Kullanıcı kontrol 
            if (_userRepository.GetUserByUserName(model.Username) == null)
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
            _userRepository.AddUserAsync(newUser);
            return newUser;
        }

        public IEnumerable<Core.Models.User> GetAll()
        {
            return _context.Users;
        }

        public Core.Models.User GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
