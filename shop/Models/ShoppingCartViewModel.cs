using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// using shop.CustomValidation;

namespace shop.Models
{
    public class ShoppingCartViewModel
    {
        [Required]
        public Order Order { get; set; }
        
        [Required]
        public List<OrderedBook> Basket { get; set; }
        
        [Display(Name = "Check this box if Billing Address and Shipping Address are the same.")]
        [Required]
        public bool ShippingEqualBilling { get; set; }
        
        public void AddBook(int bookId)
        {
            foreach (var book in Basket)
            {
                if (bookId == book.BookId)
                {
                    book.Quantity++;
                    return;
                }
            }
            //
            // BookQuantity newBook = new BookQuantity(bookId);
            // Basket.Add(newBook);
            // TODO: uaktualnij cookies; czy uaktualnij po wyjściu z shoppingCart?
        }

        public void RemoveBook(int bookId)
        {
            foreach (var book in Basket)
            {
                if (bookId == book.BookId)
                {
                    book.Quantity--;
                    if (book.Quantity == 0)
                    {
                        Basket.Remove(book);
                    }
                }
            }
            // TODO: uaktualnij cookies; czy uaktualnij po wyjściu z shoppingCart?
        }

        public double TotalPrice()
        {
            double totalPrice = 0; 
            foreach (var orderedBook in Basket)
            {
                totalPrice += orderedBook.Price * orderedBook.Quantity;
            }
            
            return totalPrice;
        }
        
        public double TotalAmount()
        {
            int totalAmount = 0; 
            foreach (var bookQuantity in Basket)
            {
                totalAmount += bookQuantity.Quantity;
            }

            return totalAmount;
        }
    }
}