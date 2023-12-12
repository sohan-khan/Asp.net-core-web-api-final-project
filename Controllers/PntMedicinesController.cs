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
    public class PntMedicinesController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public PntMedicinesController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/PntMedicines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PntMedicine>>> GetPntMedicines()
        {
            return await _context.PntMedicines.ToListAsync();
        }

        // GET: api/PntMedicines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PntMedicine>> GetPntMedicine(int id)
        {
            var pntMedicine = await _context.PntMedicines.FindAsync(id);

            if (pntMedicine == null)
            {
                return NotFound();
            }

            return pntMedicine;
        }

        // PUT: api/PntMedicines/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPntMedicine(int id, PntMedicine pntMedicine)
        {
            if (id != pntMedicine.PntMedicineId)
            {
                return BadRequest();
            }

            _context.Entry(pntMedicine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PntMedicineExists(id))
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

        // POST: api/PntMedicines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PntMedicine>> PostPntMedicine(PntMedicine pntMedicine)
        {
            _context.PntMedicines.Add(pntMedicine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPntMedicine", new { id = pntMedicine.PntMedicineId }, pntMedicine);
        }

        // DELETE: api/PntMedicines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PntMedicine>> DeletePntMedicine(int id)
        {
            var pntMedicine = await _context.PntMedicines.FindAsync(id);
            if (pntMedicine == null)
            {
                return NotFound();
            }

            _context.PntMedicines.Remove(pntMedicine);
            await _context.SaveChangesAsync();

            return pntMedicine;
        }

        private bool PntMedicineExists(int id)
        {
            return _context.PntMedicines.Any(e => e.PntMedicineId == id);
        }
    }
}
