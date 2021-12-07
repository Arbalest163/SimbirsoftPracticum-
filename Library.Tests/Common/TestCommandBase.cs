using Library.Persistence;
using System;

namespace Library.Tests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly LibraryDbContext Context;

        public TestCommandBase()
        {
            Context = LibraryContextFactory.Create();
        }

        public void Dispose()
        {
            LibraryContextFactory.Destroy(Context);
        }
    }
}
