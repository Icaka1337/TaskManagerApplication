using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }

        [Required]
        public DateTime DateTime { get; set; }


        public ICollection<ProjectUser> Users { get; set; } = new List<ProjectUser>();

    }
}
