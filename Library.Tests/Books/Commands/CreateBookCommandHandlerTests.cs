using AutoFixture;
using Library.Application.Books.Commands.CreateBook;
using Library.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Books.Commands
{
    public class CreateBookCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateBookCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateBookCommandHandler(Context);
            var bookValid =  new Fixture().Create<CreateBookCommand>();

        // Act
        var bookId = await handler.Handle(bookValid, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Books.SingleOrDefaultAsync(b =>
                    b.Id == bookId &&
                    b.Title == bookValid.Title &&
                    b.AuthorId == bookValid.AuthorId));
        }
    }
}
