namespace Users.Dominio ;
using Common;

    public class Plan : BaseDomainModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<EnrollServiceUser> EnrollServiceUsers { get; set; }
    }
