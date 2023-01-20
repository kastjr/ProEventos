using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.src.ProEventos.API.Data;
using Back.src.ProEventos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Proeventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;
        public EventoController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;

        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);

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
