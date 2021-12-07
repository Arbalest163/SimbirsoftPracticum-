using AutoFixture;
using Library.Application.Genres.Commands.CreateGenre;
using Library.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Genres.Commands
{
    public class CreateGenreCommandHnadlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateGenreCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateGenreCommandHandler(Context);
            var genreValid = new Fixture().Create<CreateGenreCommand>();

            // Act
            var genreId = await handler.Handle(genreValid, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Genres.SingleOrDefaultAsync(g =>
                    g.Id == genreId &&
                    g.Name == genreValid.Name));
        }
    }
}
