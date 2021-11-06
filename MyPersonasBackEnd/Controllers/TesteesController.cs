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

    //Remember to add authentication and response codes 
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
        /*
         * Changed the GetTestee Method to return a list, the class converts a testee into a list implicitly
         */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TesteeResponse>>> GetTestees()
        {
            //return await _context.Testees.ToListAsync();
            
            var testee = await _context.Testees.AsTracking()
               .Include(t => t.TesteeTest)
               .ThenInclude(tt => tt.Test)
               .Select(t => t.MapTesteeResponse())
               .ToListAsync();

            if (testee == null)
            {
                return NotFound();
            }

            return testee;
        }

        // GET: api/Testees/5
        [HttpGet("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult<TesteeResponse>> GetTestee(string username) 
        {
            var testee = await _context.Testees.Include(t => t.TesteeTest)
                                                .ThenInclude(tt => tt.Test)
                                                .SingleOrDefaultAsync(t => t.UserName == username);

            if(testee == null)
            {
                return NotFound();
            }

            return testee.MapTesteeResponse();

           
        }

        //Retrieving tests linked to a specific user
        [HttpGet("{username}/test")]
        public async Task<ActionResult<List<TestResponse>>> GetTest(string username)
        {
            var tests = await _context.Test.AsNoTracking()
                                           .Include(t => t.TestState)
                                           .Include(t => t.Type)
                                           .Include(t => t.TesteeTest)
                                           .ThenInclude(tt => tt.Testee)
                                           .Where(myT => myT.TesteeTest.Any(tt => tt.Testee.UserName == username))
                                           .Select(myTQ => myTQ.MapTestResponse())
                                           .ToListAsync();

            return tests;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<TesteeResponse>> Post(TesteeResponse uinput)
        {
            var TesteeExists = await _context.Testees
                .Where(tt => tt.UserName == uinput.UserName)
                .FirstOrDefaultAsync();

            if(TesteeExists != null)
            {
                return Conflict(uinput);
            }

            var Testee = new Data.Testee
            {
                Name = uinput.Name,
                Surname = uinput.Surname,
                UserName = uinput.UserName,
                Email = uinput.Email,
                DOB = uinput.DOB
            };

            _context.Testees.Add(Testee);
            await _context.SaveChangesAsync();

            var output = Testee.MapTesteeResponse();
            return CreatedAtAction("GetUser", new {username = output.UserName},output);
        }

        [HttpPost("{username}/test/{testId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TesteeResponse>> AddTest(string username, int testId)
        {
            var mytestee = await _context.Testees.Include(t => t.TesteeTest)
                                                 .ThenInclude(tt => tt.Test)
                                                 .SingleOrDefaultAsync(tt => tt.UserName == username);


            if(mytestee == null)
            {
                return NotFound();
            }

            var mytest = await _context.Test.FindAsync(testId);

            if(mytest == null)
            {
                return BadRequest();
            }

            mytestee.TesteeTest.Add(new TesteeTest
            {
                TesteeId = mytestee.Id,
                TestId = testId

            });

            await _context.SaveChangesAsync();


            return mytestee.MapTesteeResponse();
        }



        [HttpDelete("{username}/test/{testId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteTest(string username, int testId)
        {
            var mytestee = await _context.Testees.Include(t => t.TesteeTest)
                                                 .SingleOrDefaultAsync(t => t.UserName == username);

            if(mytestee == null)
            {
                return NotFound();
            }

            var mytest = await _context.Test.FindAsync(testId);

            if(mytest == null)
            {
                return BadRequest();
            }

            var myTesteeTest = mytestee.TesteeTest.FirstOrDefault(t => t.TestId == testId);
            mytestee.TesteeTest.Remove(myTesteeTest);

            await _context.SaveChangesAsync();

            return NoContent();
        }





    }
}
