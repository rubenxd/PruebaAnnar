using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalApi.Context;
using HospitalApi.Model;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class generoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public generoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/genero
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_genero>>> Gettbl_genero()
        {
            return await _context.tbl_genero.ToListAsync();
        }

        // GET: api/genero/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_genero>> Gettbl_genero(int id)
        {
            var tbl_genero = await _context.tbl_genero.FindAsync(id);

            if (tbl_genero == null)
            {
                return NotFound();
            }

            return tbl_genero;
        }

        // PUT: api/genero/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_genero(int id, tbl_genero tbl_genero)
        {
            if (id != tbl_genero.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_genero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_generoExists(id))
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

        // POST: api/genero
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_genero>> Posttbl_genero(tbl_genero tbl_genero)
        {
            _context.tbl_genero.Add(tbl_genero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_genero", new { id = tbl_genero.Id }, tbl_genero);
        }

        // DELETE: api/genero/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_genero(int id)
        {
            var tbl_genero = await _context.tbl_genero.FindAsync(id);
            if (tbl_genero == null)
            {
                return NotFound();
            }

            _context.tbl_genero.Remove(tbl_genero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_generoExists(int id)
        {
            return _context.tbl_genero.Any(e => e.Id == id);
        }
    }
}
