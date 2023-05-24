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
    public class UserAccessesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserAccessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserAccesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccess>>> GetUserAccess()
        {
            return await _context.UserAccess.ToListAsync();
        }

        // GET: api/UserAccesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccess>> GetUserAccess(int id)
        {
            var userAccess = await _context.UserAccess.FindAsync(id);

            if (userAccess == null)
            {
                return NotFound();
            }

            return userAccess;
        }

        // PUT: api/UserAccesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAccess(int id, UserAccess userAccess)
        {
            if (id != userAccess.UserAccesId)
            {
                return BadRequest();
            }

            _context.Entry(userAccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccessExists(id))
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

        // POST: api/UserAccesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAccess>> PostUserAccess(UserAccess userAccess)
        {
            _context.UserAccess.Add(userAccess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAccess", new { id = userAccess.UserAccesId }, userAccess);
        }

        // DELETE: api/UserAccesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccess(int id)
        {
            var userAccess = await _context.UserAccess.FindAsync(id);
            if (userAccess == null)
            {
                return NotFound();
            }

            _context.UserAccess.Remove(userAccess);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAccessExists(int id)
        {
            return _context.UserAccess.Any(e => e.UserAccesId == id);
        }
    }
}
