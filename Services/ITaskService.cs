namespace TaskManagementApp_Test.Services;
using TaskManagementApp_Test.Models;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<TaskItem>> GetByUserIdAsync(Guid userId);

    Task<IEnumerable<TaskItem>> GetCompletedAsync();
    Task<IEnumerable<TaskItem>> GetRemainingAsync();
    Task<IEnumerable<TaskItem>> GetCompletedByUserIdAsync(Guid userId);
    Task<IEnumerable<TaskItem>> GetRemainingByUserIdAsync(Guid userId);

    Task<int> GetCompletedCountAsync();
    Task<int> GetRemainingCountAsync();
    Task<int> GetCompletedCountByUserIdAsync(Guid userId);
    Task<int> GetRemainingCountByUserIdAsync(Guid userId);

}
