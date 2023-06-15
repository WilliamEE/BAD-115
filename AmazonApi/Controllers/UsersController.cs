using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketingWebApi.Models;
using AmazonApi.Models;

namespace MarketingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly BD_AmazonContext _context;

        public UsersController(BD_AmazonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var applicationDbContext = _context.Users.
                Include(u => u.Rols)
                .Include(t => t.UserItems)
                .ThenInclude(t => t.Items);
            return await applicationDbContext.ToListAsync();
        }

        // GET: api/Users
        [HttpGet]
        [Route("/[controller]/[action]/{officeid}")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsersByOfficeId(int officeid)
        {
            var applicationDbContext = _context.Users
                .Include(u => u.Rols);
            return await applicationDbContext.ToListAsync();
        }

        // GET: api/Users
        [HttpGet]
        [Route("/[controller]/[action]/{CompanyId}")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsersByCompanyId(int CompanyId)
        {
            var applicationDbContext = _context.Users
                .Include(u => u.Rols);
            return await applicationDbContext.ToListAsync();
        }


        [HttpGet("{officeid}/{id}")]
        public async Task<ActionResult<Users>> GetUsers(int officeid,int id)
        {

            var users = await _context.Users
            .Include(u => u.Rols)
            .FirstOrDefaultAsync(m => m.UserId == id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }
      
      

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.UserId)
            {
                return BadRequest();
            }

            var entityToUpdate = await _context.Users.Where(x => x.UserId == id).AsNoTracking().FirstOrDefaultAsync();

            users.UserPassword = entityToUpdate.UserPassword;

            _context.Entry(users).State = EntityState.Modified;
           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        [HttpPut]
        [Route("/[controller]/[action]/{id}")]
        public async Task<IActionResult> PutChangePassword(int id, Users users)
        {
            var entityToUpdate = await _context.Users.FindAsync(id);

            if (entityToUpdate == null)
            {
                return NotFound();
            }

            entityToUpdate.UserPassword = users.UserPassword;

            _context.SaveChanges();

            return Ok();
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut]
        //[Route("/[controller]/[action]/{id}")]
        //public async Task<IActionResult> PutUsersWithItems(int id, Users users)
        //{
        //    if (id != users.UserId)
        //    {
        //        return BadRequest();
        //    }


        //    _context.Entry(users).State = EntityState.Modified;


        //    try
        //    {
        //        await _context.SaveChangesAsync();

        //        foreach (var item in users.UserItems)
        //        {
        //            _context.UserItems.Update(item);
        //            await _context.SaveChangesAsync();
        //        }
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsersExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            //users.UserPassword = users.UserPassword.GenerateSHA256();
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
