using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Models
{
    public class TodoList
    {   
        public int Id { get; set; }
        [StringLength(50)]
        public string ListName { get; set; }
        [StringLength(50)]
        public AspNetUser ListOwner { get; set; }
        public List<TaskItem> TaskItems { get; set; }

    }
}
