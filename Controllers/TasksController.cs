using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementApp_Test.DTOs;
using TaskManagementApp_Test.Models;
using TaskManagementApp_Test.Services;

namespace TaskManagementApp_Test.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    private Guid GetUserId() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    private bool IsAdmin() =>
        User.IsInRole("Admin");

    // GET api/tasks
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (IsAdmin())
            return Ok(await _service.GetAllAsync());

        var userId = GetUserId();
        var tasks = await _service.GetByUserIdAsync(userId);

        if (tasks == null || !tasks.Any())
            throw new Exception("No tasks found for this user.");

        return Ok(tasks);
    }

    // GET api/tasks/{id}
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var task = await _service.GetByIdAsync(id);
        if (task == null)
            throw new Exception($"Task with ID {id} not found.");

        if (!IsAdmin() && task.UserId != GetUserId())
            throw new Exception("You are not authorized to access this task.");

        return Ok(task);
    }

    // POST api/tasks
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(TaskCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new Exception("Task title is required.");

        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            UserId = GetUserId(),
            Title = dto.Title,
            Description = dto.Description,
            IsCompleted = dto.IsCompleted,
            DueDate = dto.DueDate
        };

        await _service.AddAsync(task);
        return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
    }

    // PUT api/tasks/{id}
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, TaskUpdateDto dto)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            throw new Exception($"Task with ID {id} not found.");

        if (!IsAdmin() && existing.UserId != GetUserId())
            throw new Exception("You are not authorized to update this task.");

        // Update only allowed fields
        existing.Title = dto.Title;
        existing.Description = dto.Description;
        existing.IsCompleted = dto.IsCompleted;
        existing.DueDate = dto.DueDate;

        await _service.UpdateAsync(existing);
        return NoContent();
    }

    // DELETE api/tasks/{id}
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            throw new Exception($"Task with ID {id} not found.");

        if (!IsAdmin() && existing.UserId != GetUserId())
            throw new Exception("You are not authorized to delete this task.");

        await _service.DeleteAsync(id);
        return NoContent();
    }
}
