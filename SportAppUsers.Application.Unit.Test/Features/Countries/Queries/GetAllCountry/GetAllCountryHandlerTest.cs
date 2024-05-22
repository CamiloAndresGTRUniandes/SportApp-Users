namespace SportAppUsers.Application.Unit.Test.Features.Countries.Queries.GetAllCountry ;
using AutoMapper;
using Mocks;
using Moq;
using Shouldly;
using Users.Aplication.Features.Countries.Queries.GetAllCountry;
using Users.Aplication.Mappings;
using Users.Infraestructure.Persistence;

    public class GetAllCountryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetAllCountryHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            MockActivitiesRepository.AddDataActivitiesRepository(_unitOfWork.Object.UsersDbContext);
            MockGeographicRepository.AddGeographicRepository(_unitOfWork.Object.UsersDbContext);
        }


        [Fact]
        public async Task GetAllCountryTest()
        {
            var countries = _unitOfWork.Object.UsersDbContext.Country.ToList();
            var tempCountries = countries.Where(p => p.Enabled).ToList();


            var request = new GetAllCountryQuery();
            var handler = new GetAllCountryHandler(_unitOfWork.Object, _mapper);
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<List<GetAllCountryResult>>();
        }
    }
