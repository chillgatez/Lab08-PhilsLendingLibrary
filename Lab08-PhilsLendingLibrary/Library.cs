using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_PhilsLendingLibrary
{
    internal class Library : ILibrary
    {
        private Dictionary<string, Book> Storage;

        public Library()
        {
            Storage = new Dictionary<string, Book>();

            // Create a new Book object
            Book book1 = new Book("To Kill A MockingBird", "SomeGuy", 100);
            Book book2 = new Book("Americana", "Shemamonda", 100);
            Book book3 = new Book("Berserk", "Kentaro Miura", 100);

            // Add the book to the Storage dictionary using the title as the key
            Storage.Add(book1.Title, book1);
            Storage.Add(book2.Title, book2);
            Storage.Add(book3.Title, book3);
        }

        public int Count => Storage.Count;

        public void Add(string title, string author, int numberOfPages)
        {
        }

        public Book Borrow(string title)
        {
            // Search for the book in the Storage dictionary using the title as the key
            // If found, return the book, otherwise return null
            if (Storage.TryGetValue(title, out Book book))
            {
                Storage.Remove(title); // Remove the book from the dictionary
                return book;
            }
            return null;
        }

        public IEnumerator<Book> GetEnumerator() => Storage.Values.GetEnumerator();

        public void Return(Book book)
        {
            // Add the returned book back to the Storage dictionary
            Storage.Add(book.Title, book);

        }

        public Book Search(string title)
        {
            // Search for the book in the Storage dictionary using the title as the key
            // If found, return the book, otherwise return null
            if (Storage.TryGetValue(title, out Book book))
            {
                return book;
            }
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}