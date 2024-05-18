namespace Users.Dominio ;
using Common;

    public class Plan : BaseDomainModel
    {
        public Plan()
        {
            EnrollServiceUsers = new HashSet<EnrollServiceUser>();
            SuscriptionUsers = new HashSet<SuscriptionUser>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<EnrollServiceUser> EnrollServiceUsers { get; set; }
        public ICollection<SuscriptionUser> SuscriptionUsers { get; set; }
    }
