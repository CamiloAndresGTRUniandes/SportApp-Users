using Users.Dominio.Common;


namespace Users.Dominio
{
    public class Genre : BaseDomainModel
    {
        public Genre()
        {
            Users = new HashSet<ApplicationUser>();
        }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}
