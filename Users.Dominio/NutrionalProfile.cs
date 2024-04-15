namespace Users.Dominio ;
using Common;

    public class NutrionalProfile : BaseDomainModel
    {
        public bool HasAllergies { get; set; }
        public bool HasMedicalAllergies { get; set; }

        public Guid TypeOfNutritionId { get; set; }
        public virtual TypeOfNutrition TypeOfNutrition { get; } = new();
        public string UserId { get; set; } = string.Empty;
        public virtual ApplicationUser User { get; set; } = new();
        public decimal AveragesCaloriesPerDay { get; set; }
    }
