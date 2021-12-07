using AutoMapper;
using Library.Application.Genres.Queries.GetGenryList;
using Library.Persistence;
using Library.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Genres.Queries
{
    [Collection("QueryCollection")]
    public class GetGenreListQueryHandlerTests
    {
        public readonly LibraryDbContext Context;
        public readonly IMapper Mapper;

        public GetGenreListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetGenreListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetGenreListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetGenreListQuery(), CancellationToken.None);

            // Assert
            result.ShouldBeOfType<GenreListVm>();
            result.Genres.Count.ShouldBe(1);
        }
    }
}
