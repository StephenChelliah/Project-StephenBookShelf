using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StephenBookShelf.Models;
using StephenBookShelf.DATADB;
using System.Net;
using System;

namespace StephenBookShelf.Controllers
{
    public class BookstoreController : Controller
    {

        private readonly BookStoreDBContextClass bkdb;

        public BookstoreController(BookStoreDBContextClass bkdb)
        {
            this.bkdb = bkdb;
        }

        public static CartModel cm = new CartModel();

        [HttpGet]
        public async Task<IActionResult> Details(string BookId)
        {
            var detail = await bkdb.Booktab.FirstOrDefaultAsync(r => r.BookId == BookId);

            cm.BookId = detail.BookId;
            cm.Title = detail.Title;
            cm.Author = detail.Author;
            cm.Category = detail.Category;
            cm.Price = detail.Price;

            return View(detail);
        }


       

        [HttpGet]
        public async Task<IActionResult> AddtoCart()
        {
            await bkdb.Cart.AddAsync(cm);
            await bkdb.SaveChangesAsync();
            return View(cm);
        }

        [HttpGet]
        public async Task<IActionResult> YourCart()
        {
            var tab = await bkdb.Cart.ToListAsync();

            decimal total = 0m; 

            foreach (CartModel carvar in tab)
            {
                total = total + decimal.Parse(carvar.Price);
            }

            ViewBag.Total = total;

            return View(tab);
        }

       
        public async Task<IActionResult> Search(string keyword)
        {

            try
            {
                // Validate and sanitize keyword input
                var matchingBooks = await bkdb.Booktab.Where(book => book.BookId.Contains(keyword) || book.Title.Contains(keyword) || book.Author.Contains(keyword) || book.Category.Contains(keyword)).ToListAsync();

                if (matchingBooks.Count == 0)
                {
                    throw new InvalidOperationException("No matching books found.");
                }
                else
                {
                    return View(matchingBooks);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("IncorrectSearch");
            }
        }
        public IActionResult IncorrectSearch()
        {
            return View();
        }

            public async Task<IActionResult> CleartheCart()
        {

            await bkdb.Database.ExecuteSqlRawAsync("DELETE FROM Cart");

            await bkdb.SaveChangesAsync();

            return RedirectToAction("YourCart");
        }


    }
    }

