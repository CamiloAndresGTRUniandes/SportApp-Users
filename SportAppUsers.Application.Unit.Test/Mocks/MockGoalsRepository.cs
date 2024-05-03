namespace SportAppUsers.Application.Unit.Test.Mocks ;
using AutoFixture;
using Users.Dominio;
using Users.Infraestructure.Persistence;

    public class MockGoalsRepository
    {
        public static void AddDataGoalsRepository(UsersDbContext usersDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var goals = fixture.CreateMany<Goal>().ToList();
            goals.Add(fixture.Build<Goal>()
                .With(tr => tr.Enabled, true)
                .Create()
                );
            usersDbContextFake.Goal.AddRange(goals);
            usersDbContextFake.SaveChanges();
        }
    }
