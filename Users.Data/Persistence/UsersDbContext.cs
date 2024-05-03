namespace Users.Infraestructure.Persistence ;
using Configuration;
using Dominio;
using Dominio.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

    public class UsersDbContext : IdentityDbContext<ApplicationUser>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activity { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<TypeOfNutrition> TypeOfNutrition { get; set; }
        public DbSet<NutricionalAllergy> NutricionalAllergy { get; set; }
        public DbSet<NutrionalProfile> NutrionalProfile { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<UserAllergy> UserAllergy { get; set; }
        public DbSet<UserGoal> UserGoal { get; set; }
        public DbSet<SportProfile> SportProfile { get; set; }
        public DbSet<UserRecommendation> UserRecommendation { get; set; }
        public DbSet<PhysicalLevel> PhysicalLevel { get; }
        public DbSet<TypeOfRecommendation> TypeOfRecommendation { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<EnrollServiceUser> EnrollServiceUser { get; set; }
        public DbSet<UserGoalTracking> UserGoalTracking { get; set; }
        public DbSet<ProductEventSuscription> ProductEventSuscription { get; set; }
        public DbSet<RecordTrainingSession> RecordTrainingSession { get; set; }
        public DbSet<Intensity> Intensity { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.Enabled = true;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateAt = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new IntensityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TypeOfRecommendationsConfiguration());
            modelBuilder.ApplyConfiguration(new PlanConfiguration());
            modelBuilder.Entity<Activity>()
                .HasMany(p => p.Users)
                .WithMany(p => p.Activities)
                .UsingEntity<UserActivity>(
                    c => c.HasKey(e => new { e.UsersId, e.ActivityId, e.Id })
                );


            modelBuilder.Entity<NutrionalProfile>()
                .HasOne(m => m.User)
                .WithOne(m => m.NutrionalProfile)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<SportProfile>()
                .HasOne(m => m.User)
                .WithOne(m => m.SportProfile)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ApplicationUser>()
                .HasMany(p => p.NutricionalAllergies)
                .WithMany(p => p.Users)
                .UsingEntity<UserAllergy>(
                    c => c.HasKey(e => new { e.NutricionalAllergyId, e.UsersId, e.Id })
                );


            modelBuilder.Entity<ApplicationUser>()
                .HasMany(p => p.Goals)
                .WithMany(p => p.Users)
                .UsingEntity<UserGoal>(
                    c => c.HasKey(e => new { e.GoalId, e.UsersId, e.Id })
                );


            modelBuilder.Entity<ApplicationUser>()
                .HasMany<UserRecommendation>()
                .WithOne(g => g.User)
                .HasForeignKey(j => j.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<UserRecommendation>()
                .WithOne(g => g.UserAsociate)
                .HasForeignKey(j => j.UserAsociateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<EnrollServiceUser>()
                .WithOne(g => g.User)
                .HasForeignKey(j => j.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<EnrollServiceUser>()
                .WithOne(g => g.UserAsociate)
                .HasForeignKey(j => j.UserAsociateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
