using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventPersist
    {
        //EVENTOS
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int idEvento ,bool includePalestrantes);
        Task<Evento[]> GetAllEventosByThemeAsync(string theme ,bool includePalestrantes);
        
    }
}