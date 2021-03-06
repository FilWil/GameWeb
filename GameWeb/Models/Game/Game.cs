﻿using System.ComponentModel.DataAnnotations;

namespace GameWeb.Models.Game
{
    public class Game
    {
        public int Id { get; set; }

        [Required] public string Title { get; set; }

        [Required] public string Genre { get; set; }

        public string Platform { get; set; }

        public int Rating { get; set; }

        [Required] public int ReleaseYear { get; set; }

        public string ImageUrl { get; set; }
    }
}