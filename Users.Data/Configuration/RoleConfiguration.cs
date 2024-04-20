namespace Users.Infraestructure.Configuration ;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "0037fc1b-5414-449c-8f68-ff9d7365f1a0",
                    Name = "Asociado",
                    NormalizedName = "ASOCIADO"
                },
                new IdentityRole
                {
                    Id = "7707e9fa-14cb-4067-a2b0-73437dd87e36",
                    Name = "Usuario",
                    NormalizedName = "USUARIO"
                }
                );
        }
    }
