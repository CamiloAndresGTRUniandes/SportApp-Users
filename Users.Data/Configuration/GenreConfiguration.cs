namespace Users.Infraestructure.Configuration ;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GenreConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Hombre"
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Mujer"
                }
                );
        }
    }
