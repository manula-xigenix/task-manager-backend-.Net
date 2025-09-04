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

    public Task<IEnumerable<TaskItem>> GetCompletedAsync() => _repository.GetCompletedAsync();
    public Task<IEnumerable<TaskItem>> GetRemainingAsync() => _repository.GetRemainingAsync();
    public Task<IEnumerable<TaskItem>> GetCompletedByUserIdAsync(Guid userId) => _repository.GetCompletedByUserIdAsync(userId);
    public Task<IEnumerable<TaskItem>> GetRemainingByUserIdAsync(Guid userId) => _repository.GetRemainingByUserIdAsync(userId);

    public Task<int> GetCompletedCountAsync() => _repository.GetCompletedCountAsync();
    public Task<int> GetRemainingCountAsync() => _repository.GetRemainingCountAsync();
    public Task<int> GetCompletedCountByUserIdAsync(Guid userId) => _repository.GetCompletedCountByUserIdAsync(userId);
    public Task<int> GetRemainingCountByUserIdAsync(Guid userId) => _repository.GetRemainingCountByUserIdAsync(userId);

}

