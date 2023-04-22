using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEventos(int idEvento, Evento model);
        Task<bool> DeleteEventos(int idEvento, Evento model);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int idEvento ,bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByThemeAsync(string theme ,bool includePalestrantes = false);
    }
}