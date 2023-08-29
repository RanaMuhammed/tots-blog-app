using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using tots.Context;
using tots.dtos;
using tots.Models;

namespace tots.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public GenresController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await context.Genres.ToListAsync();
            return Ok(genres);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var genre = await context.Genres.FindAsync(id);
            if (genre == null) {
                return BadRequest($"No Genres with Id {id}");
            }
            return Ok(genre);
        }
        [Authorize]
        [HttpGet("genreid")]
        public async Task<IActionResult> GetAlltotsAsync(int id)
        {
            var genre = await context.Genres.FindAsync(id);
            if (genre == null)
            {
                return BadRequest($"No Genres with Id {id}");
            }
            var tots = await context.Tots.Where(t=>t.GenreId == id).ToListAsync();
            return Ok(tots);
        }
        [Authorize]
        [HttpGet("name")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var genre = await context.Genres.SingleOrDefaultAsync(g=>g.Name == name);   
            if (genre == null)
            {
                return BadRequest($"No Genres with name {name}");
            }
            return Ok(genre);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]Genredto dto)
        {
            var genre = new Genre
            {
                Name = dto.Name,
                Track = dto.Track
            };
            await context.AddAsync(genre);
            context.SaveChanges();
            return Ok(genre.Id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("id")]
        public async Task<IActionResult> EditAsync([FromForm] Genredto dto, int id)
        {
            var genre = await context.Genres.FindAsync(id);
            if (genre == null)
            {
                return BadRequest($"No Genres with Id {id}");
            }
            genre.Name = dto.Name;
            genre.Track = dto.Track;
            context.Update(genre);
            context.SaveChanges();
            return Ok(genre.Id);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync([FromForm] int id)
        {
            var genre = await context.Genres.FindAsync(id);
            if (genre == null)
            {
                return BadRequest($"No Genres with Id {id}");
            }
            context.Remove(genre);
            context.SaveChanges();
            return Ok();
        }
    }
}
