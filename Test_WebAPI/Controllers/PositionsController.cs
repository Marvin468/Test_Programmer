using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_WebAPI.Models;

namespace Test_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly DB_A54FC5_BDApptestsContext _context;

        public PositionsController(DB_A54FC5_BDApptestsContext context)
        {
            _context = context;
        }

        // GET: api/Positions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Positions>>> GetPositions()
        {
            return await _context.Positions.ToListAsync();
        }

        // GET: api/Positions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Positions>> GetPositions(int id)
        {
            var positions = await _context.Positions.FindAsync(id);

            if (positions == null)
            {
                return NotFound();
            }

            return positions;
        }

        // PUT: api/Positions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPositions(int id, Positions positions)
        {
            if (id != positions.PositionId)
            {
                return BadRequest();
            }

            _context.Entry(positions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionsExists(id))
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

        // POST: api/Positions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Positions>> PostPositions(Positions positions)
        {
            _context.Positions.Add(positions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPositions", new { id = positions.PositionId }, positions);
        }

        // DELETE: api/Positions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Positions>> DeletePositions(int id)
        {
            var positions = await _context.Positions.FindAsync(id);
            if (positions == null)
            {
                return NotFound();
            }

            _context.Positions.Remove(positions);
            await _context.SaveChangesAsync();

            return positions;
        }

        private bool PositionsExists(int id)
        {
            return _context.Positions.Any(e => e.PositionId == id);
        }
    }
}
