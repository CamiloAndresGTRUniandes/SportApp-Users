namespace Users.Dominio ;
using Common;

    public class EnrollServiceUser : BaseDomainModel
    {
        public string UserId { get; set; }
        public string UserAsociateId { get; set; }
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public Guid PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public ICollection<UserRecommendation> TypUserRecommendations { get; set; }
    }
