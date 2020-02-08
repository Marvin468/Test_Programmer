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
    public class ProfilesController : ControllerBase
    {
        private readonly DB_A54FC5_BDApptestsContext _context;

        public ProfilesController(DB_A54FC5_BDApptestsContext context)
        {
            _context = context;
        }

        // GET: api/Profiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profiles>>> GetProfiles()
        {
            return await _context.Profiles.ToListAsync();
        }

        // GET: api/Profiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profiles>> GetProfiles(int id)
        {
            var profiles = await _context.Profiles.FindAsync(id);

            if (profiles == null)
            {
                return NotFound();
            }

            return profiles;
        }

        // PUT: api/Profiles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfiles(int id, Profiles profiles)
        {
            if (id != profiles.ProfileId)
            {
                return BadRequest();
            }

            _context.Entry(profiles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfilesExists(id))
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

        // POST: api/Profiles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Profiles>> PostProfiles(Profiles profiles)
        {
            _context.Profiles.Add(profiles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfiles", new { id = profiles.ProfileId }, profiles);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Profiles>> DeleteProfiles(int id)
        {
            var profiles = await _context.Profiles.FindAsync(id);
            if (profiles == null)
            {
                return NotFound();
            }

            _context.Profiles.Remove(profiles);
            await _context.SaveChangesAsync();

            return profiles;
        }

        private bool ProfilesExists(int id)
        {
            return _context.Profiles.Any(e => e.ProfileId == id);
        }
    }
}
