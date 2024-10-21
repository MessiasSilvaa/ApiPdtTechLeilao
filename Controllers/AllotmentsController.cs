using ApiPdtTechLeilao.Data;
using ApiPdtTechLeilao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPdtTechLeilao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllotmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AllotmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ListarLotes")]
        public async Task<ActionResult<IEnumerable<Allotment>>> GetAllotments()
        {
            return await _context.Allotments.ToListAsync();
        }

        [HttpGet("ListarLotesPor{id}")]
        public async Task<ActionResult<Allotment>> GetAllotment(int id)
        {
            var allotment = await _context.Allotments.FindAsync(id);

            if (allotment == null)
            {
                return NotFound();
            }

            return allotment;
        }

        [HttpPost("AdicionarLote")]
        public async Task<ActionResult<Allotment>> PostAllotment(Allotment allotment)
        {
            _context.Allotments.Add(allotment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllotment), new { id = allotment.Id }, allotment);
        }

        [HttpPut("AtualizarLotePor{id}")]
        public async Task<IActionResult> PutAllotment(int id, Allotment allotment)
        {
            if (id != allotment.Id)
            {
                return BadRequest();
            }

            _context.Entry(allotment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllotmentExists(id))
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

        [HttpDelete("DeletarLotePor{id}")]
        public async Task<IActionResult> DeleteAllotment(int id)
        {
            var allotment = await _context.Allotments.FindAsync(id);
            if (allotment == null)
            {
                return NotFound();
            }

            _context.Allotments.Remove(allotment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllotmentExists(int id)
        {
            return _context.Allotments.Any(e => e.Id == id);
        }
    }
}
