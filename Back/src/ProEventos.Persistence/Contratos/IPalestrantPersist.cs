using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantPersist
    {

        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetAllPalestrantesByIdAsync(int idPalestrante ,bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesByNameAsync(string name ,bool includeEventos);
        
    }
}