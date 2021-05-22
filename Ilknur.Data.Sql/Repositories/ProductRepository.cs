using Ilknur.Core.Domain.Entities;
using Ilknur.Core.Repositories;
using Ilknur.Data.Sql.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ilknur.Data.Sql.Repositories
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(IlknurContext context):base(context)
        {

        }
    }
}
