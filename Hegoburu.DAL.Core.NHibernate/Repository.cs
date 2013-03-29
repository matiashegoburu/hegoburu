using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using System.Linq;

namespace Hegoburu.DAL.Core.NHibernate
{
	public class Repository<TEntity> : IRepository<TEntity>
	{
		protected readonly ISession _session;

		public Repository (ISession session)
		{
			_session = session;
		}

		#region IRepository implementation
		public TEntity GetById (object id)
		{
			return _session.Get<TEntity> (id);
		}

		public List<TEntity> All ()
		{
			return _session.Query<TEntity> ().ToList ();
		}

		public TEntity Get (Expression<Func<TEntity, bool>> predicate)
		{
			return _session.Query<TEntity> ().SingleOrDefault (predicate);
		}

		public List<TEntity> List (Expression<Func<TEntity, bool>> predicate)
		{
			return _session.Query<TEntity> ().Where (predicate).ToList ();
		}

		public void Save (TEntity entity)
		{
			_session.Save (entity);
		}

		public void Update (TEntity entity)
		{
			_session.Update (entity);
		}

		public void SaveOrUpdate (TEntity entity)
		{
			_session.SaveOrUpdate (entity);
		}

		public void Delete (TEntity entity)
		{
			_session.Delete (entity);
		}

		#endregion
	}
}

