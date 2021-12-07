using AutoMapper;
using Library.Application.Books.Queries.GetBookList;
using Library.Persistence;
using Library.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Books.Queries
{
    [Collection("QueryCollection")]
    public class GetBookListQueryHandlerTests
    {
        public readonly LibraryDbContext Context;
        public readonly IMapper Mapper;

        public GetBookListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPersonListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetBookListAllQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetBookListAllQuery(), CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BookListVm>();
            result.Books.Count.ShouldBe(1);
        }
    }
}
