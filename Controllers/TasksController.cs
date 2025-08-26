using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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


    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var task = await _service.GetByIdAsync(id);
        return task == null ? NotFound() : Ok(task);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(TaskItem task)
    {
        await _service.AddAsync(task);
        return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TaskItem task)
    {
        if (id != task.Id) return BadRequest();
        await _service.UpdateAsync(task);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}

