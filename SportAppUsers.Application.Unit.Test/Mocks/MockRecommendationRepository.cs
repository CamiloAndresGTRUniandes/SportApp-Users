namespace SportAppUsers.Application.Unit.Test.Mocks ;
using AutoFixture;
using Users.Infraestructure.Persistence;

    public class MockRecommendationRepository
    {
        public static void AddDataRecommendationRepository(UsersDbContext usersDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            /*
            data.Add(fixture.Build<NutricionalAllergy>()
                .With(tr => tr.Enabled, true)
                .Create()
                );
            data.Add()

            usersDbContextFake.NutricionalAllergy.AddRange(data);
            usersDbContextFake.SaveChanges();

            */
        }
    }
