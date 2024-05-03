namespace SportAppUsers.Application.Unit.Test.Features.Activities.Queries.GetAllActivities ;
using AutoMapper;
using Mocks;
using Moq;
using Shouldly;
using Users.Aplication.Features.Activities.Queries.GetAllActivities;
using Users.Aplication.Mappings;
using Users.Infraestructure.Persistence;

    public class GetAllActivitiesHandlerXUniTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetAllActivitiesHandlerXUniTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();

            MockActivitiesRepository.AddDataActivitiesRepository(_unitOfWork.Object.UsersDbContext);
        }

        [Fact]
        public async Task GetActivityListTest()
        {
            var handler = new GetAllActivitiesHandler(_unitOfWork.Object, _mapper);
            var request = new GetAllActivitiesQuery();
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<List<GetAllActivitiesResult>>();
        }
    }
