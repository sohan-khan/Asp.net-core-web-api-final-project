using Hospital_Management.Models;
using Hospital_Management.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hospital_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestlistsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public TestlistsController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/Testlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testlist>>> GetTestlists()
        {
            return await _context.Testlists.ToListAsync();
        }

        // GET: api/Testlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Testlist>> GetTestlist(int id)
        {
            var testlist = await _context.Testlists.FindAsync(id);

            if (testlist == null)
            {
                return NotFound();
            }

            return testlist;
        }

        // PUT: api/Testlists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestlist(int id, Testlist testlist)
        {
            if (id != testlist.testlistId)
            {
                return BadRequest();
            }

            _context.Entry(testlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestlistExists(id))
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

        // POST: api/Testlists
        [HttpPost]
        public async Task<ActionResult<Testlist>> PostTestlist(Testlist testlist)
        {
            _context.Testlists.Add(testlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestlist", new { id = testlist.testlistId }, testlist);
        }

        // DELETE: api/Testlists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Testlist>> DeleteTestlist(int id)
        {
            var testlist = await _context.Testlists.FindAsync(id);
            if (testlist == null)
            {
                return NotFound();
            }

            _context.Testlists.Remove(testlist);
            await _context.SaveChangesAsync();

            return testlist;
        }

        private bool TestlistExists(int id)
        {
            return _context.Testlists.Any(e => e.testlistId == id);
        }
    }
}
