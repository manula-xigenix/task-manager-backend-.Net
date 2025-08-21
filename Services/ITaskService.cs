namespace TaskManagementApp_Test.Services;
using TaskManagementApp_Test.Models;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(int id);
}
