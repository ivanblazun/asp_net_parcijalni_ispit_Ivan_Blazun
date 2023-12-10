using System.ComponentModel.DataAnnotations;

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string TaskName { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
        [StringLength(200)]
        public string? Type { get; set; }
        public TodoList List { get; set; }

        public bool IsDone { get; set; } = false;
    }
}
