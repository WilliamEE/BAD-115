using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketingWebApi.Data;
using MarketingWebApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace MarketingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    
    public class ModulsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ModulsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Moduls
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moduls>>> GetModuls()
        {
            return await _context.Moduls.Include(t=> t.Items).ToListAsync();
        }

        // GET: api/Moduls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Moduls>> GetModuls(int id)
        {
            var moduls = await _context.Moduls.FindAsync(id);

            if (moduls == null)
            {
                return NotFound();
            }

            return moduls;
        }

        [HttpGet]
        [Route("/[controller]/[action]/{rolid}")]
        public async Task<ActionResult<IEnumerable<Object>>> GetModulsByRolId(int rolid)
        {

            var values = await _context.Moduls
                        .Join(_context.Items
                        .Join(_context.RolsItems
                        .Where(x => x.RolId == rolid),
                        Items => Items.ItemId,
                        RolsItems => RolsItems.ItemId,
                        (Items, RolsItems) => Items)
                        ,
                        Moduls => Moduls.ModulId,
                        Items => Items.ModulId,
                        (Moduls, Items) => new
                        {
                            ModulIdG = Moduls.ModulId,
                            TextG = Moduls.ModulName,
                            IconG = Moduls.Icon,
                            ItemsG = Items
                        }
                        )
                        .ToListAsync();

            return values
                .GroupBy(x => x.ModulIdG)
                .Select(x => new {
                    ModulID = x.Key,
                    Text = x.First().TextG,
                    Icon = x.First().IconG,
                    Items = x.Select(x => x.ItemsG).ToList()
                })
                .ToList();
        }

        // PUT: api/Moduls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModuls(int id, Moduls moduls)
        {
            if (id != moduls.ModulId)
            {
                return BadRequest();
            }

            _context.Entry(moduls).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModulsExists(id))
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

        // POST: api/Moduls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Moduls>> PostModuls(Moduls moduls)
        {
            _context.Moduls.Add(moduls);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModuls", new { id = moduls.ModulId }, moduls);
        }

        // DELETE: api/Moduls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModuls(int id)
        {
            var moduls = await _context.Moduls.FindAsync(id);
            if (moduls == null)
            {
                return NotFound();
            }

            _context.Moduls.Remove(moduls);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModulsExists(int id)
        {
            return _context.Moduls.Any(e => e.ModulId == id);
        }
    }
}
