using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class Lote
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Amount { get; set; }
        public int IdEvento { get; set; }
        public Evento Eventos { get; set; }

    }
}