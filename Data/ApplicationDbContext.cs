using asp_net_parcijalni_ispit_Ivan_Blazun.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace asp_net_parcijalni_ispit_Ivan_Blazun.Data
{
    public class ApplicationDbContext : IdentityDbContext<AspNetUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
    }
}