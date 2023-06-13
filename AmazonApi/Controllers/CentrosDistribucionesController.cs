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
    public class CentrosDistribucionesController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public CentrosDistribucionesController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/CentrosDistribuciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Centros>>> GetCentrosDistribucions()
        {
            return await _context.CentrosDistribucions.ToListAsync();
        }

        // GET: api/CentrosDistribuciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Centros>> GetCentrosDistribucion(int id)
        {
            var centrosDistribucion = await _context.CentrosDistribucions.FindAsync(id);

            if (centrosDistribucion == null)
            {
                return NotFound();
            }

            return centrosDistribucion;
        }

        // PUT: api/CentrosDistribuciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCentrosDistribucion(int id, Centros centrosDistribucion)
        {
            if (id != centrosDistribucion.CentroDistribucionId)
            {
                return BadRequest();
            }

            _context.Entry(centrosDistribucion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentrosDistribucionExists(id))
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

        // POST: api/CentrosDistribuciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Centros>> PostCentrosDistribucion(Centros centrosDistribucion)
        {
            _context.CentrosDistribucions.Add(centrosDistribucion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CentrosDistribucionExists(centrosDistribucion.CentroDistribucionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCentrosDistribucion", new { id = centrosDistribucion.CentroDistribucionId }, centrosDistribucion);
        }

        // DELETE: api/CentrosDistribuciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCentrosDistribucion(int id)
        {
            var centrosDistribucion = await _context.CentrosDistribucions.FindAsync(id);
            if (centrosDistribucion == null)
            {
                return NotFound();
            }

            _context.CentrosDistribucions.Remove(centrosDistribucion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CentrosDistribucionExists(int id)
        {
            return _context.CentrosDistribucions.Any(e => e.CentroDistribucionId == id);
        }
    }
}
