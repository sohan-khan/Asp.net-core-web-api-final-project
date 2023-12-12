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
    public class BedsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public BedsController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/Beds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bed>>> GetBeds()
        {
            return await _context.Beds.ToListAsync();
        }

        // GET: api/Beds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bed>> GetBed(int id)
        {
            var bed = await _context.Beds.FindAsync(id);

            if (bed == null)
            {
                return NotFound();
            }

            return bed;
        }

        // PUT: api/Beds/5
      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBed(int id, Bed bed)
        {
            if (id != bed.BedId)
            {
                return BadRequest();
            }

            _context.Entry(bed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BedExists(id))
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

        // POST: api/Beds
       
        [HttpPost]
        public async Task<ActionResult<Bed>> PostBed(Bed bed)
        {
            _context.Beds.Add(bed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBed", new { id = bed.BedId }, bed);
        }

        // DELETE: api/Beds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bed>> DeleteBed(int id)
        {
            var bed = await _context.Beds.FindAsync(id);
            if (bed == null)
            {
                return NotFound();
            }

            _context.Beds.Remove(bed);
            await _context.SaveChangesAsync();

            return bed;
        }

        private bool BedExists(int id)
        {
            return _context.Beds.Any(e => e.BedId == id);
        }
    }
}
