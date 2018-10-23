using Microsoft.EntityFrameworkCore;

namespace TelegramBot.Models{
    public class BotDbContext : DbContext{
        public DbSet<BotUser> BotUsers { get; set; }

        public BotDbContext(DbContextOptions options) : base(options){
            Database.EnsureCreated();
        }
    }
}