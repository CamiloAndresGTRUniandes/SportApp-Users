namespace Users.Dominio ;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

    public class UserRecommendation : BaseDomainModel
    {
        public string UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserAsociateId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("UserAsociateId")]
        public virtual ApplicationUser UserAsociate { get; set; }

        public Guid TypeOfRecommendationId { get; set; }
        public virtual TypeOfRecommendation TypeOfRecommendation { get; set; }

        public Guid EnrollServiceUserId { get; set; }
        public EnrollServiceUser EnrollServiceUser { get; set; }

   
}
