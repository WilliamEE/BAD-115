using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    
    public class ModulesController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public ModulesController(BD_AmazonContext context)
        {
            _context = context;
        }

        // GET: api/Modules
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modules>>> GetModuls()
        {
            return await _context.Modules.Include(t=> t.Items).ToListAsync();
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modules>> GetModuls(int id)
        {
            var moduls = await _context.Modules.FindAsync(id);

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

            var values = await _context.Modules
                        .Join(_context.Items
                        .Join(_context.RolsItems
                        .Where(x => x.RolId == rolid),
                        Items => Items.ItemId,
                        RolsItems => RolsItems.ItemId,
                        (Items, RolsItems) => Items)
                        ,
                        Modules => Modules.ModulId,
                        Items => Items.ModulId,
                        (Modules, Items) => new
                        {
                            ModulIdG = Modules.ModulId,
                            TextG = Modules.ModulName,
                            IconG = Modules.Icon,
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

        // PUT: api/Modules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModuls(int id, Modules moduls)
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

        // POST: api/Modules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modules>> PostModuls(Modules moduls)
        {
            _context.Modules.Add(moduls);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModuls", new { id = moduls.ModulId }, moduls);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModuls(int id)
        {
            var moduls = await _context.Modules.FindAsync(id);
            if (moduls == null)
            {
                return NotFound();
            }

            _context.Modules.Remove(moduls);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModulsExists(int id)
        {
            return _context.Modules.Any(e => e.ModulId == id);
        }
    }
}
