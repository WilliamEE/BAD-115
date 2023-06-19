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
    public class InventarioController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public InventarioController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/Inventario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventarios>>> GetInventario()
        {
            return await _context.Inventarios.ToListAsync();
        }

        // GET: api/Inventarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventarios>> GetInventario(int id)
        {
            var Inventario = await _context.Inventarios.FindAsync(id);

            if (Inventario == null)
            {
                return NotFound();
            }

            return Inventario;
        }

        // PUT: api/Inventarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventarios(int id, Inventarios Inventarios)
        {
            if (id != Inventarios.InventarioId)
            {
                return BadRequest();
            }

            _context.Entry(Inventarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventariosExists(id))
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

        // POST: api/Inventarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventarios>> PostInventarios(Inventarios Inventarios)
        {
            _context.Inventarios.Add(Inventarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventario", new { id = Inventarios.InventarioId }, Inventarios);
        }

        // DELETE: api/Inventarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventarios(int id)
        {
            var Inventarios = await _context.Inventarios.FindAsync(id);
            if (Inventarios == null)
            {
                return NotFound();
            }

            _context.Inventarios.Remove(Inventarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventariosExists(int id)
        {
            return _context.Inventarios.Any(e => e.InventarioId == id);
        }
    }
}
