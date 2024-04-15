namespace Users.Aplication.Models.Common.DTO ;

    public class SportProfileDTO
    {
        public Guid Id { get; set; }
        public int ExcerciseByWeek { get; set; }
        public Guid PhysicalLevelId { get; set; }
        public bool HasInjuries { get; set; }
        public string WhatInjuries { get; set; } = string.Empty;

        public decimal Weight { get; set; }
        public decimal Heigth { get; set; }
    }
