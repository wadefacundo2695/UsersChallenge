using Microsoft.EntityFrameworkCore;
using UsersChallenge.Domain.Ports;

namespace UsersChallenge.Infrastructure
{
    public class UserContext: DbContext
    {
        public DbSet<User>? Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.BirthDate).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Active).IsRequired();
        }
    }
}
