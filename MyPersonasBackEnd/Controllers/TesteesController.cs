using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPersonasBackEnd.Data;

namespace MyPersonasBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TesteesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Testees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testee>>> GetTestees()
        {
            return await _context.Testees.ToListAsync();
        }

        // GET: api/Testees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Testee>> GetTestee(int id)
        {
            var testee = await _context.Testees.FindAsync(id);

            if (testee == null)
            {
                return NotFound();
            }

            return testee;
        }

        // PUT: api/Testees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestee(int id, Testee testee)
        {
            if (id != testee.Id)
            {
                return BadRequest();
            }

            _context.Entry(testee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TesteeExists(id))
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

        // POST: api/Testees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Testee>> PostTestee(Testee testee)
        {
            _context.Testees.Add(testee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestee", new { id = testee.Id }, testee);
        }

        // DELETE: api/Testees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Testee>> DeleteTestee(int id)
        {
            var testee = await _context.Testees.FindAsync(id);
            if (testee == null)
            {
                return NotFound();
            }

            _context.Testees.Remove(testee);
            await _context.SaveChangesAsync();

            return testee;
        }

        private bool TesteeExists(int id)
        {
            return _context.Testees.Any(e => e.Id == id);
        }
    }
}
