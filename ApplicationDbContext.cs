using auth_task.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_task
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
