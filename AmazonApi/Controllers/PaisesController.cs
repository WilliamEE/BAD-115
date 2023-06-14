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
    public class PaisesController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public PaisesController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/Paises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paises>>> GetPaises()
        {
            return await _context.Paises.ToListAsync();
        }

        // GET: api/Paises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paises>> GetPaises(int id)
        {
            var paises = await _context.Paises.FindAsync(id);

            if (paises == null)
            {
                return NotFound();
            }

            return paises;
        }

        // PUT: api/Paises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaises(int id, Paises pais)
        {
            if (id != pais.PaisId)
            {
                return BadRequest();
            }

            _context.Entry(pais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisesExists(id))
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

        // POST: api/Paises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paises>> PostPaises(Paises pais)
        {
            _context.Paises.Add(pais);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaisesExists(pais.PaisId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaises", new { id = pais.PaisId }, pais);
        }

        // DELETE: api/Paises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaises(int id)
        {
            var paises = await _context.Paises.FindAsync(id);
            if (paises == null)
            {
                return NotFound();
            }

            _context.Paises.Remove(paises);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaisesExists(int id)
        {
            return _context.Paises.Any(e => e.PaisId == id);
        }
    }
}
