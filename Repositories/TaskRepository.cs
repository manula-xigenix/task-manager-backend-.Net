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

    public async Task<IEnumerable<TaskItem>> GetAllAsync() =>
        await _context.Tasks.ToListAsync();

    public async Task<IEnumerable<TaskItem>> GetByUserIdAsync(Guid userId) =>
        await _context.Tasks
            .Where(t => t.UserId == userId)
            .ToListAsync();

    public async Task<TaskItem?> GetByIdAsync(Guid id) =>
        await _context.Tasks.FindAsync(id);

    public async Task AddAsync(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskItem task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var task = await GetByIdAsync(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }

}
