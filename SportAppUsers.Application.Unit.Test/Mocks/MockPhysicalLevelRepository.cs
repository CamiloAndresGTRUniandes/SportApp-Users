namespace SportAppUsers.Application.Unit.Test.Mocks ;
using AutoFixture;
using Users.Dominio;
using Users.Infraestructure.Persistence;

    public class MockPhysicalLevelRepository
    {
        public static void AddDataPhysicalLevelRepository(UsersDbContext usersDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var data = fixture.CreateMany<PhysicalLevel>().ToList();


            data.Add(fixture.Build<PhysicalLevel>()
                .With(tr => tr.Enabled, true)
                .Create()
                );
            usersDbContextFake.PhysicalLevel.AddRange(data);
            usersDbContextFake.SaveChanges();
        }
    }
