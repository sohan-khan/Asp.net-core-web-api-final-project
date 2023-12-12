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
    public class MedicineListsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public MedicineListsController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicineLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicineList>>> GetMedicineLists()
        {
            return await _context.MedicineLists.ToListAsync();
        }

        // GET: api/MedicineLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicineList>> GetMedicineList(int id)
        {
            var medicineList = await _context.MedicineLists.FindAsync(id);

            if (medicineList == null)
            {
                return NotFound();
            }

            return medicineList;
        }

        // PUT: api/MedicineLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicineList(int id, MedicineList medicineList)
        {
            if (id != medicineList.MedicineListId)
            {
                return BadRequest();
            }

            _context.Entry(medicineList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineListExists(id))
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

        // POST: api/MedicineLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MedicineList>> PostMedicineList(MedicineList medicineList)
        {
            _context.MedicineLists.Add(medicineList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicineList", new { id = medicineList.MedicineListId }, medicineList);
        }

        // DELETE: api/MedicineLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicineList>> DeleteMedicineList(int id)
        {
            var medicineList = await _context.MedicineLists.FindAsync(id);
            if (medicineList == null)
            {
                return NotFound();
            }

            _context.MedicineLists.Remove(medicineList);
            await _context.SaveChangesAsync();

            return medicineList;
        }

        private bool MedicineListExists(int id)
        {
            return _context.MedicineLists.Any(e => e.MedicineListId == id);
        }
    }
}
