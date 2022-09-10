using System.Data.Entity;
using TiempoEnProcesoBL.Interfaces;
using TiempoEnProcesoDL;

namespace TiempoEnProcesoBL.Repository
{
    public abstract class Repository<T>
    {
        protected readonly TEPEntities db;

        public Repository(TEPEntities _db)
        {
            db = _db;
        }
    }
}
