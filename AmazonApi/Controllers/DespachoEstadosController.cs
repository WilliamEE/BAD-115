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
    public class DespachoEstadosController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public DespachoEstadosController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/DespachoEstados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DespachoEstados>>> GetDespachoEstados()
        {
            return await _context.DespachoEstados.ToListAsync();
        }

        // GET: api/DespachoEstados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DespachoEstados>> GetDespachoEstados(int id)
        {
            var despachoEstados = await _context.DespachoEstados.FindAsync(id);

            if (despachoEstados == null)
            {
                return NotFound();
            }

            return despachoEstados;
        }

        // PUT: api/DespachoEstados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespachoEstados(int id, DespachoEstados despachoEstados)
        {
            if (id != despachoEstados.DespachoEstadoId)
            {
                return BadRequest();
            }

            _context.Entry(despachoEstados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DespachoEstadosExists(id))
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

        // POST: api/DespachoEstados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DespachoEstados>> PostDespachoEstados(DespachoEstados despachoEstados)
        {
            _context.DespachoEstados.Add(despachoEstados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDespachoEstados", new { id = despachoEstados.DespachoEstadoId }, despachoEstados);
        }

        // DELETE: api/DespachoEstados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespachoEstados(int id)
        {
            var despachoEstados = await _context.DespachoEstados.FindAsync(id);
            if (despachoEstados == null)
            {
                return NotFound();
            }

            _context.DespachoEstados.Remove(despachoEstados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DespachoEstadosExists(int id)
        {
            return _context.DespachoEstados.Any(e => e.DespachoEstadoId == id);
        }
    }
}
