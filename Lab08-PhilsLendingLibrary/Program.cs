namespace Lab08_PhilsLendingLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello welcome to my Library");

            while (true)
            {
                Console.WriteLine("Here are your options:");
                Console.WriteLine("View all books [1]");
                Console.WriteLine("Add a Book [2]");
                Console.WriteLine("Borrow a book [3]");
                Console.WriteLine("Return a book [4]");
                string choice = Console.ReadLine();
            }

        }
    }
}