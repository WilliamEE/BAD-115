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
    public class PedidoEstadosController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public PedidoEstadosController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/PedidoEstados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoEstados>>> GetPedidoEstados()
        {
            return await _context.PedidoEstados.ToListAsync();
        }

        // GET: api/PedidoEstados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoEstados>> GetPedidoEstados(int id)
        {
            var pedidoEstados = await _context.PedidoEstados.FindAsync(id);

            if (pedidoEstados == null)
            {
                return NotFound();
            }

            return pedidoEstados;
        }

        // PUT: api/PedidoEstados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoEstados(int id, PedidoEstados pedidoEstados)
        {
            if (id != pedidoEstados.PedidoEstadoId)
            {
                return BadRequest();
            }

            _context.Entry(pedidoEstados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoEstadosExists(id))
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

        // POST: api/PedidoEstados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PedidoEstados>> PostPedidoEstados(PedidoEstados pedidoEstados)
        {
            _context.PedidoEstados.Add(pedidoEstados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoEstados", new { id = pedidoEstados.PedidoEstadoId }, pedidoEstados);
        }

        // DELETE: api/PedidoEstados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoEstados(int id)
        {
            var pedidoEstados = await _context.PedidoEstados.FindAsync(id);
            if (pedidoEstados == null)
            {
                return NotFound();
            }

            _context.PedidoEstados.Remove(pedidoEstados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoEstadosExists(int id)
        {
            return _context.PedidoEstados.Any(e => e.PedidoEstadoId == id);
        }
    }
}
