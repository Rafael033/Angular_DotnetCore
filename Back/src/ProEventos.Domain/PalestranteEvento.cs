using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class PalestranteEvento
    {
    public int IdPalestrante { get; set; }
    public IEnumerable<Palestrante> Palestrante { get; set; }
    public int IdEvento { get; set; }
    public IEnumerable<Evento> Evento { get; set; }
    }
}