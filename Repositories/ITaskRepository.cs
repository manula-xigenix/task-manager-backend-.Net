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

    Task<IEnumerable<TaskItem>> GetCompletedAsync();
    Task<IEnumerable<TaskItem>> GetRemainingAsync();
    Task<IEnumerable<TaskItem>> GetCompletedByUserIdAsync(Guid userId);
    Task<IEnumerable<TaskItem>> GetRemainingByUserIdAsync(Guid userId);

    Task<int> GetCompletedCountAsync();
    Task<int> GetRemainingCountAsync();
    Task<int> GetCompletedCountByUserIdAsync(Guid userId);
    Task<int> GetRemainingCountByUserIdAsync(Guid userId);



}

