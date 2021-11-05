using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPersonasBackEnd.Data;
using PersonalityProfilerDTO;

namespace MyPersonasBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tests
        [HttpGet]

        public async Task<ActionResult<List<TestResponse>>> GetTest()
        {
            var test = await _context.Test.AsTracking()
                //.Include(t => t.Type)
                .Include(t => t.TesteeTest)
                .ThenInclude(t => t.Testee)
                .Select(t => t.MapTestResponse())
                .ToListAsync();

            return test;
        }


        // GET: api/Tests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestResponse>> GetTest(int id)
        {
            var test = await _context.Test.AsTracking()
            .Include(t => t.TestQuestion)
            .ThenInclude(t => t.Questions)
            .SingleOrDefaultAsync(t => t.Id == id);

            if(test == null)
            {
                return NotFound();
            }


            return test.MapTestResponse();
        }

   


   
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest(int id, PersonalityProfilerDTO.Test tinput)
        {
            var mytest = await _context.Test.FindAsync(id);
            if (mytest == null)
            {
                return NotFound();
            }

            mytest.Id = tinput.Id;
            mytest.Type = tinput.Type;
            mytest.TestState = tinput.TestState;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<TestResponse>> PostTest(PersonalityProfilerDTO.Test tinput)
        {
            var mytest = new Data.Test
            {
                //Id = tinput.Id,
                DateTaken = tinput.DateTaken,
                TestState = tinput.TestState,
                Type = tinput.Type
            };

            _context.Test.Add(mytest);
            await _context.SaveChangesAsync();

            var output = mytest.MapTestResponse();

            return CreatedAtAction("GetTest", new { id = output.Id }, output);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestResponse>> DeleteTest(int id)
        {
            var test = await _context.Test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _context.Test.Remove(test);
            await _context.SaveChangesAsync();

            return test.MapTestResponse();
        }

        private bool TestExists(int id)
        {
            return _context.Test.Any(e => e.Id == id);
        }
    }
   
}
