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
    public class AppoinmentsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public AppoinmentsController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/Appoinments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appoinment>>> GetAppoinments()
        {
            return await _context.Appoinments.ToListAsync();
        }

        // GET: api/Appoinments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appoinment>> GetAppoinment(int id)
        {
            var appoinment = await _context.Appoinments.FindAsync(id);

            if (appoinment == null)
            {
                return NotFound();
            }

            return appoinment;
        }

        // PUT: api/Appoinments/5
      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppoinment(int id, Appoinment appoinment)
        {
            if (id != appoinment.AppoinmentId)
            {
                return BadRequest();
            }

            _context.Entry(appoinment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppoinmentExists(id))
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

        // POST: api/Appoinments
        
        [HttpPost]
        public async Task<ActionResult<Appoinment>> PostAppoinment(Appoinment appoinment)
        {
            _context.Appoinments.Add(appoinment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppoinment", new { id = appoinment.AppoinmentId }, appoinment);
        }

        // DELETE: api/Appoinments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appoinment>> DeleteAppoinment(int id)
        {
            var appoinment = await _context.Appoinments.FindAsync(id);
            if (appoinment == null)
            {
                return NotFound();
            }

            _context.Appoinments.Remove(appoinment);
            await _context.SaveChangesAsync();

            return appoinment;
        }

        private bool AppoinmentExists(int id)
        {
            return _context.Appoinments.Any(e => e.AppoinmentId == id);
        }
    }
}
