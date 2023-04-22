using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProEventos.Application;
using ProEventos.Application.Contratos;
using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public EventosController(IEventoService eventoService)
        {
            this._eventoService = eventoService;

        }

         [HttpGet]
        public async Task<IActionResult> Get()
        {

         try
         {
           var eventos = await _eventoService.GetAllEventosAsync(true);
           if(eventos == null) return NotFound("Nenhum Evento Encontrado");

           return Ok(eventos);
         }
         catch (Exception ex)
         {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar Recuperar Evento. Erro:  {ex.Message}");
         }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

        try
         {
           var evento = await _eventoService.GetEventoByIdAsync(id,false);

           if(evento == null) return NotFound("Nenhum Evento Encontrado");

           return Ok(evento);
         }
         catch (Exception ex)
         {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar Recuperar Evento. Evento {id} Erro:  {ex.Message}");
         }

        
        }
        [HttpGet("{theme}/theme")]
        public async Task<IActionResult> GetByTheme(string theme)
        {

        try
         {
           var evento = await _eventoService.GetAllEventosByThemeAsync(theme,false);

           if(evento == null) return NotFound("Nenhum Evento Encontrado");

           return Ok(evento);
         }
         catch (Exception ex)
         {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar Recuperar Evento. Erro:  {ex.Message}");
         }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {

        try
         {
           var evento = await _eventoService.AddEventos(model);

           if(evento == null) return BadRequest("Erro tentar adicionar Evento");

           return Ok(evento);
         }
         catch (Exception ex)
         {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar incluir Evento. Erro:  {ex.Message}");
         }
                
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Evento model)
        {
           try
         {
           var evento = await _eventoService.UpdateEventos(id,model);

           if(evento == null) return BadRequest("Erro tentar alterar Evento");

           return Ok(evento);
         }
         catch (Exception ex)
         {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar alterar Evento. Evento {id} Erro:  {ex.Message}");
         }
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Evento model)
        {

             try
         {
           return await _eventoService.DeleteEventos(id,model)? 
           Ok("Deletado") : BadRequest("Erro ao tentar deletar");

         }
         catch (Exception ex)
         {
          
          return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar Evento. Evento {id} Erro:  {ex.Message}");
         }
        
        }

    }
}