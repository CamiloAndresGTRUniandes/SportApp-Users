namespace SportAppUsers.Application.Unit.Test.Mocks ;
using AutoFixture;
using Users.Dominio;
using Users.Infraestructure.Persistence;

    public class MockNutritionalAllergiesRepository
    {
        public static void AddDataNutritionalAllergiesRepository(UsersDbContext usersDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var activities = fixture.CreateMany<NutricionalAllergy>().ToList();


            activities.Add(fixture.Build<NutricionalAllergy>()
                .With(tr => tr.Enabled, true)
                .Create()
                );

            usersDbContextFake.NutricionalAllergy.AddRange(activities);
            usersDbContextFake.SaveChanges();
        }
    }
