using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWeb.Data;
using GameWeb.Interfaces;
using GameWeb.Models.Game;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace GameWeb.Services
{
    public class GameService : IGames
    {
        private readonly ApplicationDbContext _context;

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
                return _context.Games.FirstOrDefault(game => game.Id == id)?.Title;
            return "";
        }

        public string GetGenre(int id)
        {
            if (_context.Games.Any(game => game.Id == id))
                return _context.Games.FirstOrDefault(game => game.Id == id)?.Genre;
            return "";
        }

        public string GetPlatform(int id)
        {
            if (_context.Games.Any(game => game.Id == id))
                return _context.Games.FirstOrDefault(game => game.Id == id)?.Platform;
            return "";
        }

        public int GetRating(int id)
        {
            if (_context.Games.Any(game => game.Id == id))
                return _context.Games.FirstOrDefault(game => game.Id == id).Rating;
            return -1;
        }

        public int ReleaseYear(int id)
        {
            if (_context.Games.Any(game => game.Id == id))
                return _context.Games.FirstOrDefault(game => game.Id == id).Rating;
            return -1;
        }

        public CloudBlobContainer GetBlobContainer(string connectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            return blobClient.GetContainerReference(containerName);
        }

        public async Task SetGame(string title, string genre, string platform, int releaseYear, Uri uri)
        {
            var game = new Game
            {
                Title = title,
                Genre = genre,
                Platform = platform,
                ReleaseYear = releaseYear,
                ImageUrl = uri.AbsoluteUri
            };

            _context.Add(game);
            await _context.SaveChangesAsync();
        }
    }
}