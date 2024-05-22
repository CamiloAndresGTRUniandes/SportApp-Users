namespace Users.Infraestructure.Configuration ;

using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class IntensityConfiguration : IEntityTypeConfiguration<Intensity>
    {
        public void Configure(EntityTypeBuilder<Intensity> builder)
        {
            var idBaja = new Guid("f0fa1aca-0936-4de6-90c0-96add874e03e");
            var idMedia = new Guid("033e6b36-38a2-4457-b5ba-0b113a5fafed");
            var idAlta = new Guid("267939ec-5810-4913-bfc3-f02edd79c144");

            builder.HasData(
                new Intensity
                {
                    Id = idBaja,
                    Name = "Baja"
                },
                new Intensity
                {
                    Id = idMedia,
                    Name = "Media"
                },
                new Intensity
                {
                    Id = idAlta,
                    Name = "Alta"
                }
                );
        }
    }
