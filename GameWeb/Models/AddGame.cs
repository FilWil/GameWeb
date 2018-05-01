using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GameWeb.Models
{
    public class AddGame
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        [Range(1947,2030)]
        public int ReleaseYear { get; set; }
        public IFormFile GameAdd { get; set; }
    }
}
