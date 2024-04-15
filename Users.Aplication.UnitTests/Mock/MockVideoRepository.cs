

using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using Users.Dominio;
using Users.Infraestructure.Persistence;

namespace Users.Aplication.UnitTests.Mock
{
    public static class MockVideoRepository
    {

        public static Mock<VideoRepository> GetVideoRepository()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var videos = fixture.CreateMany<Video>().ToList();
            // videos.Add(new Video { Nombre = "yonathan", CreatedBy = "yonathan", CreatedDate = System.DateTime.Now });
            videos.Add(
                    fixture.Build<Video>().With(tr=> tr.Created_By,"yonathan").Create()
                );
            var options = new DbContextOptionsBuilder<UsersDbContext>()
                .UseInMemoryDatabase(databaseName:$"StreamerDbContext-{Guid.NewGuid()}").Options
                ;

            var streamerDbContextFake = new UsersDbContext(options);
            streamerDbContextFake.Videos!.AddRange(videos);
            streamerDbContextFake.SaveChanges();

            var mockRepository= new Mock<VideoRepository>(streamerDbContextFake);
          //  mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(videos);
            return mockRepository;        
        }

    }
}
