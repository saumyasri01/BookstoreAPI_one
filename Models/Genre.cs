namespace BookstoreAPI.Models
{
    public class Genre
    {
        public int genre_id { get; set; }
        public string genre_name { get; set; }
        public string description { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}