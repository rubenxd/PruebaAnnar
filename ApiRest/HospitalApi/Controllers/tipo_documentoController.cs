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
    public class tipo_documentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public tipo_documentoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tipo_documento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_tipo_documento>>> Gettbl_tipo_documento()
        {
            return await _context.tbl_tipo_documento.ToListAsync();
        }

        // GET: api/tipo_documento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_tipo_documento>> Gettbl_tipo_documento(int id)
        {
            var tbl_tipo_documento = await _context.tbl_tipo_documento.FindAsync(id);

            if (tbl_tipo_documento == null)
            {
                return NotFound();
            }

            return tbl_tipo_documento;
        }

        // PUT: api/tipo_documento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_tipo_documento(int id, tbl_tipo_documento tbl_tipo_documento)
        {
            if (id != tbl_tipo_documento.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_tipo_documento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_tipo_documentoExists(id))
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

        // POST: api/tipo_documento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_tipo_documento>> Posttbl_tipo_documento(tbl_tipo_documento tbl_tipo_documento)
        {
            _context.tbl_tipo_documento.Add(tbl_tipo_documento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_tipo_documento", new { id = tbl_tipo_documento.Id }, tbl_tipo_documento);
        }

        // DELETE: api/tipo_documento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_tipo_documento(int id)
        {
            var tbl_tipo_documento = await _context.tbl_tipo_documento.FindAsync(id);
            if (tbl_tipo_documento == null)
            {
                return NotFound();
            }

            _context.tbl_tipo_documento.Remove(tbl_tipo_documento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_tipo_documentoExists(int id)
        {
            return _context.tbl_tipo_documento.Any(e => e.Id == id);
        }
    }
}
