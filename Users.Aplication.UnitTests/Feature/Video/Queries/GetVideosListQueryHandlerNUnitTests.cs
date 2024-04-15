

using AutoMapper;
using Users.Aplication.Contracts.Persistence;
using Users.Aplication.Features.Videos.Queries.GetVideoList;
using Users.Aplication.Mappings;
using Users.Aplication.UnitTests.Mock;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Users.Aplication.UnitTests.Feature.Video.Queries
{
    public class GetVideosListQueryHandlerNUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public GetVideosListQueryHandlerNUnitTests()
        {
            _unitOfWork= MockUnitWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(
                        c => {
                            c.AddProfile<MappingProfile>();    
                        }
                ); 
            _mapper = mapperConfig.CreateMapper();

        }


        [Test]
        public async Task GetVideoList()
        {

            var handler = new GetVideosListQueryHandler(_unitOfWork.Object, _mapper);
            var result= await handler.Handle(new GetVideosListQuery("yonathan"),CancellationToken.None);

            Assert.That( result.Count, Is.GreaterThanOrEqualTo(0));
            
        }
    }
}
