using System.Linq;
using event_manager_data;
using Microsoft.AspNetCore.Mvc;
using event_manager_shared.Models;

namespace event_manager_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventiController : ControllerBase
    {
        private readonly EventManagerDbContext db;
    
        public EventiController(EventManagerDbContext db)
        {
            this.db = db;
        }
    
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.db.Eventi.Select(x => new ElementoListaEventi()
            {
                Id = x.Id,
                Nome = x.Nome,
                Localita = x.Localita,
                Data = x.Data
            }).ToList());
        }
    
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.db.Eventi
                .Where(x => x.Id == id)
                .Select(x => new Evento()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Localita = x.Localita,
                    Data = x.Data,
                    Descrizione = x.Descrizione,
                    Note = x.Note
                }).SingleOrDefault();
    
            if(result == null) return NotFound();
            return Ok(result);
        }
    
        [HttpPost]
        public IActionResult Post(Evento item)
        {
            if(ModelState.IsValid)
            {
                var entity = new DatiEvento()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Localita = item.Localita,
                    Data = item.Data,
                    Descrizione = item.Descrizione,
                    Note = item.Note
                };
                this.db.Add(entity);
                this.db.SaveChanges();
                item.Id = entity.Id;
                return CreatedAtAction(nameof(Get), new { id = entity.Id }, item);
            }
            return BadRequest(ModelState);
        }
    
        [HttpPut("{id}")]
        public IActionResult Put(int id, Evento item)
        {
            if(ModelState.IsValid)
            {
                var entity = this.db.Eventi.SingleOrDefault(x => x.Id == id);
                if(entity == null) return NotFound();
                entity.Nome = item.Nome;
                entity.Localita = item.Localita;
                entity.Data = item.Data;
                entity.Descrizione = item.Descrizione;
                entity.Note = item.Note;
                this.db.SaveChanges();
                return NoContent();
            }
            return BadRequest(ModelState);
        }
    
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = this.db.Eventi.SingleOrDefault(x => x.Id == id);
            if(entity == null) return NotFound();
            this.db.Remove(entity);
            this.db.SaveChanges();
            return NoContent();
        }
    }
}