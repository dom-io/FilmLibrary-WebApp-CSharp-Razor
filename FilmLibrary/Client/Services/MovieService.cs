using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FilmLibrary.Client.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public MovieService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<UserRegister> Users { get; set; } = new List<UserRegister>();

        public async Task CreateMovie(Movie movie)
        {
            var result = await _http.PostAsJsonAsync("api/movie", movie);
            await SetMovies(result);
        }

        private async Task SetMovies(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Movie>>();
            Movies = response; 
            _navigationManager.NavigateTo("mylist");
        }


        public async Task DeleteMovie(int id)
        {
            var result = await _http.DeleteAsync($"api/movie{id}");
            var response = await result.Content.ReadFromJsonAsync<List<Movie>>();
            await SetMovies(result);
        }

        public async Task GetUsers()
        {
            var result = await _http.GetFromJsonAsync<List<UserRegister>>("api/movie/users");
            if (result != null) 
                Users = result;
        }

        public async Task<Movie> GetSingleMovie(int id)
        {
            var result = await _http.GetFromJsonAsync<Movie>($"api/movie/{id}");
            if (result != null)
                return result;
            throw new Exception("Movie not found.");
        }

        public async Task GetMovies()
        {
            var result = await _http.GetFromJsonAsync<List<Movie>>("api/movie");
            if (result != null)
                Movies = result;
        }

        public async Task UpdateMovie(Movie movie)
        {
            var result = await _http.PostAsJsonAsync($"api/movie/{movie.Id}", movie);
            var response = await result.Content.ReadFromJsonAsync<List<Movie>>();
            await SetMovies(result);
        }
    }
}
