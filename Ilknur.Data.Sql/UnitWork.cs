﻿using Ilknur.Core;
using Ilknur.Core.Domain.Abstractions;
using Ilknur.Core.Domain.Dto;
using Ilknur.Core.Loggers;
using Ilknur.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilknur.Data.Sql
{
    public class UnitWork : IUnitWork
    {
        private readonly ICrudOperationLogger _crudLogger;

        public UnitWork(
                            IlknurContext context,
                            ICategoryRepository categoryRepository,
                            IErrorRepository errorRepository,
                            ICrudLoggerRepository crudLoggerRepository,
                            ICrudOperationLogger crudLogger
                        )
        {
            CategoryRepo = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            ErrorRepo = errorRepository ?? throw new ArgumentNullException(nameof(errorRepository));
            CrudLoggerRepo= crudLoggerRepository ?? throw new ArgumentNullException(nameof(crudLoggerRepository));

            _crudLogger = crudLogger ?? throw new ArgumentNullException(nameof(crudLogger));

            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IlknurContext Context { get; }


        public ICategoryRepository CategoryRepo { get; }
        public IErrorRepository ErrorRepo { get; }
        public ICrudLoggerRepository CrudLoggerRepo { get; set; }



        /// <summary>
        /// Insert, Update ve Delete gibi kalıcı değişkliğe neden olan işlemlerin Loglarını belirleyen metodumuz. 
        /// Bu bilgiler LogDto türünden elde edilmektedir.
        /// </summary>
        
        void HandleCrudOperationsLog()
        {
            var entries=Context.ChangeTracker.Entries();
            var logs = new List<LogDto>();
            foreach (var entry in entries)
            {
                LogDto log = new LogDto();
                
                if(entry.State==EntityState.Added||entry.State==EntityState.Modified)
                {
                    //Yapılan değişiklikte Log entity'nin sadece New property'si doludur
                    log.New = JsonConvert.SerializeObject(GetCurrentValues(entry));
                }
                if (entry.State == EntityState.Deleted || entry.State == EntityState.Modified)
                {
                    //Yapılan değişiklikte Log entity'nin New ve Old property'si doludur
                    log.Old = JsonConvert.SerializeObject(GetOldValues(entry));
                }
                log.EntityName = entry.Entity.GetType().Name;
                log.LogDate = DateTime.Now;
                log.Username = "admin";
                logs.Add(log);
            }
            _crudLogger.LogCrudOperation(logs);
        }


        /// <summary>
        /// Herhangi bir entity üzerinde insert veya update işlemleri yapıldığında CreateDate, LastupDate, 
        /// CreateUser ve LastupUser bilgilerini otomatik olarak güncelleyen metodumuz
        /// </summary>

        void UpdateEntityCrudInformation()
        {
            var entries = Context.ChangeTracker.Entries();

            var trackableEntries = entries.Where(entry => entry.Entity is ITrackable);

            foreach (var entry in trackableEntries)
            {
                var entity = entry.Entity as ITrackable;
                if (entry.State == EntityState.Added)
                {                    
                    entity.CreateDate = DateTime.Now;
                    entity.CreateUser = "admin";
                    entity.LastupDate = DateTime.Now;
                    entity.LastupUser = "admin";
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.LastupDate = DateTime.Now;
                    entity.LastupUser = "admin";
                }
            }
        }


        /// <summary>
        /// Herhangi bir entity için onun güncel durumunu getirir.
        /// </summary>
        /// <param name="entry">ChangeTracker üzerinden elde edilen her bir EntityEntry değerini tanımlamaktadır</param>
        /// <returns></returns>

        private object GetCurrentValues(EntityEntry entry)
        {
            return entry.Entity;
        }

        /// <summary>
        /// Herhangi bir entity için onun önceki durumunu getirir.
        /// </summary>
        /// <param name="entry">ChangeTracker üzerinden elde edilen her bir EntityEntry değerini tanımlamaktadır</param>
        /// <returns></returns>

        private object GetOldValues(EntityEntry entry)
        {
            var entityType = entry.Entity.GetType();
            var entity = Activator.CreateInstance(entityType);

            foreach (var prop in entry.Properties)
            {
                var propertyValue = entry.GetDatabaseValues().GetValue<object>(prop.Metadata.Name);
                var entityProperty = entityType.GetProperty(prop.Metadata.Name);
                entityProperty.SetValue(entity, propertyValue);
            }
            return entity;
        }


        public bool Commit()
        {
            int numRows = 0;
            using (var transaction=Context.Database.BeginTransaction())
            {
                try
                {
                    //Crud Operations Log
                    HandleCrudOperationsLog();

                    //Trackable Entity'lerin CreateDate, LastupDate, CreateUser ve LastupUser gibi bilgileri
                    //otomatik olarak ayarlanıyor.
                    UpdateEntityCrudInformation();

                    numRows = Context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Context.ChangeTracker.Clear();
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
                    //Crud Operations Log
                    HandleCrudOperationsLog();

                    //Trackable Entity'lerin CreateDate, LastupDate, CreateUser ve LastupUser gibi bilgileri
                    //otomatik olarak ayarlanıyor.
                    UpdateEntityCrudInformation();

                    numRows = await Context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Context.ChangeTracker.Clear();
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
                    CategoryRepo.Dispose();
                    ErrorRepo.Dispose();
                    CrudLoggerRepo.Dispose();
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
