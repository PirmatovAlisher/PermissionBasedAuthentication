using System.Linq.Expressions;

namespace PermissionBasedAuthentication.Services
{
	public interface IGenericService<TEntity> where TEntity : class
	{
		IList<TEntity> GetAllItems(params Expression<Func<TEntity, object>>[] includeProperties);

		void CreateEntity(TEntity entity);
		void UpdateEntity(TEntity entity);
		void DeleteEntity(int id);

		TEntity GetEntityById(int id);
	}
}
