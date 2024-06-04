using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomStack
{
    public class CustomStack
    {
        private const int Capacity = 4;

        private int[] items;
        private int counter;

        public CustomStack()
        {
            this.items = new int[Capacity];
        }

        public int Count
            => this.counter;

        public void Push(int value)
        {
            if (this.counter == this.items.Length)
            {
                int[] tempArray = new int[this.items.Length * 2];
                Array.Copy(this.items, tempArray, this.items.Length);
                this.items = tempArray;
            }

            this.items[this.counter++] = value;
        }

        public int Pop()
        {
            if (this.counter == 0)
            {
                throw new InvalidOperationException();
            }

            int removedElement = this.items[this.counter - 1];
            this.items[this.counter - 1] = default;

            this.counter--;

            if (this.items.Length / 2 >= this.counter)
            {
                int[] tempArray = new int[this.items.Length / 2];
                Array.Copy(this.items, tempArray, tempArray.Length);
                this.items = tempArray;
            }

            return removedElement;
        }

        public int Peek()
        {
            if (this.counter == 0)
            {
                throw new InvalidOperationException();
            }

            return this.items[this.counter - 1];
        }

        public void ForEach(Action<int> action)
        {
            for(int i = this.counter - 1; i >= 0; i--) 
            {
                action(this.items[i]);
            }
        }
    }
}
