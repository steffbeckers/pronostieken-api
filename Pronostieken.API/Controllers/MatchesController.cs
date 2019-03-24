using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronostieken.Data;
using Pronostieken.Models;

namespace Pronostieken.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly PronostiekenContext _context;

        public MatchesController(PronostiekenContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lists all Matches.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Match> GetMatches()
        {
            return _context.Matches;
        }

        /// <summary>
        /// Retrieves a specific Match by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatch([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var match = await _context.Matches.FindAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        /// <summary>
        /// Updates a specific Match by ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch([FromRoute] Guid id, [FromBody] Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != match.Id)
            {
                return BadRequest();
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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

        /// <summary>
        /// Creates a Match.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///       "name": "This is a test match",
        ///       "isComplete": false
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created Match</response>
        [HttpPost]
        public async Task<IActionResult> PostMatch([FromBody] Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatch", new { id = match.Id }, match);
        }

        /// <summary>
        /// Deletes a specific Match by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();

            return Ok(match);
        }

        private bool MatchExists(Guid id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}