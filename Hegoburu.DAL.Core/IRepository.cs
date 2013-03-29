using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hegoburu.DAL.Core
{
	public interface IRepository<TEntity>
	{
		TEntity GetById (object id);
		List<TEntity> All ();
		TEntity Get (Expression<Func<TEntity, bool>> predicate);
		List<TEntity> List (Expression<Func<TEntity, bool>> predicate);
		void Save (TEntity entity);
		void Update (TEntity entity);
		void SaveOrUpdate (TEntity entity);
		void Delete (TEntity entity);
	}
}

