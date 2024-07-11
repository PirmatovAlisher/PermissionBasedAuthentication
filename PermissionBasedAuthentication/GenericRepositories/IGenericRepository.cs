namespace PermissionBasedAuthentication.GenericRepositories
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> GetAll();

		void CreateItem(TEntity entity);
		void UpdateItem(TEntity entity);
		void DeleteItem(TEntity entity);

		TEntity GetItemById(int id);
	}
}
