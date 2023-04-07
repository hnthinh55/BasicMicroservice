using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain
{
    public interface IDbFactory<TContext> where TContext : DbContext
    {
        TContext Context { get; }
    }
}
