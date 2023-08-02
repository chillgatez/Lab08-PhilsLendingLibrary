using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_PhilsLendingLibrary
{
    public class Backpack : IBag<Book>
    {
        private List<Book> items;

        public Backpack()
        {
            items = new List<Book>();
        }

        public void Pack(Book item)
        {
            if (item != null)
            {
                items.Add(item);
            }
        }

        public Book Unpack(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                Book removedItem = items[index];
                items.RemoveAt(index);
                return removedItem;
            }
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        public IEnumerator<Book> GetEnumerator() => items.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => items.Count;
    }
}