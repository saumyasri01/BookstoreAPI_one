namespace BookstoreAPI.Models
{
    public class Book
    {
        public int book_id { get; set; }
        public string title { get; set; }
        public int author_id { get; set; }
        public int genre_id { get; set; }
        public string isbn { get; set; }
        public decimal price { get; set; }
        public DateTime? publication_date { get; set; }
        public int stock_quantity { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}