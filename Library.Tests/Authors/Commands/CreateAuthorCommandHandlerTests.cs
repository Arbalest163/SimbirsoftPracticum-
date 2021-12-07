using AutoFixture;
using Library.Application.Authors.Commands.CreateAuthor;
using Library.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Authors.Commands
{
    public class CreateAuthorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateAuthorCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateAuthorCommandHandler(Context);
            var authorValid = new Fixture().Create<CreateAuthorCommand>();

            // Act
            var authorId = await handler.Handle(authorValid, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Authors.SingleOrDefaultAsync(p =>
                    p.Id == authorId &&
                    p.FirstName == authorValid.FirstName &&
                    p.LastName == authorValid.LastName &&
                    p.MiddleName == authorValid.MiddleName));
        }
    }
}
