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

        IErrorRepository Errors { get; }

        bool Commit();
        Task<bool> CommitAsync();
    }

}
