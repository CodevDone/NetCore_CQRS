
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;
using CodevDone.CQRS.Domain.Aggregates.PostAgregate;
using CodevDone.CQRS.Dal.Configurations;

namespace CodevDone.CQRS.Dal
{
    public class DataContext : IdentityDbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:mssql_azure,1433; Initial Catalog=CQRS_social; Persist Security Info=False; User ID=SA; Password=Sql_Server123; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=True; Connection Timeout=30;");
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostCommentConfig());
            builder.ApplyConfiguration(new PostInteractionConfig());
            builder.ApplyConfiguration(new UserProfileConfig());
            builder.ApplyConfiguration(new IdentityUserLoginConfig());
            builder.ApplyConfiguration(new IdentityUserRoleConfig());
            builder.ApplyConfiguration(new IdentityUsderTokenConfig());
        }

    }
}