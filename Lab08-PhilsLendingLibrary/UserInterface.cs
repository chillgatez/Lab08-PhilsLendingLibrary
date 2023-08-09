using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_PhilsLendingLibrary
{
    public class UserInterface
    {
        private Library library;
        private Backpack bookBag;

        public UserInterface()
        {
            library = new Library();
            bookBag = new Backpack();
        }

        public void LoadBooks()
        {
            // Add some initial books to the library
            library.Add("Book Title 1", "AuthorFirstName1", "AuthorLastName1", 200);
            library.Add("Book Title 2", "AuthorFirstName2", "AuthorLastName2", 150);
            // Add more books as needed
        }

        public void ShowOptions()
        {
            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. View all Books");
            Console.WriteLine("2. Add a Book");
            Console.WriteLine("3. Borrow a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. View Book Bag");
            Console.WriteLine("0. Exit");
        }

        public void UserInterfaceLoop()
        {
            LoadBooks();

            while (true)
            {
                ShowOptions();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ViewAllBooks();
                        break;

                    case 2:
                        AddBook();
                        break;

                    case 3:
                        BorrowBook();
                        break;

                    case 4:
                        ReturnBook();
                        break;

                    case 5:
                        ViewBookBag();
                        break;

                    case 0:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ViewAllBooks()
        {
            Console.WriteLine("All Books in the Library:");
            foreach (Book book in library)
            {
                Console.WriteLine(book.Title);
            }
        }

        private void AddBook()
        {
            Console.WriteLine("Enter the Title of the book:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the Author's First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the Author's Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the Number of Pages:");
            int numberOfPages = int.Parse(Console.ReadLine());

            library.Add(title, firstName, lastName, numberOfPages);
            Console.WriteLine("Book added to the Library.");
        }

        private void BorrowBook()
        {
            Console.WriteLine("Enter the Title of the book to borrow:");
            string title = Console.ReadLine();

            Book borrowedBook = library.Borrow(title);
            if (borrowedBook != null)
            {
                bookBag.Pack(borrowedBook);
                Console.WriteLine($"You have borrowed the book: {borrowedBook.Title}");
            }
            else
            {
                Console.WriteLine("Book not found in the Library.");
            }
        }

        private void ReturnBook()
        {
            if (bookBag.Count == 0)
            {
                Console.WriteLine("Your Book Bag is empty.");
                return;
            }

            Console.WriteLine("Your Book Bag:");
            int index = 1;
            foreach (Book book in bookBag)
            {
                Console.WriteLine($"{index}. {book.Title}");
                index++;
            }

            Console.WriteLine("Enter the number of the book to return:");
            int bookNumber = int.Parse(Console.ReadLine()) - 1;

            if (bookNumber >= 0 && bookNumber < bookBag.Count)
            {
                Book returnedBook = bookBag.Unpack(bookNumber);
                library.Return(returnedBook);
                Console.WriteLine($"You have returned the book: {returnedBook.Title}");
            }
            else
            {
                Console.WriteLine("Invalid book number.");
            }
        }

        private void ViewBookBag()
        {
            Console.WriteLine("Your Book Bag:");
            int index = 1;
            foreach (Book book in bookBag)
            {
                Console.WriteLine($"{index}. {book.Title}");
                index++;
            }
        }
    }

}
