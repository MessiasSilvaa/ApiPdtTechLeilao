using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPdtTechLeilao.Data;
using ApiPdtTechLeilao.Models;

namespace ApiPdtTechLeilao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuctionImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ListarImagens")]
        public async Task<ActionResult<IEnumerable<AuctionImage>>> GetAuctionImages()
        {
            return await _context.AuctionImages.ToListAsync();
        }

        [HttpGet("ListarImagensPor{id}")]
        public async Task<ActionResult<AuctionImage>> GetAuctionImage(int id)
        {
            var auctionImage = await _context.AuctionImages.FindAsync(id);

            if (auctionImage == null)
            {
                return NotFound();
            }

            return auctionImage;
        }

        [HttpPost("AdicionarImagem")]
        public async Task<ActionResult<AuctionImage>> PostAuctionImage(AuctionImage auctionImage)
        {
            _context.AuctionImages.Add(auctionImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuctionImage), new { id = auctionImage.Id }, auctionImage);
        }

        [HttpPut("AtualizarImagemPor{id}")]
        public async Task<IActionResult> PutAuctionImage(int id, AuctionImage auctionImage)
        {
            if (id != auctionImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(auctionImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionImageExists(id))
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

        [HttpDelete("DeletarImagemPor{id}")]
        public async Task<IActionResult> DeleteAuctionImage(int id)
        {
            var auctionImage = await _context.AuctionImages.FindAsync(id);
            if (auctionImage == null)
            {
                return NotFound();
            }

            _context.AuctionImages.Remove(auctionImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuctionImageExists(int id)
        {
            return _context.AuctionImages.Any(e => e.Id == id);
        }
    }
}
