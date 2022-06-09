using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class FattalDbContext : DbContext
    {
        public FattalDbContext(DbContextOptions<FattalDbContext> options)
            : base(options) { }

        public DbSet<User> SYS_Users { get; set; }
        public DbSet<VariableDetails> SYS_VariableDetails { get; set; }
        public DbSet<UserAccess> SYS_UsersAccess { get; set; }
        public DbSet<MenuAccess> SYS_MenuAccess { get; set; }
        public DbSet<Node> SYS_Nodes { get; set; }
    }
}
