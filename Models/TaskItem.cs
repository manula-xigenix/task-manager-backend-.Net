using TaskStatusEnum = TaskManagementApp_Test.Models.TaskStatus;

namespace TaskManagementApp_Test.Models;

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // Foreign key
    public Guid UserId { get; set; }

    // Navigation property
    public User User { get; set; } = null!;

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskStatusEnum Status { get; set; } = TaskStatusEnum.ToDo;
    public DateTime? DueDate { get; set; }
}
