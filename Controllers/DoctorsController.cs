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
    public class DoctorsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public DoctorsController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctors>>> GetDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctors>> GetDoctors(int id)
        {
            var doctors = await _context.Doctors.FindAsync(id);

            if (doctors == null)
            {
                return NotFound();
            }

            return doctors;
        }

        // PUT: api/Doctors/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctors(int id, Doctors doctors)
        {
            if (id != doctors.DoctorsId)
            {
                return BadRequest();
            }

            _context.Entry(doctors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorsExists(id))
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

        // POST: api/Doctors
       
        [HttpPost]
        public async Task<ActionResult<Doctors>> PostDoctors(Doctors doctors)
        {
            _context.Doctors.Add(doctors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctors", new { id = doctors.DoctorsId }, doctors);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctors>> DeleteDoctors(int id)
        {
            var doctors = await _context.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctors);
            await _context.SaveChangesAsync();

            return doctors;
        }

        private bool DoctorsExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorsId == id);
        }
    }
}
