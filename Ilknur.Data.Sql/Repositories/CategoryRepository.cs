using Ilknur.Core.Domain.Entities;
using Ilknur.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ilknur.Data.Sql.Repositories
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(IlknurContext context):base(context)
        {

        }

    }
}
