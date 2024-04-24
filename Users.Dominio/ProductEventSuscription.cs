namespace Users.Dominio ;
using Common;

    public class ProductEventSuscription : BaseDomainModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string UserId { get; set; }
        public Guid PlanId { get; set; }
        public string PlanName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public ApplicationUser User { get; set; }
        public Plan Plan { get; set; }
    }
