using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLiteTest;
using SQLiteTest.Models;

namespace SQLiteTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnswersController : ControllerBase
    {
        private readonly DataContext _context;

        public UserAnswersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UserAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAnswers>>> GetUserAnswers()
        {
            return await _context.UserAnswers.Include(k=> k.Answer).Include(k=>k.User).ToListAsync();
        }

        // GET: api/UserAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAnswers>> GetUserAnswers(int id)
        {
            var userAnswers = await _context.UserAnswers.Include(k=>k.Answer).Include(k=>k.User).FirstOrDefaultAsync(k=>  k.Id == id);

            if (userAnswers == null)
            {
                return NotFound();
            }

            return userAnswers;
        }

        // PUT: api/UserAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAnswers(int id, UserAnswers userAnswers)
        {
            if (id != userAnswers.AnswerID)
            {
                return BadRequest();
            }

            _context.Entry(userAnswers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAnswersExists(id))
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

        // POST: api/UserAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAnswers>> PostUserAnswers(UserAnswers userAnswers)
        {
            _context.UserAnswers.Add(userAnswers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserAnswersExists(userAnswers.AnswerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserAnswers", new { id = userAnswers.AnswerID }, userAnswers);
        }

        // DELETE: api/UserAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAnswers(int id)
        {
            var userAnswers = await _context.UserAnswers.FindAsync(id);
            if (userAnswers == null)
            {
                return NotFound();
            }

            _context.UserAnswers.Remove(userAnswers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAnswersExists(int id)
        {
            return _context.UserAnswers.Any(e => e.AnswerID == id);
        }
    }
}
