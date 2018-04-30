using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameWeb;
using GameWeb.Data;
using GameWeb.Models;

namespace GameWeb.Services
{
    public class GameService : IGames
    {
        private ApplicationDbContext _context;

        public GameService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games;
        }

        public Game GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(game => game.Id == id);
        }

        public void Add(Game newGame)
        {
            _context.Add(newGame);
            _context.SaveChanges();
        }

        public string GetTitle(int id)
        {
            if (_context.Games.Any(game => game.Id == id))
            {
                return _context.Games.FirstOrDefault(game => game.Id == id)?.Title;
            }
            else return "";
        }

        public string GetGenre(int id)
        {
            if (_context.Games.Any(game => game.Id == id))
            {
                return _context.Games.FirstOrDefault(game => game.Id == id)?.Genre;
            }
            else return "";
        }

        public string GetPlatform(int id)
        {
            if (_context.Games.Any(game => game.Id == id))
            {
                return _context.Games.FirstOrDefault(game => game.Id == id)?.Platform;
            }
            else return "";
        }

        public int GetRating(int id)
        {
            if (_context.Games.Any(game => game.Id == id))
            {
                return _context.Games.FirstOrDefault(game => game.Id == id).Rating;
            }
            else return -1;
        }

        public int ReleaseYear(int id)
        {
            if (_context.Games.Any(game => game.Id == id))
            {
                return _context.Games.FirstOrDefault(game => game.Id == id).Rating;
            }
            else return -1;
        }
    }
}
