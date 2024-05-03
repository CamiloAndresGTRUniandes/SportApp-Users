namespace SportAppUsers.Application.Unit.Test.Features.Goals.Queries.GetAllGoals ;
using AutoMapper;
using Mocks;
using Moq;
using Shouldly;
using Users.Aplication.Features.Goals.Queries.GetAllGoals;
using Users.Aplication.Mappings;
using Users.Infraestructure.Persistence;

    public class GetAllGoalsHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetAllGoalsHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            MockGoalsRepository.AddDataGoalsRepository(_unitOfWork.Object.UsersDbContext);
        }

        [Fact]
        public async Task GetAllGoalsTest()
        {
            var handler = new GetAllGoalsHandler(_unitOfWork.Object, _mapper);
            var request = new GetAllGoalsQuery();
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<List<GetAllGoalsResult>>();
        }
    }
