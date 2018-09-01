using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DotNetCoreSwaggerImp.Controllers
{
    [Route("api/personalinfo")]
    [ApiController]
    public class PersonalInfoesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public PersonalInfoesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/PersonalInfoes
        [HttpGet]
        [Route("GetPersonalInfo")]
        public IEnumerable<PersonalInfo> GetPersonalInfo()
        {
            try
            {
                var result = _context.PersonalInfo.ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: api/PersonalInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalInfo([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalInfo = await _context.PersonalInfo.FindAsync(id);

            if (personalInfo == null)
            {
                return NotFound();
            }

            return Ok(personalInfo);
        }

        // PUT: api/PersonalInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalInfo([FromRoute] long id, [FromBody] PersonalInfo personalInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalInfo.PersonalInfoID)
            {
                return BadRequest();
            }

            _context.Entry(personalInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInfoExists(id))
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

        // POST: api/PersonalInfoes
        [HttpPost]
        public async Task<IActionResult> PostPersonalInfo([FromBody] PersonalInfo personalInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonalInfo.Add(personalInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalInfo", new { id = personalInfo.PersonalInfoID }, personalInfo);
        }

        // DELETE: api/PersonalInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalInfo([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalInfo = await _context.PersonalInfo.FindAsync(id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            _context.PersonalInfo.Remove(personalInfo);
            await _context.SaveChangesAsync();

            return Ok(personalInfo);
        }

        private bool PersonalInfoExists(long id)
        {
            return _context.PersonalInfo.Any(e => e.PersonalInfoID == id);
        }
    }
}