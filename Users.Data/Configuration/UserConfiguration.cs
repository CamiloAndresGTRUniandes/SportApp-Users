namespace Users.Infraestructure.Configuration ;
using Dominio;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var man = Guid.NewGuid();
            var women = Guid.NewGuid();

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new Genre
                {
                    Id = man,
                    Name = "Hombre"
                });

            builder.HasData(
                new Genre
                {
                    Id = women,
                    Name = "Mujer"
                }
                );

            builder.HasData(
                new ApplicationUser
                {
                    UserName = "nathanbelt23",
                    Id = "0037fc1b-5414-449c-8f68-ff9d7365f1a0",
                    Email = "nathanbelt23@gmail.com",
                    NormalizedEmail = "nathanbelt23@gmail.com",
                    Name = "Yonathan",
                    LastName = "Beltran",
                    NormalizedUserName = "nathanbelt23",
                    PasswordHash = hasher.HashPassword(null, "1"),
                    EmailConfirmed = true
                    //   GenresId= intHombre
                }
                );
            builder.HasData(
                new ApplicationUser
                {
                    UserName = "nathanbelt14",
                    Id = "7707e9fa-14cb-4067-a2b0-73437dd87e36",
                    Email = "nathanbelt14@outlook.com",
                    NormalizedEmail = "nathanbelt14@outlook.com",
                    Name = "Nathan",
                    LastName = "Belt",
                    NormalizedUserName = "nathanbelt14",
                    PasswordHash = hasher.HashPassword(null, "1"),
                    EmailConfirmed = true
                    // GenresId = intHombre
                }
                );
        }
    }
