using TrackingTasks.Models;

namespace TrackingTasks.Interfaces.Repositories
{
    public interface IWorkTaskRepository
    {

        Task<IEnumerable<WorkTask>> GetWorkTasks();
        Task<WorkTask> AddWorkTask(WorkTask workTask);
        Task<bool> DeleteWorkTask(int id);
        Task<bool> UpdateWorkTask(int id, WorkTask workTask);
    }
}
