using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Beachcombing_API.Models;

namespace Beachcombing_API.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
        {
        public DbSet<FavoritePlace> FavoritePlaces { get; set; } // Add this line for the FavoritePlace table
        public DbSet<CleanupRecord> CleanupRecords { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);


            builder.Entity<CleanupRecord>().HasKey(cr => cr.Id);

            builder.Entity<FavoritePlace>().HasKey(fp => fp.Id);
            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(new User
            {
                Id = "1", // 确保这是唯一的
                UserName = "User1",
                Email = "test@coventry.com",
                NormalizedEmail = "TEST@COVENTRY.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Test1234!"), 
                SelfIntro = "hello",// 使用实际的 UserManager 来生成哈希
                AvatarUrl = "https://beachcombingstorage.blob.core.windows.net/useravatar/user1.jpg",
                SecurityStamp = string.Empty // 通常用于标识用户密码更改
            });

            
        }

        
    }
    }
