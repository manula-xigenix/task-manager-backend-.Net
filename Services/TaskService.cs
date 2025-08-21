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
    public Task<TaskItem?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
    public Task AddAsync(TaskItem task) => _repository.AddAsync(task);
    public Task UpdateAsync(TaskItem task) => _repository.UpdateAsync(task);
    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}

