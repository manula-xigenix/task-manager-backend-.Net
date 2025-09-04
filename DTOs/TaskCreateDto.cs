using TaskManagementApp_Test.Models;

namespace TaskManagementApp_Test.DTOs
{
    public class TaskCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Models.TaskStatus Status { get; set; } = Models.TaskStatus.ToDo;
        public DateTime? DueDate { get; set; }
    }

}
