using System.Linq.Expressions;

namespace MyFramework.Domain
{
    public interface IRepository<Tkey, T> where T : class
    {
        void Create(T entity);
        T GetById(Tkey Id);
        List<T> GetAll();
        bool Exist(Expression<Func<T, bool>> expression);
        void Save();
    }
}
