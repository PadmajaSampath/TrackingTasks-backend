using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingTasks.Interfaces.Services;
using TrackingTasks.Models;
using TrackingTasks.Services;

namespace TrackingTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTaskController : ControllerBase
    {
        private readonly IWorkTaskService _workTaskService;

        public WorkTaskController(IWorkTaskService workTaskService)
        {
            _workTaskService = workTaskService ?? throw new ArgumentNullException(nameof(workTaskService));
        }
        //private readonly WorkTaskDbContext _workTaskDbContext;
                

        [HttpGet]   
        [Route("GetWorkTask")]
        public async Task<ActionResult<IEnumerable<WorkTask>>> GetWorkTasks()
        {
            //throw new Exception($"Error while trying to call GetFeedbacks method.");
            var response = await _workTaskService.GetWorkTasks().ConfigureAwait(false);
            return response != null ? Ok(response) : NotFound();
        }

        [HttpPost]
        [Route("AddWorkTask")]
        public async Task<WorkTask> AddWorkTask(WorkTask objWorkTask)
        {
                     

            var response = await _workTaskService.AddWorkTask(objWorkTask).ConfigureAwait(false);
            return objWorkTask;
        }

        [HttpPatch]
        [Route("UpdateWorkTask/{id}")]

        public async Task<ActionResult> UpdateWorkTask(int id, WorkTask workTask)
        {
            //_workTaskDbContext.Entry(objWorkTask).State = EntityState.Modified;
            //await _workTaskDbContext.SaveChangesAsync();    
            //return workTask;

            var response = await _workTaskService.UpdateWorkTask(id, workTask).ConfigureAwait(false);
            return response ? Ok(response) : NotFound();
        }

        [HttpDelete]
        [Route("DeleteWorkTask/{id}")]

        public async Task<ActionResult> DeleteFeedback(int id)
        {
            var response = await _workTaskService.DeleteWorkTask(id).ConfigureAwait(false);

            return response ? NoContent() : NotFound();
        }

    }
}
