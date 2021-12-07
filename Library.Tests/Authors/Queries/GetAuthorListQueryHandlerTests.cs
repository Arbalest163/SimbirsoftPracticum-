using AutoMapper;
using Library.Application.Authors.Queries.GetAuthorList;
using Library.Persistence;
using Library.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Authors.Queries
{
    [Collection("QueryCollection")]
    public class GetAuthorListQueryHandlerTests
    {
        public readonly LibraryDbContext Context;
        public readonly IMapper Mapper;

        public GetAuthorListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAuthorListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAuthorListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetAuthorListQuery(), CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AuthorListVm>();
            result.Authors.Count.ShouldBe(1);
        }
    }
}
