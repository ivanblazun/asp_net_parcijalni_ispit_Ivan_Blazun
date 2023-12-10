using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Models
{
    public class AspNetUser : IdentityUser
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(150)]
        public string? Address { get; set; }

        [ForeignKey("UserId")]
        public TodoList TodoList { get; set; }
    }
}
