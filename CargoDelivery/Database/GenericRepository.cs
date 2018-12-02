﻿using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;

using CargoDelivery.Database.Interfaces;

namespace CargoDelivery.Database
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		internal readonly DbContext Context;
		internal readonly DbSet<TEntity> DbSet;

		public GenericRepository(DbContext context)
		{
			Context = context;
			DbSet = context.Set<TEntity>();
		}

		public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			IQueryable<TEntity> query = DbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}

			query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
				.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

			return orderBy?.Invoke(query).ToList() ?? query.ToList();
		}

		public virtual TEntity GetById(object id)
		{
			return DbSet.Find(id);
		}

		public virtual void Insert(TEntity entity)
		{
			DbSet.Add(entity);
		}

		public virtual void Delete(object id)
		{
			var entityToDelete = DbSet.Find(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (Context.Entry(entityToDelete).State == EntityState.Detached)
			{
				DbSet.Attach(entityToDelete);
			}

			DbSet.Remove(entityToDelete);
		}

		public virtual void Update(TEntity entityToUpdate)
		{
			DbSet.Attach(entityToUpdate);
			Context.Entry(entityToUpdate).State = EntityState.Modified;
		}
	}
}