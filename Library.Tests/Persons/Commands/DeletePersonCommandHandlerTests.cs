using Library.Application.Common.Exceptions;
using Library.Application.Persons.Commands.DeletePerson;
using Library.Tests.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Persons.Commands
{
    public class DeletePersonCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeletePersonCommandHandler_Success()
        {
            // Arrange
            var handler = new DeletePersonCommandHandler(Context);

            // Act
            await handler.Handle(new DeletePersonCommand
            {
                Id = LibraryContextFactory.PersonOne.Id
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Persons.SingleOrDefault(p =>
                p.Id == LibraryContextFactory.PersonOne.Id));
        }

        [Fact]
        public async Task DeletePersonCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeletePersonCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeletePersonCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
