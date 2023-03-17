using Microsoft.AspNetCore.Mvc;

namespace FilmLibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly DataContext _context;

        public MovieController(DataContext context)
        {
            _context = context;
        }

        public static List<UserRegister> users = new List<UserRegister>
        {
            new UserRegister { Id = 1, Username = "Dom", Password = "123456" },
            new UserRegister { Id = 2, Username = "John", Password = "1234567" }
        };

        public static List<Movie> movies = new List<Movie> {
                new Movie
                {
                    Id = 1,
                    Title = "Jaws",
                    Director = "Steven Spielberg",
                    ReleaseYear = "1975",
                },

                new Movie
                {
                    Id = 2,
                    Title = "Aliens",
                    Director = "James Cameron",
                    ReleaseYear = "1986",
                },
            };

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetsingleMovie(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.UserId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound("Sorry, no movie here.");
            }
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> CreateMovie(Movie movie)
        {
            movie.UserId = null;
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return Ok(await GetDbMovies());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Movie>>> UpdateMovie(Movie movie, int id)
        {
            var dbMovie = await _context.Movies
                .Include(mv => mv.UserId)
                .FirstOrDefaultAsync(mv => mv.Id == id);
            if (dbMovie == null)
                return NotFound("Sorry, no movie for you.");

            dbMovie.Title = movie.Title;
            dbMovie.Director = movie.Director;
            dbMovie.ReleaseYear = movie.ReleaseYear;
            dbMovie.Id = movie.MovieId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbMovies());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Movie>>> DeleteMovie(Movie movie, int id)
        {
            var dbMovie = await _context.Movies
                .Include(mv => mv.UserId)
                .FirstOrDefaultAsync(mv => mv.Id == id);
            if (dbMovie == null)
                return NotFound("Sorry, no movie for you.");

            _context.Movies.Remove(dbMovie);

            await _context.SaveChangesAsync();

            return Ok(await GetDbMovies());
        }

        private async Task<List<Movie>> GetDbMovies()
        {
            return await _context.Movies.Include(sh => sh.UserId).ToListAsync();
        }
    }
}
