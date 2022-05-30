namespace Smedix.RecruitmentFunnel.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        Task Delete(object id);
        Task Update(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
        void Save();
    }
}
