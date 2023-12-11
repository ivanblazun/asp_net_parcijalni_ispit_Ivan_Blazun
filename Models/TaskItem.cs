using System.ComponentModel.DataAnnotations;

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string TaskName { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
        [StringLength(200)]
        public string? Type { get; set; }
        public TodoList List { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime Created { get; set; } = DateTime.Now;

        public string? UserId { get; set; }
        public virtual AspNetUser? User { get; set; }
    }
}
