namespace Users.Infraestructure.Configuration ;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
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
