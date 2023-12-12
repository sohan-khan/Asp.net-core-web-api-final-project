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
    public class InPtPrescriptionsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public InPtPrescriptionsController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/InPtPrescriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InPtPrescription>>> GetInPtPrescriptions()
        {
            return await _context.InPtPrescriptions.Include(p => p.PntMedicines).Include(p => p.PatientTests).ToListAsync();
        }

        // GET: api/InPtPrescriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InPtPrescription>> GetInPtPrescription(int? id)
        {
            InPtPrescription inPtPrescription;

            if (id is null)
            {
                inPtPrescription = await _context.InPtPrescriptions.Include(p => p.PntMedicines).Include(p => p.PatientTests).SingleOrDefaultAsync();

                if (inPtPrescription == null)
                {
                    return NotFound();
                }

                //var response = 

                return inPtPrescription;
            }
            else
            {
                inPtPrescription = await _context.InPtPrescriptions.Include(p => p.PntMedicines).Include(p => p.PatientTests).SingleAsync(p => p.InPtPrescriptionId == id);


                if (inPtPrescription == null)
                {
                    return NotFound();
                }

                return inPtPrescription;
            }
        }
    
        // PUT: api/InPtPrescriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInPtPrescription(int id, InPtPrescription inPtPrescription)
        {
            if (id != inPtPrescription.InPtPrescriptionId)
            {
                return BadRequest();
            }

            _context.Entry(inPtPrescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InPtPrescriptionExists(id))
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

        // POST: api/InPtPrescriptions
        [HttpPost]
        public async Task<ActionResult<InPtPrescription>> PostInPtPrescription(InPtPrescription inPtPrescription)
        {
            try
            {
                _context.Database.BeginTransaction();
                _context.InPtPrescriptions.Add(inPtPrescription);
                await _context.SaveChangesAsync();
                _context.Database.CommitTransaction();
                return CreatedAtAction("GetInPtPrescriptions", new { id = inPtPrescription.InPtPrescriptionId}, inPtPrescription);
            }
            catch (Exception)
            {
                _context.Database.RollbackTransaction();
                return CreatedAtAction("GetInPtPrescriptions", inPtPrescription);
            }

            return CreatedAtAction("GetInPtPrescription", new { id = inPtPrescription.InPtPrescriptionId }, inPtPrescription);
        }

        // DELETE: api/InPtPrescriptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InPtPrescription>> DeleteInPtPrescription(int id)
        {
            var inPtPrescription = await _context.InPtPrescriptions.FindAsync(id);
            if (inPtPrescription == null)
            {
                return NotFound();
            }

            _context.InPtPrescriptions.Remove(inPtPrescription);
            await _context.SaveChangesAsync();

            return inPtPrescription;
        }

        private bool InPtPrescriptionExists(int id)
        {
            return _context.InPtPrescriptions.Any(e => e.InPtPrescriptionId == id);
        }
    }
}
