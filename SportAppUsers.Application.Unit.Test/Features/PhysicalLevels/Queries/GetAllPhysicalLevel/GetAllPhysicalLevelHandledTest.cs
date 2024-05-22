namespace SportAppUsers.Application.Unit.Test.Features.PhysicalLevels.Queries.GetAllPhysicalLevel ;
using AutoMapper;
using Mocks;
using Moq;
using Shouldly;
using Users.Aplication.Features.PhysicalLevels.Queries.GetAllPhysicalLeve;
using Users.Aplication.Mappings;
using Users.Infraestructure.Persistence;

    public class GetAllPhysicalLevelHandledTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;


        public GetAllPhysicalLevelHandledTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            MockPhysicalLevelRepository.AddDataPhysicalLevelRepository(_unitOfWork.Object.UsersDbContext);
        }

        [Fact]
        public async Task GetAllPhysicalLevelAllergiesTest()
        {
            var handler = new GetAllPhysicalHandler(_unitOfWork.Object, _mapper);
            var request = new GetAllPhysicalQuery();
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<List<GetAllPhysicalResult>>();
        }
    }
