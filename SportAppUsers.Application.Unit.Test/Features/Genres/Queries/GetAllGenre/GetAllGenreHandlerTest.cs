namespace SportAppUsers.Application.Unit.Test.Features.Genres.Queries.GetAllGenre ;
using AutoMapper;
using Mocks;
using Moq;
using Shouldly;
using Users.Aplication.Features.Genres.Queries.GetAllGenre;
using Users.Aplication.Mappings;
using Users.Infraestructure.Persistence;

    public class GetAllGenreHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetAllGenreHandlerTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
            MockGenresRepository.AddDataGenreRepository(_unitOfWork.Object.UsersDbContext);
        }

        [Fact]
        public async Task GetAllGenreTest()
        {
            var handler = new GetAllGenresHandler(_unitOfWork.Object, _mapper);
            var request = new GetAllGenresQuery();
            var countries = _unitOfWork.Object.UsersDbContext.Country.ToList();
            var states = _unitOfWork.Object.UsersDbContext.City.ToList();
            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<List<GetAllGenresResult>>();
        }
    }
