using FitnessClub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationMember>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Members> Members { get; set; }
        public DbSet<Sessions> Sessions { get; set; }
        public DbSet<Trainers> Trainers { get; set; }
        public DbSet<Recommendations> Recommendations { get; set; }
        public DbSet<MotivationalQotes> MotivationalQotes { get; set; }
        public DbSet<MemberTrainer> MemberTrainer { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        public DbSet<BookedSessions> BookedSessions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Members>().ToTable("Members");
            builder.Entity<Trainers>().ToTable("Trainers");
            builder.Entity<Sessions>().ToTable("Sessions");
            builder.Entity<MemberTrainer>().ToTable("MemberTrainer");

            builder.Entity<Members>()
                .HasMany(m => m.MemberTrainers)  
                .WithOne(mt => mt.Member)  
                .HasForeignKey(mt => mt.MemberId);

            builder.Entity<Trainers>()
                .HasMany(t => t.MemberTrainers) 
                .WithOne(mt => mt.Trainer)  
                .HasForeignKey(mt => mt.TrainerId); 

            builder.Entity<MemberTrainer>()
                .HasKey(mt => new { mt.MemberId, mt.TrainerId });  

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "427bbfc7-064c-4408-9f5b-01d9f16d0d30", Name = "member", NormalizedName = "MEMBER" },
                new IdentityRole { Id = "bd57e38a-0d06-4031-8de5-7e16c8bc27f3", Name = "admin", NormalizedName = "ADMIN" }
            );
        }

    }
}
