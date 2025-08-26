using TaskManagementApp_Test.Data;
using TaskManagementApp_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementApp_Test.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        try
        {
            return await _context.Tasks.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving all tasks.", ex);
        }
    }

    public async Task<IEnumerable<TaskItem>> GetByUserIdAsync(Guid userId)
    {
        try
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving tasks for user {userId}.", ex);
        }
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id)
    {
        try
        {
            return await _context.Tasks.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while retrieving the task with ID {id}.", ex);
        }
    }

    public async Task AddAsync(TaskItem task)
    {
        try
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while adding a new task.", ex);
        }
    }

    public async Task UpdateAsync(TaskItem task)
    {
        try
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while updating the task with ID {task.Id}.", ex);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var task = await GetByIdAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while deleting the task with ID {id}.", ex);
        }
    }
}
