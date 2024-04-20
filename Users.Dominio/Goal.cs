namespace Users.Dominio ;
using Common;

    public class Goal : BaseDomainModel
    {
        public Goal()
        {
            Users = new HashSet<ApplicationUser>();
        }

        public string Name { get; set; } = string.Empty;
        public ICollection<ApplicationUser> Users { get; set; }
    }
