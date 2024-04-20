using Microsoft.EntityFrameworkCore;
using DatabaseAPI.User.Models;

namespace DatabaseAPI
{
    public class FunBoardGameDBContext : DbContext
    {
        public DbSet<User.Models.User> Users { get; private set; }
        public DbSet<UserSession> UserSessions { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Server=localhost;Port=5432;Database=fun_board_games;UserId=postgres;Password=12345;", m =>
            {
                m.MigrationsHistoryTable("Migrations", "public");
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User.Models.User>().Property(user => user.Created_At).HasDefaultValueSql("now()");
            modelBuilder.Entity<UserSession>().Property(userSession => userSession.Created_At).HasDefaultValueSql("now()");
        }
    }
}
