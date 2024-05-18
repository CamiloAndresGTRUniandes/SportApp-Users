namespace Users.Dominio ;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

    public class SuscriptionUser : BaseDomainModel
    {
        public Guid SubscriptionId { get; set; }
        public string UserId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Plan Plan { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
