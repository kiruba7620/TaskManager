using TaskManager.Model;

namespace TaskManager.Repository.IRepository
{
    public interface ITaskRepository
    {
        Task<List<Tasks>> GetAll();

        Task<Tasks> GetById(int id);

        Task Create(Tasks entity);

        Task  Update(Tasks entity);

        Task Delete(Tasks entity);

        Task Save();

        bool IsRecordExsist(string name);

    }
}
