using BackendTraining.ApiDoc.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendTraining.ApiDoc.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class ListSincronoController : ControllerBase
    {
        private static List<Persona> personas = new()
        {
            new Persona { Id = 1, Nombre = "Ana", Edad = 28 },
            new Persona { Id = 2, Nombre = "Luis", Edad = 35 }
        };

        // GET: /personas
        [HttpGet]
        public ActionResult<IEnumerable<Persona>> GetAll()
        {
            return Ok(personas);
        }

        // GET: /personas/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Persona> GetById(int id)
        {
            var persona = personas.FirstOrDefault(p => p.Id == id);
            return persona is not null ? Ok(persona) : NotFound();
        }

        // POST: /personas
        [HttpPost]
        public ActionResult<Persona> Create(Persona nueva)
        {
            nueva.Id = personas.Any() ? personas.Max(p => p.Id) + 1 : 1;
            personas.Add(nueva);
            return CreatedAtAction(nameof(GetById), new { id = nueva.Id }, nueva);
        }

        // PUT: /personas/{id}
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Persona actualizada)
        {
            var persona = personas.FirstOrDefault(p => p.Id == id);
            if (persona is null) return NotFound();

            persona.Nombre = actualizada.Nombre;
            persona.Edad = actualizada.Edad;
            return Ok(persona);
        }

        // DELETE: /personas/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var persona = personas.FirstOrDefault(p => p.Id == id);
            if (persona is null) return NotFound();

            personas.Remove(persona);
            return NoContent();
        }
    }
}
