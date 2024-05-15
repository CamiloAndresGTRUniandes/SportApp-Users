namespace SportAppUsers.Application.Unit.Test.Mocks ;
using Constants;
using Users.Dominio;
using Users.Infraestructure.Persistence;

    internal class MockUserRepository
    {
        public static void AddUserRepository(UsersDbContext usersDbContextFake)
        {
            usersDbContextFake.Users.Add(new ApplicationUser
            {
                Id = ConstanstIds.userId,
                CityId = ConstanstIds.cityId,
                GenreId = ConstanstIds.genreId
            });
        }
    }
