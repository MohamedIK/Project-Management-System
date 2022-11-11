namespace Project_Management_System.ORM
{
    public interface IORM<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
