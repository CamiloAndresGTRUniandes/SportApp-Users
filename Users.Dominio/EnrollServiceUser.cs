namespace Users.Dominio ;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

    public class EnrollServiceUser : BaseDomainModel
    {
        public string UserId { get; set; }
        public string UserAsociateId { get; set; }
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public Guid PlanId { get; set; }
        public Guid CategoryId { get; set; }
        public bool WasPayed { get; set; }
        public string CategoryName { get; set; }
        public virtual Plan Plan { get; set; }
        public DateTime? StartSuscription { get; set; }
        public DateTime? EndSuscription { get; set; }
        public ICollection<UserRecommendation> UserRecommendations { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("UserAsociateId")]
        public virtual ApplicationUser UserAsociate { get; set; }
    }
