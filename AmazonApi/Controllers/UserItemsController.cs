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
    public class UserItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserItems>>> GetUserItems()
        {
            return await _context.UserItems.ToListAsync();
        }

        // GET: api/UserItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserItems>> GetUserItems(int id)
        {
            var userItems = await _context.UserItems.FindAsync(id);

            if (userItems == null)
            {
                return NotFound();
            }

            return userItems;
        }

        [HttpGet]
        [Route("/[controller]/[action]/{userId}")]
        public async Task<ActionResult<IEnumerable<UserItems>>> GetUserItemsUnAsignedByUser(int userId)
        {
            var user = await _context.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();

            //Obtenemos los que existen
            var UserItems = await _context.UserItems
                .Where(x => x.UserId == user.UserId)
                .ToListAsync();

            //Obtenemos los que pertenecen al rol
            var Rolsitems = await _context.Items
                .Join(_context.RolsItems.Where
                (x => x.RolId == user.RolId),
                         Items => Items.ItemId,
                         RolsItems => RolsItems.ItemId,
                         (Items, RolsItems) => Items)
                .ToListAsync();

            if (UserItems.Count == 0)
            {
                foreach (Items item in Rolsitems)
                {
                    UserItems userSave = new();
                    userSave.UserId = user.UserId;
                    userSave.ItemId = item.ItemId;
                    _context.UserItems.Add(userSave);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                foreach (Items item in Rolsitems)
                {
                    UserItems userSave = new();
                    userSave.UserId = user.UserId;
                    userSave.ItemId = item.ItemId;

                    if (!user.UserItems.Any(x => x.ItemId == item.ItemId))
                    {
                        _context.UserItems.Update(userSave);
                        await _context.SaveChangesAsync();
                    }
                }
                foreach (UserItems item in UserItems)
                {
                    if (!Rolsitems.Any(x => x.ItemId == item.ItemId))
                    {
                        _context.UserItems.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            //Obtenemos los que existen
            var items = await _context.UserItems
                .Include(x=>x.Items)
                .Where(x => x.UserId == user.UserId)
                .OrderBy(x=>x.ItemId)
                .ToListAsync();

            return items;
        }

        // PUT: api/UserItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserItems(int id, UserItems userItems)
        {
            if (id != userItems.UserItemsId)
            {
                return BadRequest();
            }

            _context.Entry(userItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserItemsExists(id))
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

        // POST: api/UserItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserItems>> PostUserItems(UserItems userItems)
        {
            _context.UserItems.Add(userItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserItems", new { id = userItems.UserItemsId }, userItems);
        }

        // DELETE: api/UserItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserItems(int id)
        {
            var userItems = await _context.UserItems.FindAsync(id);
            if (userItems == null)
            {
                return NotFound();
            }

            _context.UserItems.Remove(userItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserItemsExists(int id)
        {
            return _context.UserItems.Any(e => e.UserItemsId == id);
        }
    }
}
