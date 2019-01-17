
using System.Collections.Generic;

namespace WebCommercial.Models.DAO
{
    public interface IDAO<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetSingleById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int Id);
    }
}
