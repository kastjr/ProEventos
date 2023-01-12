using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.src.ProEventos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Proeventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[] {

                new Evento(){
                EventoId = 1,
                Tema = "Angular",
                Local = "Bh",
                Lote = "1 lote",
                QtdPessoas = 100,
                DataEvento = DateTime.Now.AddDays(2).ToString()
                },

                new Evento(){
                EventoId = 2,
                Tema = "Angular",
                Local = "sp",
                Lote = "3 lote",
                QtdPessoas = 1000,
                DataEvento = DateTime.Now.AddDays(2).ToString()
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
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
            
        }

        [HttpPost]
        public string Post()
        {
            return "exemplo";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"exemplo de put {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"exemplo de delete {id}";
        }
    }
}
