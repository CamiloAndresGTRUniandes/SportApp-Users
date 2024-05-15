namespace SportAppUsers.Application.Unit.Test.Features.NutritionalAllergies.Queries ;
using AutoMapper;
using Mocks;
using Moq;
using Shouldly;
using Users.Aplication.Features.NutritionalAllergies.Queries.GetAllNutionalAllergies;
using Users.Aplication.Mappings;
using Users.Infraestructure.Persistence;

    public class GetAllNutionalAllergiesHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetAllNutionalAllergiesHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            MockNutritionalAllergiesRepository.AddDataNutritionalAllergiesRepository(_unitOfWork.Object.UsersDbContext);
        }

        [Fact]
        public async Task GetAllNutionalAllergiesTest()
        {
            var handler = new GetAllNutionalAllergiesHandler(_unitOfWork.Object, _mapper);
            var request = new GetAllNutionalAllergiesQuery();
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<List<GetAllNutionalAllergiesResult>>();
        }
    }
