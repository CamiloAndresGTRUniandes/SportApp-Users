namespace SportAppUsers.Application.Unit.Test.Mocks ;
using AutoFixture;
using Users.Dominio;
using Users.Infraestructure.Persistence;

    public class MockActivitiesRepository
    {
        public static void AddDataActivitiesRepository(UsersDbContext usersDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var activities = fixture.CreateMany<Activity>().ToList();


            activities.Add(fixture.Build<Activity>()
                .With(tr => tr.Enabled, true)
                .Create()
                );

            usersDbContextFake.Activity.AddRange(activities);

            usersDbContextFake.SaveChanges();
        }
    }
