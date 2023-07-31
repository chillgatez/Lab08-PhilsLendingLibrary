using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_PhilsLendingLibrary
{
    internal class LinkedList : IEnumerable<Book>
    {
        public Node Head { get; set; }

        public LinkedList()
        {
            Head = null;
        }

        // This is required for non-generic collections (legacy support)
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // This is the strongly-typed enumerator required for generic collections
        public IEnumerator<Book> GetEnumerator()
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        public void Insert(Book book)
        {
            Node newNode = new Node(book);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
        }

        public bool Includes(Book book)
        {
            bool foundBook = false;
            Node currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value == book)
                {
                    foundBook = true;
                }
                currentNode = currentNode.Next;
            }
            return foundBook;
        }

        public string ToString()
        {
            string listString = "";
            Node currentNode = Head;
            while (currentNode != null)
            {
                listString += currentNode.Value.Title + " -> ";
                currentNode = currentNode.Next;
            }
            listString += "NULL";
            return listString;
        }
    }

    public class Node
    {
        public Book Value { get; set; }
        public Node Next { get; set; }

        public Node(Book value)
        {
            Value = value;
            Next = null;
        }
    }
}
