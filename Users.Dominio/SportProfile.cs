namespace Users.Dominio ;
using Common;

    public class SportProfile : BaseDomainModel
    {
        public int ExcerciseByWeek { get; set; }
        public bool HasInjuries { get; set; }
        public decimal Weight { get; set; }
        public decimal Heigth { get; set; }
        public string TestMe { get; set; } = "x";
        public string? WhatInjuries { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public virtual ApplicationUser User { get; set; } = new();
        public Guid PhysicalLevelId { get; set; }
        public virtual PhysicalLevel PhysicalLevel { get; }
    }
