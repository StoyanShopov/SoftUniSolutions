using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomQueue
{
    public class CustomQueue
    {
        private const int Capacity = 4;
        private int[] items;
        private int counter;

        public CustomQueue()
        {
            this.items = new int[Capacity];
        }

        public CustomQueue(params int[] items)
        {
            this.items = items;
        }

        public int Count
            => this.counter;

        public void Enqueue(int value)
        {
            if (this.counter == this.items.Length)
            {
                int[] tempArray = new int[this.items.Length * 2];
                Array.Copy(this.items, tempArray, this.items.Length);
                this.items = tempArray;
            }

            this.items[this.counter++] = value;
        }

        public int Dequeue()
        {
            if (this.counter == 0)
            {
                throw new InvalidOperationException();
            }

            int removedElement = this.items[0];

            this.counter--;

            for (int i = 0; i < this.counter; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            if (this.items.Length / 2 >= this.counter)
            {
                int[] tempArray = new int[this.items.Length / 2];
                Array.Copy(this.items, tempArray, tempArray.Length);
                this.items = tempArray;
            }

            for (int i = this.counter; i < this.items.Length; i++)
            {
                this.items[i] = default;
            }

            return removedElement;
        }

        public int Peek()
        {
            if (this.counter == 0)
            {
                throw new InvalidOperationException();
            }

            return this.items[0];
        }

        public void Clear()
        {
            this.counter = 0;
            this.items = new int[Capacity];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.counter; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
