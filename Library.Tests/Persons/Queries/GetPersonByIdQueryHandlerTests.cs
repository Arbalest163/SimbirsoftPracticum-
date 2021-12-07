using AutoMapper;
using Library.Application.Persons.Queries.GetPersonId;
using Library.Persistence;
using Library.Tests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Persons.Queries
{
    [Collection("QueryCollection")]
    public class GetPersonByIdQueryHandlerTests
    {
        public readonly LibraryDbContext Context;
        public readonly IMapper Mapper;

        public GetPersonByIdQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPersonByIdQueryHandler_Success()
        {
            // Arrange
            var handler = new GetPersonByIdQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetPersonByIdQuery 
                { 
                    Id = LibraryContextFactory.PersonOne.Id
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PersonVm>();
            result.FirstName.ShouldBe(LibraryContextFactory.PersonOne.FirstName);
            result.LastName.ShouldBe(LibraryContextFactory.PersonOne.LastName);
            result.MiddleName.ShouldBe(LibraryContextFactory.PersonOne.MiddleName);
            result.Birthday.ShouldBe(LibraryContextFactory.PersonOne.Birthday);
        }
    }
}
