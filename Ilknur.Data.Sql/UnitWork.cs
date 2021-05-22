using Ilknur.Core;
using Ilknur.Core.Repositories;
using Ilknur.Data.Sql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ilknur.Data.Sql
{
    public class UnitWork : IUnitWork<IlknurContext>
    {
        public UnitWork(
                            IlknurContext context,
                            ICategoryRepository categoryRepository,
                            IProductRepository productRepository
                        )
        {
            Categories = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            Products = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IlknurContext Context { get; }


        public ICategoryRepository Categories { get; }


        public IProductRepository Products { get; }




        public bool Commit()
        {
            int numRows = 0;
            using (var transaction=Context.Database.BeginTransaction())
            {
                try
                {
                    numRows = Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return numRows != 0;
        }


        public async Task<bool> CommitAsync()
        {
            int numRows = 0;
            using (var transaction = await Context.Database.BeginTransactionAsync())
            {
                try
                {
                    numRows = await Context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
            return numRows != 0;
        }



        bool disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if(disposing)
                {
                    Categories.Dispose();
                    Products.Dispose();
                    Context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
