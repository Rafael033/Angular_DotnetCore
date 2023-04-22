using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? IdEvento { get; set; }
        public IEnumerable<Evento> Eventos { get; set; }
        public int? IdPalestrantes { get; set; }
        public IEnumerable<Palestrante> Palestrantes { get; set; }
        
    }
}