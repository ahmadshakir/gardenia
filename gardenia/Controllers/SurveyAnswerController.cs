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
    public class SurveyAnswerController : ControllerBase
    {
        private readonly SurveyContext _context;

        public SurveyAnswerController(SurveyContext context)
        {
            _context = context;
        }

        // GET: api/SurveyAnswer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyAnswer>>> GetSurveyAnswers()
        {
            return await _context.SurveyAnswers.ToListAsync();
        }

        // GET: api/SurveyAnswer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyAnswer>> GetSurveyAnswer(int id)
        {
            var surveyAnswer = await _context.SurveyAnswers.FindAsync(id);

            if (surveyAnswer == null)
            {
                return NotFound();
            }

            return surveyAnswer;
        }

        // PUT: api/SurveyAnswer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurveyAnswer(int id, SurveyAnswer surveyAnswer)
        {
            if (id != surveyAnswer.Id)
            {
                return BadRequest();
            }

            _context.Entry(surveyAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyAnswerExists(id))
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

        // POST: api/SurveyAnswer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SurveyAnswer>> PostSurveyAnswer(SurveyAnswer surveyAnswer)
        {
            _context.SurveyAnswers.Add(surveyAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSurveyAnswer", new { id = surveyAnswer.Id }, surveyAnswer);
        }

        // DELETE: api/SurveyAnswer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurveyAnswer(int id)
        {
            var surveyAnswer = await _context.SurveyAnswers.FindAsync(id);
            if (surveyAnswer == null)
            {
                return NotFound();
            }

            _context.SurveyAnswers.Remove(surveyAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SurveyAnswerExists(int id)
        {
            return _context.SurveyAnswers.Any(e => e.Id == id);
        }
    }
}
