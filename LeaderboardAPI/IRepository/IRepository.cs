namespace LeaderboardAPI.IRepository
{

    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task<IList<T>> GetAllAsync();

        Task<T> GetAsync(int Id);

        Task<bool> IsExistAsync(int Id);

    }

    public interface IUpdatebaleRepository<T> where T : class
    {
        Task<bool> UpdateAsync(T entity);
    }


    public interface IDeletebleRepository
    {
        Task<bool> DeleteAsync(int Id);
    }

}