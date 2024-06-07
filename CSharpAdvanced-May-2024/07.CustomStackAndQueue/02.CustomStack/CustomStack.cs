using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomStack
{
    public class CustomStack<T>
    {
        private const int Capacity = 4;

        private T[] items;
        private int counter;

        public CustomStack()
        {
            this.items = new T[Capacity];
        }

        public int Count
            => this.counter;

        public void Push(T value)
        {
            if (this.counter == this.items.Length)
            {
                T[] tempArray = new T[this.items.Length * 2];
                Array.Copy(this.items, tempArray, this.items.Length);
                this.items = tempArray;
            }

            this.items[this.counter++] = value;
        }

        public T Pop()
        {
            if (this.counter == 0)
            {
                throw new InvalidOperationException();
            }

            T removedElement = this.items[this.counter - 1];
            this.items[this.counter - 1] = default;

            this.counter--;

            if (this.items.Length / 2 >= this.counter)
            {
                T[] tempArray = new T[this.items.Length / 2];
                Array.Copy(this.items, tempArray, tempArray.Length);
                this.items = tempArray;
            }

            return removedElement;
        }

        public T Peek()
        {
            if (this.counter == 0)
            {
                throw new InvalidOperationException();
            }

            return this.items[this.counter - 1];
        }

        public void ForEach(Action<T> action)
        {
            for(int i = this.counter - 1; i >= 0; i--) 
            {
                action(this.items[i]);
            }
        }
    }
}
