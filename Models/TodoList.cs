using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string ListName { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public AspNetUser User { get; set; }
        public List<TaskItem> TaskItems { get; set; }

    }
}
