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
}
