using System.ComponentModel.DataAnnotations;

namespace StephenBookShelf.Models
{
    public class CartModel
    {
        [Key]
        public string BookId { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string Price { get; set; }

       

    }
}
