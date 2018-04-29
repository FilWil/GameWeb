using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWeb.Models;

namespace GameWeb
{
    public interface IGames
    {
        IEnumerable<Game> GetAll();
        Game GetById(int id);

        void Add(Game newGame);
        string GetTitle(int id);
        string GetGenre(int id);
        string GetPlatform(int id);
        int GetRating(int id);
        int ReleaseYear(int id);
    }
}
