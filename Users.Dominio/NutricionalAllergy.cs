namespace Users.Dominio ;
using Common;

    public class NutricionalAllergy : BaseDomainModel
    {
        public NutricionalAllergy()
        {
            Users = new HashSet<ApplicationUser>();
        }

        public string Name { get; set; } = string.Empty;
        public ICollection<ApplicationUser> Users { get; set; }
    }
