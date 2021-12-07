using Library.Application.Books.Commands.DeleteBook;
using Library.Application.Common.Exceptions;
using Library.Tests.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Books.Commands
{
    public class DeleteBookCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteBookCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteBookCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteBookCommand
            {
                Id = LibraryContextFactory.BookOne.Id
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Books.SingleOrDefault(b =>
                b.Id == LibraryContextFactory.BookOne.Id));
        }

        [Fact]
        public async Task DeleteBookCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteBookCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteBookCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
