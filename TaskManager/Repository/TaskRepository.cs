using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Model;
using TaskManager.Repository.IRepository;

namespace TaskManager.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataBaseContext _dbContext;
        public TaskRepository(DataBaseContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task Create(Tasks entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task Delete(Tasks entity)
        {
            _dbContext.Remove(entity);
            await Save();
        }

        public async Task<List<Tasks>> GetAll()
        {
            var task = await _dbContext.Tasks.ToListAsync();
            return task;
        }

        public async Task<Tasks> GetById(int id)
        {
            var taskId =await _dbContext.Tasks.FindAsync(id);
            return taskId;
        }

        public bool IsRecordExsist(string name)
        {
            var dulicate= _dbContext.Tasks.AsQueryable().Where(x=>x.TaskName.ToLower()==name.ToLower()).Any();
            return dulicate;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Tasks entity)
        {
            _dbContext.Tasks.Update(entity);
            await Save();
        }
    }
}
