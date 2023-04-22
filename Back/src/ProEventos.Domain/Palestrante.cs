using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SmallCV { get; set; }
        public string ImageURL { get; set; }
        public int Cellphone { get; set; }
        public IEnumerable<RedeSocial> RedesSocials { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
        
    }
}