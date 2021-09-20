using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallengeService.Data;
using CodeChallengeService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeChallengeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PublicacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Publicacioness
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publicaciones>>> GetPublicacioness()
        {
            return await _context.Publicacioness.ToListAsync();
        }

        // GET: api/Publicacioness/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publicaciones>> GetPublicaciones(int id)
        {
            var Publicaciones = await _context.Publicacioness.FindAsync(id);

            if (Publicaciones == null)
            {
                return NotFound();
            }

            return Publicaciones;
        }

        // PUT: api/Publicacioness/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicaciones(int id, Publicaciones Publicaciones)
        {
            if (id != Publicaciones.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(Publicaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionesExists(id))
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

        // POST: api/Publicacioness
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publicaciones>> PostPublicaciones(Publicaciones Publicaciones)
        {
            _context.Publicacioness.Add(Publicaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicaciones", new { id = Publicaciones.Codigo }, Publicaciones);
        }

        // DELETE: api/Publicacioness/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicaciones(int id)
        {
            var Publicaciones = await _context.Publicacioness.FindAsync(id);
            if (Publicaciones == null)
            {
                return NotFound();
            }

            _context.Publicacioness.Remove(Publicaciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicacionesExists(int id)
        {
            return _context.Publicacioness.Any(e => e.Codigo == id);
        }
    }
}
