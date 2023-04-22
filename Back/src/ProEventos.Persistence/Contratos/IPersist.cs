using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPersist
    {
        void Add<T> (T entity) where T: class; 
        void Update<T> (T entity) where T: class; 
        void Delete<T> (T entity) where T: class; 
        void DeleteRanger<T> (T[] entity) where T: class; 
        Task<bool> SaveChangesAsync();
        
    }
}