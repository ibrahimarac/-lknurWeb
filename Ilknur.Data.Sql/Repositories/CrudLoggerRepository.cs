using Ilknur.Core.Domain.Entities;
using Ilknur.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Data.Sql.Repositories
{
    public class CrudLoggerRepository:Repository<Log>, ICrudLoggerRepository
    {
        public CrudLoggerRepository(IlknurContext context):base(context)
        {
            
        }

    }
}
