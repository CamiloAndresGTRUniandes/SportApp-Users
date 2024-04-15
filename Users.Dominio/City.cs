namespace Users.Dominio ;
using Common;

    public sealed class City : BaseDomainModel
    {
        public string Name { get; set; } = string.Empty;
        public Guid StateId { get; set; }
        public State State { get; set; } = new();
        public ICollection<ApplicationUser>? users { get; set; }
    }
