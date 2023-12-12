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
    public class HospitalsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public HospitalsController(HospitalDbContext context)
        {
            _context = context;
        }
        // GET: api/Hospitals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospital>>> GetHospitals()
        {
            return await _context.Hospitals.ToListAsync();
        }

        // GET api/Hospitals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hospital>> GetHospital(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);

            if (hospital == null)
            {
                return NotFound();
            }

            return hospital;
        }

        // POST api/Hospitals
        [HttpPost]
        public async Task<ActionResult<Hospital>> PostHospital(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospital", new { id = hospital.HospitalId }, hospital);
        }

        // PUT api/Hospitals/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Hospital>> PutHospital(int id, Hospital hospital)
        {
            if (id != hospital.HospitalId)
            {
                return BadRequest();
            }

            _context.Entry(hospital).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExists(id))
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

        // DELETE api/Hospitals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hospital>> DeleteHospital(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }

            _context.Hospitals.Remove(hospital);
            await _context.SaveChangesAsync();

            return hospital;
        }

        private bool HospitalExists(int id)
        {
            return _context.Hospitals.Any(e => e.HospitalId == id);
        }
    }
}
