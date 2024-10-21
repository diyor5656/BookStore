namespace BookStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Coment { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
