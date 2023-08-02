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
        }
        public int Count
        {
            get
            {
                return Storage.Count;
            }
        }

        public void Add(string title, string firstName, string lastName, int numberOfPages)
        {
            Book newBook = new Book(title, $"{firstName} {lastName}", numberOfPages);

            Storage.Add(newBook.Title, newBook);
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

        public IEnumerator<Book> GetEnumerator()
        {
            IEnumerator<Book> bookEnumerator = Storage.Values.GetEnumerator();
            return bookEnumerator;
        }

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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}