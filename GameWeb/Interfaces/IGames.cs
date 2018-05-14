using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameWeb.Models.Game;
using Microsoft.WindowsAzure.Storage.Blob;

namespace GameWeb.Interfaces
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

        CloudBlobContainer GetBlobContainer(string connectionString, string containerName);
        Task SetGame(string title, string genre, string platform, int releaseYear, Uri uri);
    }
}