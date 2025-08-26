namespace TaskManagementApp_Test.Services;
using TaskManagementApp_Test.Models;
using TaskManagementApp_Test.Repositories;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<TaskItem>> GetAllAsync() => _repository.GetAllAsync();
    public Task<TaskItem?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);
    public Task AddAsync(TaskItem task) => _repository.AddAsync(task);
    public Task UpdateAsync(TaskItem task) => _repository.UpdateAsync(task);
    public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
    public Task<IEnumerable<TaskItem>> GetByUserIdAsync(Guid userId) =>
        _repository.GetByUserIdAsync(userId);
}

