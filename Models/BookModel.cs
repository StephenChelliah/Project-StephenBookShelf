using System.ComponentModel.DataAnnotations;

namespace StephenBookShelf.Models
{
    public class BookModel
    {
        [Key]
        public string BookId { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string Price { get; set; }

        public string ImageURL { get; set; }

    }
}
