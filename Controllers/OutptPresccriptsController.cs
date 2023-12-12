using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital_Management.Models;
using Hospital_Management.Models.Context;

namespace Hospital_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutptPresccriptsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public OutptPresccriptsController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/OutptPresccripts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutptPresccript>>> GetOutptPresccripts()
        {
            return await _context.OutptPresccripts.ToListAsync();
        }

        // GET: api/OutptPresccripts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutptPresccript>> GetOutptPresccript(int id)
        {
            var outptPresccript = await _context.OutptPresccripts.FindAsync(id);

            if (outptPresccript == null)
            {
                return NotFound();
            }

            return outptPresccript;
        }

        // PUT: api/OutptPresccripts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOutptPresccript(int id, OutptPresccript outptPresccript)
        {
            if (id != outptPresccript.OutptPresccriptId)
            {
                return BadRequest();
            }

            _context.Entry(outptPresccript).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutptPresccriptExists(id))
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

        // POST: api/OutptPresccripts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OutptPresccript>> PostOutptPresccript(OutptPresccript outptPresccript)
        {
            _context.OutptPresccripts.Add(outptPresccript);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOutptPresccript", new { id = outptPresccript.OutptPresccriptId }, outptPresccript);
        }

        // DELETE: api/OutptPresccripts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OutptPresccript>> DeleteOutptPresccript(int id)
        {
            var outptPresccript = await _context.OutptPresccripts.FindAsync(id);
            if (outptPresccript == null)
            {
                return NotFound();
            }

            _context.OutptPresccripts.Remove(outptPresccript);
            await _context.SaveChangesAsync();

            return outptPresccript;
        }

        private bool OutptPresccriptExists(int id)
        {
            return _context.OutptPresccripts.Any(e => e.OutptPresccriptId == id);
        }
    }
}
