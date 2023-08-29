namespace tots.Models
{
    public class Tot
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string article { get; set; }
        public DateTime TottedOn { get; set; }
        //Forign Key 
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
