using AutoMapper;
using Library.Application.Persons.Queries.GetPersonList;
using Library.Persistence;
using Library.Tests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace Library.Tests.Persons.Queries
{
    [Collection("QueryCollection")]
    public class GetPersonListQueryHandlerTests
    {
        public readonly LibraryDbContext Context;
        public readonly IMapper Mapper;

        public GetPersonListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPersonListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetPersonListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetPersonListQuery(), CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonListVm>();
            result.Persons.Count.ShouldBe(1);
        }
    }
}
