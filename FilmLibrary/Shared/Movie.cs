using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Shared
{
    public class Movie
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Director { get; set; } = string.Empty;
        [Required]
        public string ReleaseYear { get; set; } = string.Empty;

        public int Id { get; set; }
        public UserRegister? UserId { get; set; }
        public int MovieId { get; set; }

    }
}
