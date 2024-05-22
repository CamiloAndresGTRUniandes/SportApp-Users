namespace Users.Dominio ;
using Common;

    public class TypeOfRecommendation : BaseDomainModel
    {
        public TypeOfRecommendation()
        {
            UserRecommendations = new HashSet<UserRecommendation>();
        }

        public string Name { get; set; } = string.Empty;
        public ICollection<UserRecommendation> UserRecommendations { get; set; }
    }
