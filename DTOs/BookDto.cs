namespace BookstoreAPI.DTOs
{
  public class BookDto
{
    public int book_id { get; set; }
    public string title { get; set; }
    public int author_id { get; set; }
        public string author_name { get; set; }  // New field
        public int genre_id { get; set; }
        public string genre_name { get; set; }  // New field
        public string isbn { get; set; }
    public decimal price { get; set; }
    public DateTime? publication_date { get; set; }
    public int stock_quantity { get; set; }
}
}

