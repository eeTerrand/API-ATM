using ApiATM.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiATM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserCard> UserCards { get; set; }
        public DbSet<UserOperation> UserOperation { get; set; }
    }
}
