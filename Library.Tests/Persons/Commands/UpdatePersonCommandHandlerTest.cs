using Library.Application.Persons.Commands.UpdatePerson;
using Library.Tests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Library.Application.Common.Exceptions;
using AutoFixture;

namespace Library.Tests.Persons.Commands
{
    public class UpdatePersonCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task UpdatePersonCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdatePersonCommandHandler(Context);
            var personUpdate = new Fixture().Create<UpdatePersonCommand>();
            personUpdate.Id = LibraryContextFactory.PersonOne.Id;

            // Act
            await handler.Handle(personUpdate, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Persons.SingleOrDefaultAsync(p =>
                    p.Id == LibraryContextFactory.PersonOne.Id &&
                    p.FirstName == personUpdate.FirstName &&
                    p.LastName == personUpdate.LastName &&
                    p.MiddleName == personUpdate.MiddleName &&
                    p.Birthday == personUpdate.Birthday));
        }

        [Fact]
        public async Task UpdatePersonCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdatePersonCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdatePersonCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
