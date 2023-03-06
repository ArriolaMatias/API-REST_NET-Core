using Entities;

namespace DataAccess.Repository
{
    public interface IRepository<T>
    {
        public Task<csResponse> Create(T _object);
        public Task<csResponse> Read();
        public Task<csResponse> Update(int id, T _object);
        public Task<csResponse> Delete(T _object);
        public Task<csResponse> GetById(int id);
    }
}
