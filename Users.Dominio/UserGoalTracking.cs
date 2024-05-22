namespace Users.Dominio ;
using Common;

    public class UserGoalTracking : BaseDomainModel
    {
        public decimal KgOfMuscleGained { get; set; }
        public decimal PrInFlatBenchPress { get; set; }
        public decimal CmsInArm { get; set; }
        public decimal PrInSquad { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
