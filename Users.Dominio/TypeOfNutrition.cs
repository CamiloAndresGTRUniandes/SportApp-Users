namespace Users.Dominio ;
using Common;

    public class TypeOfNutrition : BaseDomainModel
    {
        public TypeOfNutrition()
        {
            NutrionalProfile = new HashSet<NutrionalProfile>();
        }

        public string Name { get; set; } = string.Empty;
        public ICollection<NutrionalProfile> NutrionalProfile { get; set; }
    }
