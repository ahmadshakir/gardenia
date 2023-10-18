#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gardenia.Model;

namespace gardenia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyQuestionController : ControllerBase
    {
        private readonly SurveyContext _context;

        public SurveyQuestionController(SurveyContext context)
        {
            _context = context;
        }

        // GET: api/SurveyQuestion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyQuestion>>> GetSurveyQuestions()
        {
            return await _context.SurveyQuestions.ToListAsync();
        }

        // GET: api/SurveyQuestion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyQuestion>> GetSurveyQuestion(int id)
        {
            var surveyQuestion = await _context.SurveyQuestions.FindAsync(id);

            if (surveyQuestion == null)
            {
                return NotFound();
            }

            return surveyQuestion;
        }

        // PUT: api/SurveyQuestion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurveyQuestion(int id, SurveyQuestion surveyQuestion)
        {
            if (id != surveyQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(surveyQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyQuestionExists(id))
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

        // POST: api/SurveyQuestion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SurveyQuestion>> PostSurveyQuestion(SurveyQuestion surveyQuestion)
        {
            _context.SurveyQuestions.Add(surveyQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSurveyQuestion", new { id = surveyQuestion.Id }, surveyQuestion);
        }

        // DELETE: api/SurveyQuestion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurveyQuestion(int id)
        {
            var surveyQuestion = await _context.SurveyQuestions.FindAsync(id);
            if (surveyQuestion == null)
            {
                return NotFound();
            }

            _context.SurveyQuestions.Remove(surveyQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SurveyQuestionExists(int id)
        {
            return _context.SurveyQuestions.Any(e => e.Id == id);
        }
    }
}
