using StephenBookShelf.Models;
using Microsoft.EntityFrameworkCore;


namespace StephenBookShelf.DATADB
{
    public class BookStoreDBContextClass : DbContext
    {
        public BookStoreDBContextClass(DbContextOptions<BookStoreDBContextClass> options) : base(options)
        {

        }

        public DbSet<BookModel> Booktab { get; set; }
        public DbSet<CartModel> Cart { get; set; }

    }
}
