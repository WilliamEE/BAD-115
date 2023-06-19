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
    public class PedidosController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public PedidosController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedidos>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedidos>> GetPedido(int id)
        {
            var Pedidos = await _context.Pedidos.FindAsync(id);

            if (Pedidos == null)
            {
                return NotFound();
            }

            return Pedidos;
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedidos Pedido)
        {
            if (id != Pedido.PedidoId)
            {
                return BadRequest();
            }

            _context.Entry(Pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedidos>> PostPedido(PedidoFinal Pedido)
        {
            var nuevopedido = new Pedidos
            {
                PedidoEstadoId=Pedido.PedidoEstadoId,
                ClienteId=Pedido.ClienteId,
                DireccionEntrega=Pedido.DireccionEntrega,
                ObservacionesAdicionales=Pedido.ObservacionesAdicionales
            };

            _context.Pedidos.Add(nuevopedido);
            await _context.SaveChangesAsync();

            var nuevodetallepedido = new PedidoDetalles
            {
                PedidoId = nuevopedido.PedidoId,
                ProductoId = Pedido.ProductoId,
                Cantidad = Pedido.Cantidad
            };

            await PostPedidoDetalle(nuevodetallepedido);

            return CreatedAtAction("GetPedido", new { id = Pedido.PedidoId }, Pedido);
        }



        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var Pedido = await _context.Pedidos.FindAsync(id);
            if (Pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(Pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.PedidoId == id);
        }



        //PedidoDetalles
        // GET: api/Pedidos
        [HttpGet]
        [Route("Detalle")]
        public async Task<ActionResult<IEnumerable<PedidoDetalles>>> GetPedidoDetalles()
        {
            return await _context.PedidoDetalles.ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet]
        [Route("Detalle/{id:int}")]
        public async Task<ActionResult<PedidoDetalles>> GetPedidoDetalle(int id)
        {
            var PedidoDetalles = await _context.PedidoDetalles.FindAsync(id);

            if (PedidoDetalles == null)
            {
                return NotFound();
            }

            return PedidoDetalles;
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Detalle/{id:int}")]
        public async Task<IActionResult> PutPedidoDetalle(int id, PedidoDetalles PedidoDetalle)
        {
            if (id != PedidoDetalle.PedidoDetalleId)
            {
                return BadRequest();
            }

            _context.Entry(PedidoDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoDetalleExists(id))
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

        // POST: api/Pedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Detalle")]
        public async Task<ActionResult<Pedidos>> PostPedidoDetalle(PedidoDetalles PedidoDetalle)
        {
            _context.PedidoDetalles.Add(PedidoDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoDetalle", new { id = PedidoDetalle.PedidoDetalleId }, PedidoDetalle);
        }

        // DELETE: api/Pedidos/5
        [HttpDelete]
        [Route("Detalle/{id:int}")]
        public async Task<IActionResult> DeletePedidoDetalle(int id)
        {
            var PedidoDetalle = await _context.PedidoDetalles.FindAsync(id);
            if (PedidoDetalle == null)
            {
                return NotFound();
            }

            _context.PedidoDetalles.Remove(PedidoDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoDetalleExists(int id)
        {
            return _context.PedidoDetalles.Any(e => e.PedidoDetalleId == id);
        }
    }
}
