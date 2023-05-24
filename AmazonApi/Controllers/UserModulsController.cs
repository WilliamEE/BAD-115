using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketingWebApi.Data;
using MarketingWebApi.Models;
using Microsoft.Data.SqlClient;

namespace MarketingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserModulsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserModulsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserModuls
        [HttpGet("{userid}")]
        public async Task<ActionResult<IEnumerable<UserModuls>>> GetUserModuls(int userid)
        {
            try
            {
                string qry = "select b.RolModulId,d.ModulId,d.ModulName,e.PageName,e.ControllerName,e.ActionName " +
                   "from Users a " +
                   "inner join RolsModuls b on a.RolId = b.RolId " +
                   "inner join ModulsPages c on b.ModulPageId = c.ModulPageId " +
                   "inner join Moduls d on c.ModulId = d.ModulId " +
                   "inner join Pages e on c.PageId = e.PageId " +
                   "where a.UserId = @UserId ";
                var result = await _context.UserModuls.FromSqlRaw(qry, new SqlParameter("@UserId", userid)).ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        // PUT: api/UserModuls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModuls(int id, UserModuls userModuls)
        {
            if (id != userModuls.RolModulId)
            {
                return BadRequest();
            }

            _context.Entry(userModuls).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModulsExists(id))
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

        // POST: api/UserModuls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserModuls>> PostUserModuls(UserModuls userModuls)
        {
            _context.UserModuls.Add(userModuls);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserModuls", new { id = userModuls.RolModulId }, userModuls);
        }

        // DELETE: api/UserModuls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserModuls(int id)
        {
            var userModuls = await _context.UserModuls.FindAsync(id);
            if (userModuls == null)
            {
                return NotFound();
            }

            _context.UserModuls.Remove(userModuls);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserModulsExists(int id)
        {
            return _context.UserModuls.Any(e => e.RolModulId == id);
        }
    }
}
