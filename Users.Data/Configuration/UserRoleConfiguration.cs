using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Users.Infraestructure.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(

                        new IdentityUserRole<string>
                        {
                            RoleId = "0037fc1b-5414-449c-8f68-ff9d7365f1a0",
                            UserId = "0037fc1b-5414-449c-8f68-ff9d7365f1a0",
                        },
                        new IdentityUserRole<string>
                        {
                            RoleId = "7707e9fa-14cb-4067-a2b0-73437dd87e36",
                            UserId = "7707e9fa-14cb-4067-a2b0-73437dd87e36",
                        }


                );

        }
    }
}
