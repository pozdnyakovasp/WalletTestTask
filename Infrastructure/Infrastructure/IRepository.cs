namespace Infrastructure.Infrastructure
{
    public interface IReposotory
    { }

    public interface IRepository<TEntity> : IReposotory where TEntity : IAggregateRoot
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetBy(int key);
    }
}
