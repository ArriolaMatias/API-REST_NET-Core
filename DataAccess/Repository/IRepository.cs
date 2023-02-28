namespace DataAccess.Repository
{
    public interface IRepository<T>
    {
        public void Create(T _object);
        public IEnumerable<T> Read();
        public void Update(int id, T _object);
        public void Delete(T _object);
        public T? GetById(int id);
    }
}
