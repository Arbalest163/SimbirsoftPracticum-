using AutoMapper;
using Library.Application.Genres.Queries.GetGenreId;
using Library.Persistence;
using Library.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Genres.Queries
{
    [Collection("QueryCollection")]
    public class GetGenreByIdQueryHandlerTests
    {
        public readonly LibraryDbContext Context;
        public readonly IMapper Mapper;

        public GetGenreByIdQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetGenreByIdQueryHandler_Success()
        {
            // Arrange
            var handler = new GetGenreIdQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetGenreIdQuery
                {
                    Id = LibraryContextFactory.GenreOne.Id
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<GenreVm>();
            result.Id.ShouldBe(LibraryContextFactory.GenreOne.Id);
        }
    }
}
