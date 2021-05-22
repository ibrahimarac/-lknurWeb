using Ilknur.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ilknur.Core
{
    public interface IUnitWork:IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }

        bool Commit();
        Task<bool> CommitAsync();
    }

    public interface IUnitWork<TContext> : IUnitWork where TContext : DbContext
    {
        TContext Context { get; }
    }

}
