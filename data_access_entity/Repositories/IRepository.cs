using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace data_access_entity.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //CRUD interface.....Create.. read..update...delete
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int Id);
        void Insert(TEntity entity);
        void Delete(int ID);
        void Update(TEntity entity);
        void Save();
    }
}
