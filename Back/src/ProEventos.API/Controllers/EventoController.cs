using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [Route("api/[controller]")]
    public class EventoController : Controller
    {
        public IEnumerable<Evento> _evento = new Evento[]{
                        new Evento(){
                            EventoId = 1,
                            Tema = "Fut Recorrente Qauarta",
                            Local = "Golden ball",
                            Lote = 5,
                            QdtPessoas = 20,
                            DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                            ImageURL = "foto.png"

                        },
                        new Evento(){
                            EventoId = 2,
                            Tema = "Fut Recorrente Qauarta",
                            Local = "Golden ball",
                            Lote = 5,
                            QdtPessoas = 20,
                            DataEvento = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy"),
                            ImageURL = "foto.png"

                        }
       };
       
        public EventoController()
        {
           
        }

         [HttpGet]
        public IEnumerable<Evento> Get()
        {

          return _evento;

        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {

          return _evento.Where(x => x.EventoId == id);

        }

    }
}