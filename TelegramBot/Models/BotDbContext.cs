using Microsoft.EntityFrameworkCore;

namespace TelegramBot.Models{
    public sealed class BotDbContext : DbContext
    {

        public BotDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<BotUser> BotUsers { get; set; }

    }
}