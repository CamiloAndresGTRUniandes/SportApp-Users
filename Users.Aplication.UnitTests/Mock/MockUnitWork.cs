
using Moq;
using Users.Aplication.Contracts.Persistence;

namespace Users.Aplication.UnitTests.Mock
{

    public class MockUnitWork
    {


        public static Mock<IUnitOfWork> GetUnitOfWork()
        { 
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockVideoRepository = MockVideoRepository.GetVideoRepository();
            mockUnitOfWork.Setup(r=> r.VideoRepository).Returns(mockVideoRepository.Object);
            return mockUnitOfWork;
        }

    }
}
