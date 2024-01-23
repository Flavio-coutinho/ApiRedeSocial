using Microsoft.EntityFrameworkCore;

namespace ApiRedeSocial.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<User> Users { get; set; }
       
    }
}
