using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenCodeAlong.Data;
using ExamenCodeAlong.Models;

namespace ExamenCodeAlong.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VestigingenController : ControllerBase
    {
        private readonly EhelpBContext _context;

        public VestigingenController(EhelpBContext context)
        {
            _context = context;
        }

        // GET: api/Vestigingen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vestiging>>> GetVestigingen()
        {
          if (_context.Vestigingen == null)
          {
              return NotFound();
          }
            return await _context.Vestigingen.ToListAsync();
        }

        // GET: api/Vestigingen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vestiging>> GetVestiging(int id)
        {
          if (_context.Vestigingen == null)
          {
              return NotFound();
          }
            var vestiging = await _context.Vestigingen.FindAsync(id);

            if (vestiging == null)
            {
                return NotFound();
            }

            return vestiging;
        }

        // PUT: api/Vestigingen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVestiging(int id, Vestiging vestiging)
        {
            if (id != vestiging.Id)
            {
                return BadRequest();
            }

            _context.Entry(vestiging).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VestigingExists(id))
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

        // POST: api/Vestigingen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vestiging>> PostVestiging(Vestiging vestiging)
        {
          if (_context.Vestigingen == null)
          {
              return Problem("Entity set 'EhelpBContext.Vestigingen'  is null.");
          }
            _context.Vestigingen.Add(vestiging);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVestiging", new { id = vestiging.Id }, vestiging);
        }

        // DELETE: api/Vestigingen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVestiging(int id)
        {
            if (_context.Vestigingen == null)
            {
                return NotFound();
            }
            var vestiging = await _context.Vestigingen.FindAsync(id);
            if (vestiging == null)
            {
                return NotFound();
            }

            _context.Vestigingen.Remove(vestiging);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VestigingExists(int id)
        {
            return (_context.Vestigingen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
