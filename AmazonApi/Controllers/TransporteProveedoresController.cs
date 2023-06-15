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
    public class TransporteProveedoresController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public TransporteProveedoresController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/TransporteProveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransporteProveedores>>> GetTransporteProveedores()
        {
            return await _context.TransporteProveedores.ToListAsync();
        }

        // GET: api/TransporteProveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransporteProveedores>> GetTransporteProveedores(int id)
        {
            var transporteProveedores = await _context.TransporteProveedores.FindAsync(id);

            if (transporteProveedores == null)
            {
                return NotFound();
            }

            return transporteProveedores;
        }

        // PUT: api/TransporteProveedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransporteProveedores(int id, TransporteProveedores transporteProveedores)
        {
            if (id != transporteProveedores.TransporteProveedorId)
            {
                return BadRequest();
            }

            _context.Entry(transporteProveedores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransporteProveedoresExists(id))
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

        // POST: api/TransporteProveedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransporteProveedores>> PostTransporteProveedores(TransporteProveedores transporteProveedores)
        {
            _context.TransporteProveedores.Add(transporteProveedores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransporteProveedores", new { id = transporteProveedores.TransporteProveedorId }, transporteProveedores);
        }

        // DELETE: api/TransporteProveedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransporteProveedores(int id)
        {
            var transporteProveedores = await _context.TransporteProveedores.FindAsync(id);
            if (transporteProveedores == null)
            {
                return NotFound();
            }

            _context.TransporteProveedores.Remove(transporteProveedores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransporteProveedoresExists(int id)
        {
            return _context.TransporteProveedores.Any(e => e.TransporteProveedorId == id);
        }
    }
}
