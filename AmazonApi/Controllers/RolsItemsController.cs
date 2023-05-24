using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketingWebApi.Data;
using MarketingWebApi.Models;

namespace MarketingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolsItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RolsItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RolsItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolsItems>>> GetRolsItems()
        {
            return await _context.RolsItems.ToListAsync();
        }

        // GET: api/RolsItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolsItems>> GetRolsItems(int id)
        {
            var rolsItems = await _context.RolsItems.FindAsync(id);

            if (rolsItems == null)
            {
                return NotFound();
            }

            return rolsItems;
        }

        // GET: api/RolsItems/5
        [HttpGet]
        [Route("/[controller]/[action]/{Rolid}")]
        public async Task<ActionResult<IEnumerable<RolsItems>>> GetItemsByRolId(int Rolid)
        {
            var rolsItems = await _context.RolsItems
                .Include(t => t.Items).ThenInclude(t => t.Moduls)
                .Include(t => t.Rols)
                .Where(x => x.RolId == Rolid)
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .ToListAsync();

            return rolsItems;
        }

        //[HttpGet]
        //[Route("/[controller]/[action]/{rolid}")]
        //public async Task<ActionResult<IEnumerable<Moduls>>> GetItemsByRolId(int rolid)
        //{

        //    var result = await _context.RolsItems.Where(x=>x.RolId== rolid).ToListAsync();
        //    List<Items> items = new();
        //    List<Moduls> moduls = new();
        //    foreach (var item in result)
        //    {
        //        var resultitems = await _context.Items.Where(x => x.ItemId == item.ItemId).FirstOrDefaultAsync();
        //        if (resultitems != null)
        //        {
        //            items.Add(resultitems);
        //        }
        //    }

        //    if (items != null )
        //    {
        //        var itemsgroup = items.ToList().GroupBy(x => x.ModulId);
        //        foreach (var item in itemsgroup)
        //        {
        //            var resultmoduls = await _context.Moduls.Include(t=>t.Items).Where(x => x.ModulId == item.FirstOrDefault().ModulId).FirstOrDefaultAsync();
        //            if (resultmoduls != null)
        //            {
        //                moduls.Add(resultmoduls);
        //            }
        //        }
        //    }

        //    return moduls;
        //}

        //[HttpGet]
        //[Route("/[controller]/[action]/{rolid}")]
        //public IQueryable<object> GetItemsByRolIdQry(int rolid)
        //{
        //    var existsQuery = from ri in _context.RolsItems
        //                      join i in _context.Items on ri.ItemId equals i.ItemId
        //                      join t in _context.Moduls on i.ModulId equals t.ModulId
        //                      where ri.RolId == rolid
        //                      select new
        //                      {
        //                          ri.RolId,
        //                          ri.ItemId,
        //                          i.ItemName,
        //                          t.ModulName,
        //                          Exists = true
        //                      };

        //    var notExistsQuery = from r in _context.Rols
        //                         from i in _context.Items
        //                         join t in _context.Moduls on i.ModulId equals t.ModulId
        //                         where !(from ri in _context.RolsItems where ri.RolId == r.RolId && ri.ItemId == i.ItemId select ri.RolItemId).Any()
        //                         && r.RolId == rolid
        //                         select new
        //                         {
        //                             r.RolId,
        //                             i.ItemId,
        //                             i.ItemName,
        //                             t.ModulName,
        //                             Exists = false
        //                         };

        //    IQueryable<object> result =  existsQuery.Union(notExistsQuery);

        //    return result;
        //}


            // PUT: api/RolsItems/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolsItems(int id, RolsItems rolsItems)
        {
            if (id != rolsItems.RolItemId)
            {
                return BadRequest();
            }

            _context.Entry(rolsItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolsItemsExists(id))
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

        // POST: api/RolsItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolsItems>> PostRolsItems(RolsItems rolsItems)
        {

            if (! await _context.RolsItems.Where(x => x.RolId == rolsItems.RolId && x.ItemId == rolsItems.ItemId).AnyAsync())
            {
                _context.RolsItems.Add(rolsItems);
                await _context.SaveChangesAsync();
            }

            return Ok();

        }

        // DELETE: api/RolsItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolsItems(int id)
        {
            var rolsItems = await _context.RolsItems.FindAsync(id);

            if (rolsItems == null)
            {
                return NotFound();
            }

            _context.RolsItems.Remove(rolsItems);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolsItemsExists(int id)
        {
            return _context.RolsItems.Any(e => e.RolItemId == id);
        }
    }
}
