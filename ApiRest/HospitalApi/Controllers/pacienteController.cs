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
    public class pacienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public pacienteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/paciente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_paciente>>> Gettbl_paciente()
        {
            return await _context.tbl_paciente.ToListAsync();
        }

        // GET: api/paciente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_paciente>> Gettbl_paciente(int id)
        {
            var tbl_paciente = await _context.tbl_paciente.FindAsync(id);

            if (tbl_paciente == null)
            {
                return NotFound();
            }

            return tbl_paciente;
        }

        // PUT: api/paciente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_paciente(int id, tbl_paciente tbl_paciente)
        {
            if (id != tbl_paciente.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_pacienteExists(id))
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

        // POST: api/paciente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_paciente>> Posttbl_paciente(tbl_paciente tbl_paciente)
        {
            _context.tbl_paciente.Add(tbl_paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_paciente", new { id = tbl_paciente.Id }, tbl_paciente);
        }

        // DELETE: api/paciente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_paciente(int id)
        {
            var tbl_paciente = await _context.tbl_paciente.FindAsync(id);
            if (tbl_paciente == null)
            {
                return NotFound();
            }

            _context.tbl_paciente.Remove(tbl_paciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_pacienteExists(int id)
        {
            return _context.tbl_paciente.Any(e => e.Id == id);
        }
    }
}
