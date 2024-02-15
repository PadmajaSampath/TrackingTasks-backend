using TrackingTasks.Interfaces.Repositories;
using TrackingTasks.Interfaces.Services;
using TrackingTasks.Models;
using TrackingTasks.Repositories;

namespace TrackingTasks.Services
{
    public class WorkTaskService: IWorkTaskService
    {
        public readonly IWorkTaskRepository _workTaskRepository;
        private readonly ILogger<WorkTaskService> _logger;

        public WorkTaskService(IWorkTaskRepository workTaskRepository, ILogger<WorkTaskService> logger)
        {
            _workTaskRepository = workTaskRepository ?? throw new ArgumentNullException(nameof(workTaskRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<IEnumerable<Models.WorkTask>> GetWorkTasks()
        {
            try
            {
                return await _workTaskRepository.GetWorkTasks();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while trying to call GetWorkTasks in service class, Error Message = {exception}.");
                throw;
            }
        }
        public async Task<WorkTask> AddWorkTask(WorkTask workTask)
        {
            try
            {
                if (workTask == null)
                {
                    throw new ArgumentNullException(nameof(workTask));
                }
                return await _workTaskRepository.AddWorkTask(workTask);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while trying to call AddWorkTask in service class, Error Message = {exception}.");
                throw;
            }
        }
        public async Task<bool> DeleteWorkTask(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                return await _workTaskRepository.DeleteWorkTask(id);

            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while trying to call DeleteWorkTask in service class, Error Message = {exception}.");
                throw;// If an uncaught exception occurs, return an error response, with status code 500 (Internal Server Error)
            }
        }
        public async Task<bool> UpdateWorkTask(int id, WorkTask workTask)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                if (workTask == null)
                {
                    throw new ArgumentNullException(nameof(workTask));
                }
                return await _workTaskRepository.UpdateWorkTask(id, workTask);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while trying to call UpdateWorkTask in service class, Error Message = {exception}.");
                throw;
            }
        }


    }
}
