using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketingWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using AmazonApi.Models;

namespace MarketingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RolsController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public RolsController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/Rols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rols>>> GetRols()
        {
            return await _context.Rols
                .Include(t => t.RolsItems)
                .ThenInclude(t => t.Items)
                .ToListAsync();
        }

        // GET: api/Rols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rols>> GetRols(int id)
        {
            var rols = await _context.Rols.FindAsync(id);

            if (rols == null)
            {
                return NotFound();
            }

            return rols;
        }

        // PUT: api/Rols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRols(int id, Rols rols)
        {
            if (id != rols.RolId)
            {
                return BadRequest();
            }

            _context.Entry(rols).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolsExists(id))
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

        // PUT: api/Rols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("/[controller]/[action]/{id}")]
        public async Task<IActionResult> PutRolsWithItems(int id, Rols rols)
        {
            if (id != rols.RolId)
            {
                return BadRequest();
            }

            _context.Entry(rols).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                var RolsItems = await _context.RolsItems
                    .Where(x => x.RolId == rols.RolId)
                    .AsNoTracking()
                    .IgnoreAutoIncludes()
                    .ToListAsync();

                foreach (var item in RolsItems)
                {
                    if (rols.RolsItems.Any(x => x.RolId == item.RolId && x.ItemId == item.ItemId))
                    {
                        _context.RolsItems.Update(item);
                        await _context.SaveChangesAsync();
                    }
                    else {
                        _context.RolsItems.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }

                foreach (var item in rols.RolsItems)
                {
                    if (!RolsItems.Any(x => x.RolId == item.RolId && x.ItemId == item.ItemId))
                    {
                        _context.RolsItems.Add(item);
                        await _context.SaveChangesAsync();
                    }
                }


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolsExists(id))
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

        // POST: api/Rols
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rols>> PostRols(Rols rols)
        {
            _context.Rols.Add(rols);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRols", new { id = rols.RolId }, rols);
        }

        // DELETE: api/Rols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRols(int id)
        {
            var rols = await _context.Rols.FindAsync(id);
            if (rols == null)
            {
                return NotFound();
            }

            _context.Rols.Remove(rols);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolsExists(int id)
        {
            return _context.Rols.Any(e => e.RolId == id);
        }
    }
}
