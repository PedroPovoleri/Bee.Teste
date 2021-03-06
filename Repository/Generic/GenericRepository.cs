﻿using Context.ctx;
using Microsoft.EntityFrameworkCore;
using Model.Interface;
using Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Generic
{
    public class GenericRepository<T> : IDisposable, IRepository<T> where T : class, IEntity
    {
        protected ApplicationDbContext _session;

        public GenericRepository(DbContextOptions<ApplicationDbContext> options)
        {
            _session = new ApplicationDbContext(options);
        }

        public void Dispose()
        {
            _session.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return GetQueryAll().ToList();
        }

        public T GetById(long id)
        {
            return GetQueryAll().SingleOrDefault(e => e.id == id);
        }

        public void Remove(T entity)
        {
            _session.Entry(entity).State = EntityState.Deleted;
            _session.SaveChanges();
            _session.Dispose();
        }

        public T Save(T entity)
        {
            return Save(entity, false);
        }

        public T Update(T entity)
        {
            return Save(entity, true);
        }

        private T Save(T entity, bool update)
        {
            var saved = false;
            while (!saved)
            {
                try
                {                    
                    _session.Entry(entity).State = update ? EntityState.Modified : EntityState.Added;
                    _session.SaveChanges();
                    _session.Dispose();                   
              
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is T)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];

                                // TODO: decide which value should be written to database
                                // proposedValues[property] = <value to be saved>;
                            }

                            // Refresh original values to bypass next concurrency check
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for "
                                + entry.Metadata.Name);
                        }
                    }
                }
            }


            return entity;

          
        }

        private IQueryable<T> GetQueryAll()
        {
            return _session.Set<T>();
        }

        public async Task<T> AsyncSave(T entity)
        {
            return await AsyncSave(entity, true);
        }

        public async Task<T> AsyncGetById(long id)
        {
            return await GetQueryAll().SingleOrDefaultAsync(e => e.id == id);
        }

        public async void AsyncRemove(T entity)
        {
            _session.Entry(entity).State = EntityState.Deleted;
            await _session.SaveChangesAsync();
            _session.Dispose();
        }

        public async Task<IList<T>> AsyncGetAll(Expression<Func<T, bool>> match)
        {
            return await _session.Set<T>().Where(match).ToListAsync();
        }

        public async Task<T> AsymcUpdate(T entity)
        {
            return await AsyncSave(entity, true);
        }

        private async Task<T> AsyncSave(T entity, bool update)
        {
            _session.Entry(entity).State = update ? EntityState.Modified : EntityState.Added;

            await _session.SaveChangesAsync();
            _session.Dispose();
            return entity;
        }

        Task<T> IRepository<T>.AsyncSave(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.AsyncGetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> AsyncUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.POCO.Customers> WithPaging(int page, int pageSize)
        {
            return _session.Customers.FromSql("SELECT * FROM dbo.Customers Where id between @pageSize AND (@page*@pageSize)", new SqlParameter("page",page), new SqlParameter("pageSize",pageSize)).AsEnumerable<Model.POCO.Customers>();
        }
    }

}
