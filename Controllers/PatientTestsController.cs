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
    public class PatientTestsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public PatientTestsController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/PatientTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientTest>>> GetPatientTests()
        {
            return await _context.PatientTests.ToListAsync();
        }

        // GET: api/PatientTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientTest>> GetPatientTest(int id)
        {
            var patientTest = await _context.PatientTests.FindAsync(id);

            if (patientTest == null)
            {
                return NotFound();
            }

            return patientTest;
        }

        // PUT: api/PatientTests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientTest(int id, PatientTest patientTest)
        {
            if (id != patientTest.PatientTestId)
            {
                return BadRequest();
            }

            _context.Entry(patientTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientTestExists(id))
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

        // POST: api/PatientTests
        [HttpPost]
        public async Task<ActionResult<PatientTest>> PostPatientTest(PatientTest patientTest)
        {
            _context.PatientTests.Add(patientTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientTest", new { id = patientTest.PatientTestId }, patientTest);
        }

        // DELETE: api/PatientTests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientTest>> DeletePatientTest(int id)
        {
            var patientTest = await _context.PatientTests.FindAsync(id);
            if (patientTest == null)
            {
                return NotFound();
            }

            _context.PatientTests.Remove(patientTest);
            await _context.SaveChangesAsync();

            return patientTest;
        }

        private bool PatientTestExists(int id)
        {
            return _context.PatientTests.Any(e => e.PatientTestId == id);
        }
    }
}
