namespace SportAppUsers.Application.Unit.Test.Features.Cities.Queries.GetCityByState ;
using AutoMapper;
using Constants;
using Mocks;
using Moq;
using Shouldly;
using Users.Aplication.Features.Cities.Queries.GetCityByState;
using Users.Aplication.Mappings;
using Users.Infraestructure.Persistence;

    public class GetCityByStateHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetCityByStateHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            MockActivitiesRepository.AddDataActivitiesRepository(_unitOfWork.Object.UsersDbContext);
            MockGeographicRepository.AddGeographicRepository(_unitOfWork.Object.UsersDbContext);
        }

        [Fact]
        public async Task GetCityByStateTest()
        {
            var cities = _unitOfWork.Object.UsersDbContext.City.ToList();
            var id = ConstanstIds.stateId;
            var tempCities = cities.Where(p => p.Enabled).ToList();
            if (tempCities.Count > 0)
            {
                id = tempCities[0].StateId;
            }


            var resCities = cities.Where(p => p.Id == ConstanstIds.cityId).ToList();
            var request = new GetCityByStateQuery { StateId = id };
            var handler = new GetCityByStateHandler(_unitOfWork.Object, _mapper);
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<List<GetCityByStateResult>>();
        }
    }
