namespace Users.Dominio ;
using Common;

    public class State : BaseDomainModel
    {
        public State()
        {
            Cities = new HashSet<City>();
        }

        public string Name { get; set; } = string.Empty;
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; } = new();
        public ICollection<City> Cities { get; set; }
        public ICollection<ApplicationUser>? users { get; set; }
    }
