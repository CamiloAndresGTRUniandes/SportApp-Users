namespace SportAppUsers.Application.Unit.Test.Mocks ;
using AutoFixture;
using Constants;
using Users.Dominio;
using Users.Infraestructure.Persistence;

    public class MockGeographicRepository
    {
        public static void AddGeographicRepository(UsersDbContext usersDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            List<Country> countries = new();

            var country = new Country
            {
                Id = ConstanstIds.countryId,
                Name = "Test-Country-01",
                Enabled = true
            };


            var state = new State
            {
                Id = ConstanstIds.stateId,
                Name = "Test-State-01",
                CountryId = ConstanstIds.countryId,
                Enabled = true
            };


            var city = new City
            {
                Id = ConstanstIds.cityId,
                Name = "Test-City-01",
                StateId = ConstanstIds.stateId,
                Enabled = true
            };


            countries.Add(fixture.Build<Country>()
                .With(tr =>
                    tr.CreatedBy, "Test-Country")
                .With(p => p.Enabled, true)
                .Create()
                );

            countries.Add(country);
            usersDbContextFake.Country!.AddRange(countries);
            usersDbContextFake.State.Add(state);
            usersDbContextFake.City.Add(city);
            usersDbContextFake.SaveChanges();
        }
    }
