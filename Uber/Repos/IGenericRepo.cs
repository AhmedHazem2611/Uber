namespace Uber.Repos
{
    public interface IGenericRepo<T> where T : class
    {
        public Task<T> GetById (int id);
        public Task<IEnumerable<T>> GetAll();
        public Task Add(T item);
        public void Update (T item);
        public void Delete (T item);
        public Task<IEnumerable<T>> GetPaged(int PageNumber, int PageSize);
    }
}
