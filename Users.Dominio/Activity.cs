namespace Users.Dominio ;
using Common;

    public class Activity : BaseDomainModel
    {
        public Activity()
        {
            Users = new HashSet<ApplicationUser>();
        }


        public string Name { get; set; } = string.Empty;

        public ICollection<ApplicationUser> Users { get; set; }
    }
