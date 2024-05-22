namespace Users.Dominio ;
using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Activities = new HashSet<Activity>();
            Goals = new HashSet<Goal>();
        }

        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Guid? GenreId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? StateId { get; set; }
        public Guid? CityId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public virtual ICollection<NutricionalAllergy>? NutricionalAllergies { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
        public virtual NutrionalProfile NutrionalProfile { get; set; }
        public virtual SportProfile SportProfile { get; set; }
        public virtual UserGoalTracking UserGoalTracking { get; set; }
        public virtual ICollection<ProductEventSuscription> ProductEventSuscriptions { get; set; }
        public virtual ICollection<RecordTrainingSession> RecordTrainingSessions { get; set; }
        public virtual SuscriptionUser SuscriptionUser { get; set; }
    }
