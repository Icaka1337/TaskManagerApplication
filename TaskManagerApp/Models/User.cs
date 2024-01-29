using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        public string Email { get; set; }

        public ICollection<ProjectUser> Projects { get; set; } = new List<ProjectUser>();

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
