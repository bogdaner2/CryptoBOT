﻿using AutoMapper;
using CryptoTrackerAPI.DAL.Data;
using CryptoTrackerAPI.DAL.Entities;
using CryptoTrackerAPI.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CryptoTrackerAPI.DAL.Repositories
{
    public class GenericRepository<TEntity>:IRepository<TEntity> where TEntity:Entity
    {
        protected readonly CryptoTrackerDbContext Context;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IMapper mapper;

        public GenericRepository(CryptoTrackerDbContext context, IMapper automapper)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
            mapper = automapper;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entityToDelete = await DbSet.FindAsync(id);
            if (entityToDelete == null)
            {
                throw new Exception($"Entity with id: {id} not found when trying to update entity. Entity was no Deleted.");
            }

            return Delete(entityToDelete);
        }

        public bool Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }

            try
            {
                DbSet.Remove(entityToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().CountAsync(predicate);
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(
                                   Expression<Func<TEntity, bool>> predicate = null,
                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = DbSet;
            query = query.AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var findEntity = await DbSet.FindAsync(entity.Id);

            if (findEntity == null)
            {
                throw new Exception($"Entity {entity.GetType().Name} with id: {entity.Id} not found");
            }

            return mapper.Map(entity, findEntity);
        }

        public Task<List<TEntity>> GetAllEntities(
                                   Func<IQueryable<TEntity>, 
                                   IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (include != null)
            {
                query = include(query);
            }

            return query.ToListAsync();
        }
    }
}
