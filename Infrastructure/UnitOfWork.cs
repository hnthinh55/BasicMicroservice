using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbFactory dbFactory;
        public UnitOfWork(DbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public Task<int> CommitAsync()
        {
            return dbFactory.DbContext.SaveChangesAsync();
        }
    }
}
