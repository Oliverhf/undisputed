using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Undisputed.Models;

namespace Undisputed.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        private readonly DbContextOptions<ApplicationDbContext> options;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this.options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
           .HasMany(u => u.Topics)
           .WithOne(c => c.AppUser);

            builder.Entity<AppUser>()
            .HasMany(u => u.JoinedTopics)
            .WithMany(c => c.Users)
            .UsingEntity<UserTopic>(
                x => x.HasOne(x => x.Topic).WithMany().HasForeignKey(x => x.TopicId),
                x => x.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId));

            builder.Entity<AppUser>()
            .HasMany(u => u.NeatTopics)
            .WithOne(c => c.AppUser);

            builder.Entity<AppUser>()
            .HasMany(u => u.JoinedNeatTopics)
            .WithMany(c => c.Users)
            .UsingEntity<UserNeatTopic>(
                x => x.HasOne(x => x.NeatTopic).WithMany().HasForeignKey(x => x.NeatTopicId),
                x => x.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId));

            builder.Entity<AppUser>()
            .HasMany(u => u.Teams)
            .WithOne(c => c.AppUser);

            builder.Entity<AppUser>()
            .HasMany(u => u.JoinedTeams)
            .WithMany(c => c.Users)
            .UsingEntity<UserTeam>(
                x => x.HasOne(x => x.Team).WithMany().HasForeignKey(x => x.TeamId),
                x => x.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId));

        }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<NeatTopic> NeatTopics { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
