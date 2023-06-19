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
    public class DespachosController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public DespachosController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/Despachos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Despachos>>> GetDespachos()
        {
            return await _context.Despachos.ToListAsync();
        }

        // GET: api/Despachos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Despachos>> GetDespacho(int id)
        {
            var Despacho = await _context.Despachos.FindAsync(id);

            if (Despacho == null)
            {
                return NotFound();
            }

            return Despacho;
        }

        // PUT: api/Despachos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespachos(int id, Despachos Despacho)
        {
            if (id != Despacho.DespachoId)
            {
                return BadRequest();
            }

            _context.Entry(Despacho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DespachoExists(id))
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

        // POST: api/Despachos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Despachos>> PostDespacho(Despachos Despacho)
        {
            _context.Despachos.Add(Despacho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDespacho", new { id = Despacho.DespachoId }, Despacho);
        }

        // DELETE: api/Despachos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespacho(int id)
        {
            var Despacho = await _context.Despachos.FindAsync(id);
            if (Despacho == null)
            {
                return NotFound();
            }

            _context.Despachos.Remove(Despacho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DespachoExists(int id)
        {
            return _context.Despachos.Any(e => e.DespachoId == id);
        }
    }
}
