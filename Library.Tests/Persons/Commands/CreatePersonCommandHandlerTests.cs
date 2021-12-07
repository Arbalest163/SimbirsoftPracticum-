using AutoFixture;
using Library.Application.Persons.Commands.CreatePerson;
using Library.Domain;
using Library.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Persons.Commands
{
    public class CreatePersonCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreatePersonCommandHandler_Success()
        {
            // Arrange
            var handler = new CreatePersonCommandHandler(Context);
            var personValid = new Fixture().Create<CreatePersonCommand>();

            // Act
            var personId = await handler.Handle(personValid, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Persons.SingleOrDefaultAsync(p =>
                    p.Id == personId &&
                    p.FirstName == personValid.FirstName &&
                    p.LastName == personValid.LastName &&
                    p.MiddleName == personValid.MiddleName &&
                    p.Birthday == personValid.Birthday));
        }
    }
}
