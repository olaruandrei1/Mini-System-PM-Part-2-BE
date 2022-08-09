using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pmAPI;
using pmAPI.Data;

namespace pmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusHosController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusHosController(DataContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusHos>>> GetStatusesHos()
        {
          if (_context.StatusesHos == null)
          {
              return NotFound();
          }
            return await _context.StatusesHos.ToListAsync();
        }

        // GET by id
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusHos>> GetStatusHos(int id)
        {
          if (_context.StatusesHos == null)
          {
              return NotFound();
          }
            var statusHos = await _context.StatusesHos.FindAsync(id);

            if (statusHos == null)
            {
                return NotFound();
            }

            return statusHos;
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusHos(int id, StatusHos statusHos)
        {
            if (id != statusHos.id)
            {
                return BadRequest();
            }

            _context.Entry(statusHos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusHosExists(id))
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

        // POST
        [HttpPost]
        public async Task<ActionResult<StatusHos>> PostStatusHos(StatusHos statusHos)
        {
          if (_context.StatusesHos == null)
          {
              return Problem("Entity set 'DataContext.StatusesHos'  is null.");
          }
            _context.StatusesHos.Add(statusHos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusHos", new { id = statusHos.id }, statusHos);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusHos(int id)
        {
            if (_context.StatusesHos == null)
            {
                return NotFound();
            }
            var statusHos = await _context.StatusesHos.FindAsync(id);
            if (statusHos == null)
            {
                return NotFound();
            }

            _context.StatusesHos.Remove(statusHos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusHosExists(int id)
        {
            return (_context.StatusesHos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
