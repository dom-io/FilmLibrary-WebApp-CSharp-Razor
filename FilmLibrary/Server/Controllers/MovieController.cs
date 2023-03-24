using FilmLibrary.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public MovieController(ApplicationDBContext context)
        {
           _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movs = await _context.Movies.ToListAsync();
            return Ok(movs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mov = await _context.Movies.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(mov);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Movie movie)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return Ok(movie.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mov = new Movie { Id = id };
            _context.Remove(mov);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
