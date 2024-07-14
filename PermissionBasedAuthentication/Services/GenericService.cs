
using Microsoft.EntityFrameworkCore;
using PermissionBasedAuthentication.GenericRepositories;
using System.Linq.Expressions;

namespace PermissionBasedAuthentication.Services
{
	public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
	{
		protected readonly IGenericRepository<TEntity> _repository;

		public GenericService(IGenericRepository<TEntity> repository)
		{
			_repository = repository;
		}

		public void CreateEntity(TEntity entity)
		{
			_repository.CreateItem(entity);
		}

		public void DeleteEntity(int id)
		{
			var entity = _repository.GetItemById(id);
			_repository.DeleteItem(entity);
		}

		public IList<TEntity> GetAllItems(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			var entities = _repository.GetAll();
			if (includeProperties is not null)
			{
				foreach (var property in includeProperties)
				{
					entities = entities.Include(property);
				}
			}

			return entities.ToList();
		}

		public TEntity GetEntityById(int id)
		{
			return _repository.GetItemById(id);
		}

		public void UpdateEntity(TEntity entity)
		{
			_repository.UpdateItem(entity);
		}
	}
}
