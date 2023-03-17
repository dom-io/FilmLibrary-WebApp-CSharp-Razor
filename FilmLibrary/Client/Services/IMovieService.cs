namespace FilmLibrary.Client.Services
{
    public interface IMovieService
    {
        List<Movie> Movies { get; set; }
        List<UserRegister> Users { get; set; }
        Task GetUsers();
        Task GetMovies();
        Task<Movie> GetSingleMovie(int id);
        Task CreateMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(int id);
    }
}
