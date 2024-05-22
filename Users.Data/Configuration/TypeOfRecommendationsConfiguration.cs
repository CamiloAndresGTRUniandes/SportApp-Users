namespace Users.Infraestructure.Configuration ;
using Constans;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TypeOfRecommendationsConfiguration : IEntityTypeConfiguration<TypeOfRecommendation>
    {
        public void Configure(EntityTypeBuilder<TypeOfRecommendation> builder)
        {
            builder.HasData(
                new TypeOfRecommendation { Id = TypeOfRecommendationContants.RecomendationId, Name = "Recomendacion", CreatedBy = "System" },
                new TypeOfRecommendation { Id = TypeOfRecommendationContants.NutritionalId, Name = "Nutricional", CreatedBy = "System" },
                new TypeOfRecommendation
                {
                    Id = TypeOfRecommendationContants.ExerciseTrackingId,
                    Name = "Seguimiento de ejercicio",
                    CreatedBy = "System"
                }
                );
        }
    }
