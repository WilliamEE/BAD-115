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
    public class ProductoTiposController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public ProductoTiposController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/ProductoTipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoTipos>>> GetProductoTipos()
        {
            return await _context.ProductoTipos.ToListAsync();
        }

        // GET: api/ProductoTipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoTipos>> GetProductoTipos(int id)
        {
            var productoTipos = await _context.ProductoTipos.FindAsync(id);

            if (productoTipos == null)
            {
                return NotFound();
            }

            return productoTipos;
        }

        // PUT: api/ProductoTipos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoTipos(int id, ProductoTipos productoTipos)
        {
            if (id != productoTipos.ProductoTipoId)
            {
                return BadRequest();
            }

            _context.Entry(productoTipos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoTiposExists(id))
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

        // POST: api/ProductoTipos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductoTipos>> PostProductoTipos(ProductoTipos productoTipos)
        {
            _context.ProductoTipos.Add(productoTipos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductoTipos", new { id = productoTipos.ProductoTipoId }, productoTipos);
        }

        // DELETE: api/ProductoTipos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoTipos(int id)
        {
            var productoTipos = await _context.ProductoTipos.FindAsync(id);
            if (productoTipos == null)
            {
                return NotFound();
            }

            _context.ProductoTipos.Remove(productoTipos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoTiposExists(int id)
        {
            return _context.ProductoTipos.Any(e => e.ProductoTipoId == id);
        }
    }
}
