using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tots.Context;
using tots.dtos;
using tots.Models;

namespace tots.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public TotsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var tots = await context.Tots.ToListAsync();
            return Ok(tots);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var tot = await context.Tots.FindAsync(id);
            if (tot == null)
            {
                return BadRequest($"No Tot with Id {id}");
            }
            return Ok(tot);
        }
        [HttpGet("title")]
        public async Task<IActionResult> GetByTitleAsync(string title)
        {
            var tot = await context.Tots.SingleOrDefaultAsync(g => g.Title == title);
            if (tot == null)
            {
                return BadRequest($"No Tots with name {title}");
            }
            return Ok(tot);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] Totdto dto)
        {
            var genre = await context.Genres.SingleOrDefaultAsync(g => g.Name == dto.GenreName);
            if (genre == null)
            {
                return BadRequest($"No Genres with name {dto.GenreName}");
            }
            var tot = new Tot
            {
                Title = dto.Title,
                Genre = genre,
                GenreId = genre.Id,
                article = dto.article,
                TottedOn = DateTime.Now
            };
            await context.AddAsync(tot);
            context.SaveChanges();
            return Ok(tot.Id);
        }

        [HttpPut("id")]
        public async Task<IActionResult> EditAsync([FromForm] Totdto dto,int id)
        {
            var genre = await context.Genres.SingleOrDefaultAsync(g => g.Name == dto.GenreName);
            if (genre == null)
            {
                return BadRequest($"No Genres with name {dto.GenreName}");
            }
            var tot = await context.Tots.FindAsync(id);
            if (tot == null)
            {
                return BadRequest($"No Tots with id {id}");
            }
            tot.Title = dto.Title;
            tot.Genre = genre;
            tot.GenreId = genre.Id;
            tot.article = dto.article;
            tot.TottedOn = DateTime.Now;
            context.Update(tot);
            context.SaveChanges();
            return Ok(tot.Id);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync([FromForm] int id)
        {
            var tot = await context.Tots.FindAsync(id);
            if (tot == null)
            {
                return BadRequest($"No Tots with Id {id}");
            }
            context.Remove(tot);
            context.SaveChanges();
            return Ok();
        }
    }
}
