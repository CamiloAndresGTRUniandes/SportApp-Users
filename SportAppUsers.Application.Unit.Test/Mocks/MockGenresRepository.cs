namespace SportAppUsers.Application.Unit.Test.Mocks ;
using AutoFixture;
using Users.Dominio;
using Users.Infraestructure.Persistence;

    public class MockGenresRepository
    {
        public static void AddDataGoalsRepository(UsersDbContext usersDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var genres = fixture.CreateMany<Genre>().ToList();
            genres.Add(fixture.Build<Genre>()
                .With(tr => tr.Enabled, true)
                .Create()
                );
            usersDbContextFake.Genre.AddRange(genres);
            usersDbContextFake.SaveChanges();
        }
    }
