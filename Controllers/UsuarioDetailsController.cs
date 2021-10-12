using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreAngularAPI.Models;

namespace EFCoreAngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioDetailsController : ControllerBase
    {
        private readonly UsuarioDetailContext _context;

        public UsuarioDetailsController(UsuarioDetailContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDetail>>> GetUsuarioDetails()
        {
            return await _context.UsuarioDetails.ToListAsync();
        }

        // GET: api/UsuarioDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDetail>> GetUsuarioDetail(int id)
        {
            var usuarioDetail = await _context.UsuarioDetails.FindAsync(id);

            if (usuarioDetail == null)
            {
                return NotFound();
            }

            return usuarioDetail;
        }

        // PUT: api/UsuarioDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioDetail(int id, UsuarioDetail usuarioDetail)
        {
            if (id != usuarioDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioDetailExists(id))
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

        // POST: api/UsuarioDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioDetail>> PostUsuarioDetail(UsuarioDetail usuarioDetail)
        {
            _context.UsuarioDetails.Add(usuarioDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioDetail", new { id = usuarioDetail.Id }, usuarioDetail);
        }

        // DELETE: api/UsuarioDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioDetail(int id)
        {
            var usuarioDetail = await _context.UsuarioDetails.FindAsync(id);
            if (usuarioDetail == null)
            {
                return NotFound();
            }

            _context.UsuarioDetails.Remove(usuarioDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioDetailExists(int id)
        {
            return _context.UsuarioDetails.Any(e => e.Id == id);
        }
    }
}
