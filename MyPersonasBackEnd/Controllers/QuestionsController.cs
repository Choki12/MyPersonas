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
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<List<QuestionsResponse>>> GetQuestions()
        {
            var questions = await _context.Questions.AsTracking()
              .Include(q => q.TestQuestion)
              .ThenInclude(q => q.Questions)
              .Select(q => q.MapQuestionsResponse())
              .ToListAsync();

            return questions;
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionsResponse>> GetQuestions(int id)
        {
            var questions = await _context.Questions.AsTracking()
            .Include(q => q.TestQuestion)
            .ThenInclude(q => q.Questions)
            .SingleOrDefaultAsync(q => q.Id == id);

            if (questions == null)
            {
                return NotFound();
            }

            return questions.MapQuestionsResponse();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, PersonalityProfilerDTO.Questions qinput)
        {
            var myquestions = await _context.Questions.FindAsync(id);
            if (myquestions == null)
            {
                return NotFound();
            }

            myquestions.Id = qinput.Id;
            myquestions.Number = qinput.Number;
            myquestions.State = qinput.State;
            myquestions.Answer = qinput.Answer;
            
            
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<QuestionsResponse>> PostTest(PersonalityProfilerDTO.Questions qinput)
        {
            var myquestions = new Data.Questions
    
            {
                //Id = tinput.Id,
                Question = qinput.Question,
                State = qinput.State,
                Number = qinput.Number,
                Answer = qinput.Answer,
                
            };

            _context.Questions.Add(myquestions);
            await _context.SaveChangesAsync();

            var output = myquestions.MapQuestionsResponse();

            return CreatedAtAction("GetTest", new { id = output.Id }, output);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestionsResponse>> DeleteTest(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return question.MapQuestionsResponse();
        }

        private bool TestExists(int id)
        {
            return _context.Test.Any(e => e.Id == id);
        }

    }
}
