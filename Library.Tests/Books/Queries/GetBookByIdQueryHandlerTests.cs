using AutoMapper;
using Library.Application.Books.Queries.GetBookById;
using Library.Persistence;
using Library.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Books.Queries
{
    [Collection("QueryCollection")]
    public class GetBookByIdQueryHandlerTests
    {
        public readonly LibraryDbContext Context;
        public readonly IMapper Mapper;

        public GetBookByIdQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBookByIdQueryHandler_Success()
        {
            // Arrange
            var handler = new GetBookByIdQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetBookByIdQuery
                {
                    Id = LibraryContextFactory.BookOne.Id
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BookVm>();
            result.Title.ShouldBe(LibraryContextFactory.BookOne.Title);
            result.AuthorId.ShouldBe(LibraryContextFactory.BookOne.AuthorId);
        }
    }
}
