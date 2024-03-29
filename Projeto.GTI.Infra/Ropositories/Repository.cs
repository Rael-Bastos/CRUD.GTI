﻿using Microsoft.EntityFrameworkCore;
using Projeto.GTI.Infra.Context;
using Projeto.GTI.Infra.Ropositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.GTI.Infra.Ropositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly GTIContext _dbContext;

        public Repository(GTIContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where) => await _dbContext.Set<TEntity>().Where(where).ToListAsync();

        public async Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>() as IQueryable<TEntity>;
            //query = query.EagerLoad(includes);

            return await query.Where(where).ToListAsync();
        }

        public async Task<int> Count() => await _dbContext.Set<TEntity>().CountAsync();

        public async Task<bool> Existe(Expression<Func<TEntity, bool>> where)
        {
            return await _dbContext.Set<TEntity>().Where(where).AnyAsync();
        }

        public async Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> orderBy, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>() as IQueryable<TEntity>;
            // query = query.EagerLoad(includes);

            return await query.Where(where).OrderBy(orderBy).ToListAsync();
        }

        public async Task<IList<TEntity>> GetAll() => await _dbContext.Set<TEntity>().ToListAsync();

        public async virtual Task<IList<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return await (includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(), (query, path) => query.Include(path))).ToListAsync();

        }

        public async Task<TEntity> GetById(int id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public virtual TEntity GetById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            return includes.Aggregate(_dbContext.Set<TEntity>().Where(where), (query, path) => query.Include(path)).FirstOrDefault();
        }
        public void Save(TEntity entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void SaveMany(IEnumerable<TEntity> entity) => _dbContext.AddRange(entity);

        public void Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteMany(IEnumerable<TEntity> entity) => _dbContext.RemoveRange(entity);

        public void AlterarAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
