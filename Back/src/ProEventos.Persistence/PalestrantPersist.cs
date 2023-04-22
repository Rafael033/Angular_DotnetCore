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
    public class PalestrantPersistence : IPalestrantPersist
    {
        private readonly DataContext _context;
        public PalestrantPersistence(DataContext context)
        {
            this._context = context;
            
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
              IQueryable<Palestrante> query = _context.Palestrantes
            .Include(x => x.RedesSocials);

            if(includeEventos)
            {
               query = query.Include(x => x.PalestrantesEventos).ThenInclude(x => x.Evento);
            }
            return await query.OrderBy(x => x.Id).ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestrantesByIdAsync(int idPalestrante, bool includeEventos)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
            .Include(x => x.RedesSocials);

            if(includeEventos)
            {
               query = query.Include(x => x.PalestrantesEventos).ThenInclude(x => x.Evento);
            }

            query = query.Where(x => x.Id == idPalestrante).OrderBy(x => x.Id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNameAsync(string name, bool includeEventos)
        {
                IQueryable<Palestrante> query = _context.Palestrantes
            .Include(x => x.RedesSocials);

            if(includeEventos)
            {
               query = query.Include(x => x.PalestrantesEventos).ThenInclude(x => x.Evento);
            }

            query = query.Where(x => x.Name.ToLower().Contains(name.ToLower())).OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

    }
}