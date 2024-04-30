namespace SportAppUsers.Application.Unit.Test.Mocks ;
using Microsoft.EntityFrameworkCore;
using Moq;
using Users.Infraestructure.Persistence;

    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<UsersDbContext>()
                .UseInMemoryDatabase($"UsersDBContextTest-{dbContextId}")
                .Options;
            var usersDBContextFake = new UsersDbContext(options);
            usersDBContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(usersDBContextFake);

            return mockUnitOfWork;
        }
    }
