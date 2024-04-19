namespace Users.Infraestructure.Configuration ;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasData(
                new Plan
                {
                    Id = new Guid("2c312559-173d-4239-a03d-2fdb3f219fa5"),
                    Name = "Intermediate",
                    Description = "Intermediate  Plan",
                    CreatedBy = "3bfc0e87-e3bb-46b4-9f0a-b0d264fcd6b6",
                    Enabled = true
                },
                new Plan
                {
                    Id = new Guid("672d4087-ac82-42b5-846e-64905d1a09b3"),
                    Name = "Basic",
                    Description = "Basic  Plan",
                    CreatedBy = "3bfc0e87-e3bb-46b4-9f0a-b0d264fcd6b6",
                    Enabled = true
                }
                ,
                new Plan
                {
                    Id = new Guid("7ee7db76-77c2-4353-a509-ebe4fbe4aed4"),
                    Name = "Premium",
                    Description = "Premium  Plan",
                    CreatedBy = "3bfc0e87-e3bb-46b4-9f0a-b0d264fcd6b6",
                    Enabled = true
                }
                );
        }
    }
