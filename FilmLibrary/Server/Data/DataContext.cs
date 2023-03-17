namespace FilmLibrary.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRegister>().HasData(
                new UserRegister { Id = 1, Username = "Dom", Password = "123456" },
                new UserRegister { Id = 2, Username = "John", Password = "1234567" }
                );

            modelBuilder.Entity<Movie>().HasData(
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
                }
                );
        }

        public DbSet<UserRegister> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}
