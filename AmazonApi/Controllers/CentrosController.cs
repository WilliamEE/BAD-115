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
    public class CentrosController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public CentrosController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/Centros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Centros>>> GetCentros()
        {
            return await _context.Centros.ToListAsync();
        }

        // GET: api/Centros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Centros>> GetCentros(int id)
        {
            var centros = await _context.Centros.FindAsync(id);

            if (centros == null)
            {
                return NotFound();
            }

            return centros;
        }

        // PUT: api/Centros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCentros(int id, Centros centros)
        {
            if (id != centros.CentroId)
            {
                return BadRequest();
            }

            _context.Entry(centros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentrosExists(id))
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

        // POST: api/Centros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Centros>> PostCentros(Centros centros)
        {
            _context.Centros.Add(centros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCentros", new { id = centros.CentroId }, centros);
        }

        // DELETE: api/Centros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCentros(int id)
        {
            var centros = await _context.Centros.FindAsync(id);
            if (centros == null)
            {
                return NotFound();
            }

            _context.Centros.Remove(centros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CentrosExists(int id)
        {
            return _context.Centros.Any(e => e.CentroId == id);
        }
    }
}
