using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrackingTasks.Interfaces.Repositories;
using TrackingTasks.Models;

namespace TrackingTasks.Repositories
{
    public class WorkTaskRepository : IWorkTaskRepository
    {

        private readonly WorkTaskDbContext _dbcontext;
        //private readonly IMapper _mapper;

        public WorkTaskRepository(WorkTaskDbContext _dbcontext)
        {
            _dbcontext = _dbcontext ?? throw new ArgumentNullException(nameof(_dbcontext));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        public async Task<IEnumerable<WorkTask>> GetWorkTasks()
        {
            var worktasks = await _dbcontext.WorkTask.ToListAsync().ConfigureAwait(false);
            if (worktasks != null)
            {
                return worktasks;
            }
            return null;
        }
        public async Task<WorkTask> AddWorkTask(WorkTask workTask)
        {
            if (workTask == null)
            {
                throw new ArgumentNullException(nameof(workTask));
            }

            _dbcontext.WorkTask.Add(workTask);
            await _dbcontext.SaveChangesAsync();
            return workTask;


        }
        public async Task<bool> DeleteWorkTask(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            // Find the WokTask to be deleted in the repository
            var workTaskToDelete = await _dbcontext.WorkTask.FindAsync(id);

            // If there is no such WokTask, return an error response with status code 404 (Not Found)
            if (workTaskToDelete == null)
            {
                return false;
            }
            // Remove the WokTask from the repository
            // The DeleteWorkTask method returns true if the WorkTask was successfully deleted

            if (workTaskToDelete != null)
            {
                //Delete that feedback
                _dbcontext.Entry(workTaskToDelete).State = EntityState.Modified;
                _dbcontext.WorkTask.Remove(workTaskToDelete);
                //Commit the transaction
                await _dbcontext.SaveChangesAsync();
                // Return a response message with status code 204 (No Content), To indicate that the operation was successful
                return true;
            }
            // Otherwise return a 400 (Bad Request) error response
            return false;
        }
        public async Task<bool> UpdateWorkTask(int id, WorkTask workTask)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (workTask == null)
            {
                throw new ArgumentNullException(nameof(workTask));
            }
            var workTaskToUpdate = await _dbcontext.WorkTask.FindAsync(id);

            if (workTaskToUpdate == null)
            {
                return false;
            }

            if (workTaskToUpdate == null || workTaskToUpdate.Id != id)
            {
                return false;
            }
            _dbcontext.Entry(workTaskToUpdate).State = EntityState.Modified;
            
            if (workTask != null)
            {
                //Update that feedback
                _dbcontext.WorkTask.Update(workTaskToUpdate);
                //Commit the transaction
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
