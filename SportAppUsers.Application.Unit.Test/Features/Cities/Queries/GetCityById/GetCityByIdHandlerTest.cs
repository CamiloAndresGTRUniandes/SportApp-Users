namespace SportAppUsers.Application.Unit.Test.Features.Cities.Queries.GetCityById ;
using AutoMapper;
using Constants;
using Mocks;
using Moq;
using Shouldly;
using Users.Aplication.Features.Cities.Queries.GetCityById;
using Users.Aplication.Mappings;
using Users.Infraestructure.Persistence;

    public class GetCityByIdHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;


        public GetCityByIdHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            MockActivitiesRepository.AddDataActivitiesRepository(_unitOfWork.Object.UsersDbContext);
            MockGeographicRepository.AddGeographicRepository(_unitOfWork.Object.UsersDbContext);
        }

        [Fact]
        public async Task GetCityByIdTest()
        {
            var handler = new GetCityByIdHandler(_unitOfWork.Object, _mapper);
            var request = new GetCityByIdQuery { CityId = ConstanstIds.cityId };
            var countries = _unitOfWork.Object.UsersDbContext.Country.ToList();
            var states = _unitOfWork.Object.UsersDbContext.City.ToList();
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<List<GetCityByIdResult>>();
        }
    }
