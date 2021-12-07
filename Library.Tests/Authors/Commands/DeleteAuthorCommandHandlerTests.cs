using Library.Application.Authors.Commands.DeleteAuthor;
using Library.Application.Common.Exceptions;
using Library.Tests.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Authors.Commands
{
    public class DeleteAuthorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteAuthorCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteAuthorCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteAuthorCommand
            {
                Id = LibraryContextFactory.AuthorOne.Id
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Authors.SingleOrDefault(p =>
                p.Id == LibraryContextFactory.AuthorOne.Id));
        }

        [Fact]
        public async Task DeletePersonCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteAuthorCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteAuthorCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
