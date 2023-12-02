using Kpi.Core.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Kpi.Core.Repositories;

namespace Kpi.Service.Services.Task
{
    public class TasksService : ITaskService
    {
        private readonly ITaskRespoistory _taskRespoistory;
        public TasksService(ITaskRespoistory taskRespoistory) {
        
           _taskRespoistory = taskRespoistory;
        }

        public async Task<Core.Models.Tasks.Task> AddNewTask(string excelFilePath, int SprintId, int UserId)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            FileInfo file = new FileInfo(excelFilePath);
            var package = new ExcelPackage(file);
            // Sayfa sayısını al
            int sheetCount = package.Workbook.Worksheets.Count;
            var worksheet = package.Workbook.Worksheets[sheetCount-1]; //ilk sayfa
            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;

            // Excel verilerini bir JSON nesnesine dönüştür

            Core.Models.Tasks.Task newTask = new Core.Models.Tasks.Task();

            for (int row = 2; row <= rowCount; row++) // İlk satırı başlık olarak alıyoruz
            {
                
               
                for (int col = 1; col <= colCount; col++)
                {
                    newTask.Title = worksheet.Cells[row, 1].Value?.ToString();
                    newTask.Description = worksheet.Cells[row, 2].Value?.ToString();
                    newTask.SprintId = SprintId;
                    newTask.UserId = UserId;
                    newTask.AssignedTo = worksheet.Cells[row, 3].Value?.ToString();
                    newTask.RemainingWork = Convert.ToInt32(worksheet.Cells[row, 4].Value);
                    newTask.ClosedDate = (DateTime)worksheet.Cells[row, 5].Value;
                    newTask.State = Convert.ToInt32(worksheet.Cells[row, 6].Value);
                    //newTask.Tag = Convert.ToInt32(worksheet.Cells[row, 4].Value);

                    // Diğer özellikler de aynı şekilde alınabilir

                }

   

            }

            //list
            var res = _taskRespoistory.AddTask(newTask);
            return newTask;

        }


    }
}
