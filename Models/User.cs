using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp_Test.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();  // PK, auto-generated
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }

}
