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
    public class estadoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public estadoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/estado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_estado>>> Gettbl_estado()
        {
            return await _context.tbl_estado.ToListAsync();
        }

        // GET: api/estado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_estado>> Gettbl_estado(int id)
        {
            var tbl_estado = await _context.tbl_estado.FindAsync(id);

            if (tbl_estado == null)
            {
                return NotFound();
            }

            return tbl_estado;
        }

        // PUT: api/estado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_estado(int id, tbl_estado tbl_estado)
        {
            if (id != tbl_estado.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_estadoExists(id))
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

        // POST: api/estado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_estado>> Posttbl_estado(tbl_estado tbl_estado)
        {
            _context.tbl_estado.Add(tbl_estado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_estado", new { id = tbl_estado.Id }, tbl_estado);
        }

        // DELETE: api/estado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_estado(int id)
        {
            var tbl_estado = await _context.tbl_estado.FindAsync(id);
            if (tbl_estado == null)
            {
                return NotFound();
            }

            _context.tbl_estado.Remove(tbl_estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_estadoExists(int id)
        {
            return _context.tbl_estado.Any(e => e.Id == id);
        }
    }
}
