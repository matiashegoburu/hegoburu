using System;

namespace Hegoburu.DAL.Core
{
	public interface IRepository<TEntity>
	{
		TEntity GetById (object id);
		List<TEntity> All ();
		TEntity Get (Expression<Func<TEntity, bool>> predicate);
		List<TEntity> Where (Expression<Func<TEntity, bool>> predicate);
		void Save (TEntity entity);
		void Update (TEntity entity);
		void SaveOrUpdate (TEntity entity);
		void Delete (TEntity entity);
		void Delete (object id);
	}
}

