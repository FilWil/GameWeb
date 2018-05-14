namespace GameWeb.Models.Game
{
    public class GameDetail
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public int Rating { get; set; }
        public int ReleaseYear { get; set; }
        public string ImageUrl { get; set; }
    }
}