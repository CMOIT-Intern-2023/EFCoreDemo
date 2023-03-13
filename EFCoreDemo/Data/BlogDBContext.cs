using EFCoreDemo.Configurations;
using EFCoreDemo.Models.BlogModels;
using EFCoreDemo.Models.PostModels;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Data
{
    public class BlogDBContext : DbContext
    {
        public DbSet<BlogModel> Blog { get; set; }
        public DbSet<PostModel> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region BlogConfigruation

            modelBuilder.Entity<BlogModel>().HasKey(x => x.Id);
            modelBuilder.Entity<BlogModel>().Property(b => b.Url).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<BlogModel>().Property(b => b.Content).IsRequired();

            #endregion

            #region PostConfiguration

            modelBuilder.Entity<PostModel>().HasKey(x => x.PostId);
            modelBuilder.Entity<PostModel>().Property(b => b.Title).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<PostModel>().Property(b => b.Content).IsRequired();

            #endregion
        }
    }
}
