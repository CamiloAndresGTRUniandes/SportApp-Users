namespace Users.Dominio ;
using Common;

    public class PhysicalLevel : BaseDomainModel
    {
        public PhysicalLevel()
        {
            SportProfile = new HashSet<SportProfile>();
        }

        public string Name { get; set; } = string.Empty;
        public ICollection<SportProfile> SportProfile { get; set; }
    }
