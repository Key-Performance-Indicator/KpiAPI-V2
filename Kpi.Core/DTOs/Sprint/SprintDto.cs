using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.DTOs.Sprint
{
    public class SprintDto
    {
        public string SprintName { get; set; }
        public IFormFile ExcelFile { get; set; }

        public int UserId {  get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
