namespace Users.Aplication.Models.Common.DTO ;

    public class NutrionalProfileDTO
    {
        public Guid Id { get; set; }
        public bool HasAllergies { get; set; }
        public bool HasMedicalAllergies { get; set; }
        public Guid TypeOfNutritionId { get; set; }
        public decimal AveragesCaloriesPerDay { get; set; }
    }
