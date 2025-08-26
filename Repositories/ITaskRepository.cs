using TaskManagementApp_Test.Models;

namespace TaskManagementApp_Test.Repositories;


public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<IEnumerable<TaskItem>> GetByUserIdAsync(Guid userId);
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(Guid id);

}

