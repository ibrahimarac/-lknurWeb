using Ilknur.Core.Domain.Entities;
using Ilknur.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Data.Sql.Repositories
{
    public class ErrorRepository:Repository<Error>,IErrorRepository
    {
        public ErrorRepository(IlknurContext context):base(context)
        {

        }


    }
}
