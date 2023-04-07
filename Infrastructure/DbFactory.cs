using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DbFactory : IDisposable
    {
        private bool disposed;
        private Func<AppDbcontext> insanceFunc;
        private DbContext dbContext;
        public DbContext DbContext => dbContext ?? (dbContext = insanceFunc.Invoke());

        public DbFactory(Func<AppDbcontext> dbContextFacory)
        {
            insanceFunc = dbContextFacory;
        }
        public void Dispose()
        {
            if (!disposed && dbContext != null)
            {
                disposed = true;
                dbContext.Dispose();
            }
        }
    }
}
