using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AmazonApi.Models;

namespace AmazonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionesController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public RecepcionesController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/Recepciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recepciones>>> GetRecepciones()
        {
            return await _context.Recepciones.ToListAsync();
        }

        // GET: api/Recepciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recepciones>> GetRecepcion(int id)
        {
            var Recepcion = await _context.Recepciones.FindAsync(id);

            if (Recepcion == null)
            {
                return NotFound();
            }

            return Recepcion;
        }

        // PUT: api/Recepciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecepcion(int id, Recepciones Recepcion)
        {
            if (id != Recepcion.RecepcionId)
            {
                return BadRequest();
            }

            _context.Entry(Recepcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecepcionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Recepciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recepciones>> PostRecepciones(Recepciones Recepcion)
        {
            _context.Recepciones.Add(Recepcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecepcion", new { id = Recepcion.RecepcionId }, Recepcion);
        }

        // DELETE: api/Recepciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecepcion(int id)
        {
            var Recepcion = await _context.Recepciones.FindAsync(id);
            if (Recepcion == null)
            {
                return NotFound();
            }

            _context.Recepciones.Remove(Recepcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecepcionExists(int id)
        {
            return _context.Recepciones.Any(e => e.RecepcionId == id);
        }
    }
}
