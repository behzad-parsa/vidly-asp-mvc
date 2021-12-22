using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
         public short NumberInStock { get; set; }
        [Range(1,20)]
        public short NumberAvailable { get; set; }

        [Required]
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }

    }
}