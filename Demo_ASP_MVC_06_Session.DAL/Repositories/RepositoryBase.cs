using Demo_ASP_MVC_06_Session.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_06_Session.DAL.Repositories
{
    public abstract class RepositoryBase<TId, TEntity> :
        IRepositoryBase<TId, TEntity>
    {
        protected readonly IDbConnection _connection;

        public RepositoryBase(IDbConnection connection)
        {
            _connection = connection;
        }
        protected abstract TEntity Mapper(IDataRecord record);
        public abstract TId Add(TEntity entity);
        public abstract bool Delete(TId id);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract TEntity? GetById(TId id);
        public abstract bool Update(TId id, TEntity entity);
    }
}
