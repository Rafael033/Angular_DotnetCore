using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Locality { get; set; }
        public int Lote { get; set; }
        public int QdtPessoas { get; set; }
        public string DataEvento { get; set; }
        public string ImageURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public IEnumerable<Palestrante> Palestrantes { get; set; }
        public IEnumerable<Lote> Lotes { get; set; }
    }
}