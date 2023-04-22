using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IPersist _persist;
        private readonly IEventPersist _eventPersist;
        public EventoService(IPersist persist, IEventPersist eventPersist)
        {
            this._eventPersist = eventPersist;
            this._persist = persist;
            
        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _persist.Add<Evento>(model);
                if( await _persist.SaveChangesAsync())
                {
                  return await _eventPersist.GetEventoByIdAsync(model.Id,false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

         public async Task<Evento>UpdateEventos(int idEvento, Evento model)
        {
            try
            {
               var evento = await _eventPersist.GetEventoByIdAsync(idEvento,false);
               if(evento == null)
               {
                 return null;
               }

               model.Id = evento.Id;

               _persist.Update(model);
                if( await _persist.SaveChangesAsync())
                {
                  return await _eventPersist.GetEventoByIdAsync(model.Id,false);
                }
                return null;
            }
            catch (Exception ex)
            {               
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEventos(int idEvento, Evento model)
        {
             try
            {
               var evento = await _eventPersist.GetEventoByIdAsync(idEvento,false);
               if(evento == null) return  false;//throw new Exception("Evento não encontrado!");

               model.Id = evento.Id;

               _persist.Delete(model);

               return await _persist.SaveChangesAsync();
            }
            catch (Exception ex)
            {               
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
              var eventos = await _eventPersist.GetAllEventosAsync(false);
             if (eventos == null) return null;

             return eventos;
            }
            catch (Exception ex)
            {         
                throw new Exception (ex.Message);
            }
         
        }

        public async Task<Evento> GetEventoByIdAsync(int idEvento, bool includePalestrantes = false)
        {
             try
            {
              var eventos = await _eventPersist.GetEventoByIdAsync(idEvento,false);
             if (eventos == null) return null;

             return eventos;
            }
            catch (Exception ex)
            {         
                throw new Exception (ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByThemeAsync(string theme, bool includePalestrantes = false)
        {
              try
            {
              var eventos = await _eventPersist.GetAllEventosByThemeAsync(theme,false);
             if (eventos == null) return null;

             return eventos;
            }
            catch (Exception ex)
            {         
                throw new Exception (ex.Message);
            }
        }
    }
}