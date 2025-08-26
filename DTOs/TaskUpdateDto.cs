namespace TaskManagementApp_Test.DTOs;

public class TaskUpdateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
    public DateTime? DueDate { get; set; }
}

