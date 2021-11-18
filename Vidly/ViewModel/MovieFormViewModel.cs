using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
       
        public IEnumerable<Genre> Genres { get; set; }

        //public Movie Movie { get; set; }
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }



        [Range(1, 20)]
        [Required]
        [Display(Name = "Number In Stock")]
        public short? NumberInStock { get; set; }


        //Foriegn KEY
        [Display(Name = "Genre Type")]
        [Required]
        public byte? GenreId { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;

        }
    }
}