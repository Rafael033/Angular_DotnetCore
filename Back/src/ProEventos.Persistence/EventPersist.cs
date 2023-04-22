using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Persistence.Contextos;
using ProEventos.Domain;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventPersist : IEventPersist
    {
        private readonly DataContext _context;
        public EventPersist(DataContext context)
        {
            this._context = context;
            
        }
      
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.AsNoTracking()
            .Include(x => x.Lotes);

            if(includePalestrantes)
            {
               query = query.Include(x => x.Palestrantes);
            }
            return await query.OrderBy(x => x.Id).ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int idEvento, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.AsNoTracking()
            .Include(x => x.Lotes);

            if(includePalestrantes)
            {
               query = query.Include(x => x.Palestrantes);
            }

            query = query.OrderBy(x => x.Id).Where(x => x.Id == idEvento);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByThemeAsync(string theme, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.AsNoTracking()
            .Include(x => x.Lotes);

            if(includePalestrantes)
            {
               query = query.Include(x => x.Palestrantes);
            }
            return await query.OrderBy(x => x.Id).Where(x => x.Theme.ToLower().Contains(theme.ToLower())).ToArrayAsync();
        }

 
    }
}