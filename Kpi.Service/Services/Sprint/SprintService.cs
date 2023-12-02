using Kpi.Core.DTOs.Sprint;
using Kpi.Core.Models.Sprints;
using Kpi.Core.Repositories;
using Kpi.Core.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Service.Services.Sprint
{
    public class SprintService : ISprintService
    {
        private readonly ISprintRepository _sprintRepository;
        private readonly ITaskService _ITaskService;
       
      
        public SprintService(ISprintRepository sprintRepository, ITaskService taskService)
        {

            _sprintRepository = sprintRepository;
            _ITaskService = taskService;
        }
        public async System.Threading.Tasks.Task<Core.Models.Sprints.Sprint> AddSprintFromExcel(string filePath,int UserId, SprintDto model)
        {
            try
            {
                Core.Models.Sprints.Sprint newSprint = new Core.Models.Sprints.Sprint
                {
                    SprintName = model.SprintName,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    DokumentUri = filePath
                };

               var res = await _sprintRepository.AddNewSprint(newSprint);
                if(res == null)
                {
                   throw new Exception("Sprint işlemi kayıt olurken bir hata oluştu");
                }

                var newTask = await _ITaskService.AddNewTask(filePath, res.Id, UserId);

                if(newTask == null) { throw new Exception("Task Kayıt etme işlemi sırasında bir hata oluştu"); }

                return newTask;

               
           

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}