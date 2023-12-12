using Hospital_Management.Models;
using Hospital_Management.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public FacilitiesController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/Facilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facilities>>> GetFacilities()
        {
            return await _context.Facilities.ToListAsync();
        }

        // GET: api/Facilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facilities>> GetFacilities(int id)
        {
            var facilities = await _context.Facilities.FindAsync(id);

            if (facilities == null)
            {
                return NotFound();
            }

            return facilities;
        }

        // PUT: api/Facilities/5

        [HttpPut("{id}")]
        public async Task<ActionResult> PutFacilities(int id, Facilities facilities)
        {
            if (id != facilities.FacilitiesId)
            {
                return BadRequest();
            }

            _context.Entry(facilities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilitiesExists(id))
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

        // POST: api/Facilities

        [HttpPost]
        public async Task<ActionResult<Facilities>> PostFacilities(Facilities facilities)
        {
            _context.Facilities.Add(facilities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacilities", new { id = facilities.FacilitiesId }, facilities);
        }

        // DELETE: api/Facilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Facilities>> DeleteFacilities(int id)
        {
            var facilities = await _context.Facilities.FindAsync(id);
            if (facilities == null)
            {
                return NotFound();
            }

            _context.Facilities.Remove(facilities);
            await _context.SaveChangesAsync();

            return facilities;
        }

        private bool FacilitiesExists(int id)
        {
            return _context.Facilities.Any(e => e.FacilitiesId == id);
        }
    }
}
