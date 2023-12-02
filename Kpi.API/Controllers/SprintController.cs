using Kpi.Core.DTOs.Sprint;
using Kpi.Core.Services;
using Kpi.Service.Services.Sprint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kpi.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SprintController : ControllerBase
    {
        private ISprintService _sprintservis;

        public SprintController(ISprintService sprintService) {

            _sprintservis = sprintService;
        
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadExcel([FromForm] SprintDto model)
        {
            //UserId = auth ile alınacak

            int UserId = 18;

            if (model == null || model.ExcelFile == null || model.ExcelFile.Length == 0)
            {
                return BadRequest("Lütfen bir dosya yükleyin.");
            }

            try
            {
                string fileName = Guid.NewGuid().ToString() + "_" + model.ExcelFile.FileName;
                string filePath = Path.Combine(fileName); // Dosyanın kaydedileceği yol

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ExcelFile.CopyToAsync(stream);
                }


              await _sprintservis.AddSprintFromExcel(filePath,UserId,model);

                return Ok("Excel dosyası başarıyla yüklendi ve tasklara dönüştürüldü.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }


        }
    }
}
