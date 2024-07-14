using Microsoft.EntityFrameworkCore;
using PermissionBasedAuthentication.Context;

namespace PermissionBasedAuthentication.GenericRepositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private readonly CustomContext _customContext;
		private readonly DbSet<TEntity> _entity;

		public GenericRepository(CustomContext customContext)
		{
			_customContext = customContext;
			_entity = _customContext.Set<TEntity>();
		}

		public void CreateItem(TEntity entity)
		{
			_entity.Add(entity);
			_customContext.SaveChanges();
		}

		public void DeleteItem(TEntity entity)
		{
			_entity.Remove(entity);
			_customContext.SaveChanges();
		}

		public IQueryable<TEntity> GetAll()
		{
			var items = _entity.AsQueryable().AsNoTracking();
			return items;
		}

		public TEntity GetItemById(int id)
		{
			var item = _entity.Find(id);
			return item;
		}

		public void UpdateItem(TEntity entity)
		{
			_entity.Update(entity);
			_customContext.SaveChanges();
		}
	}
}
