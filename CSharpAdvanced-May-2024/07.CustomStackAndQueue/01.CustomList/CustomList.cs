using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _01.CustomList
{
    public class CustomList<T>
        where T : IComparable
    {
        private const int InitialSize = 2;

        private T[] items;
        private int counter = 0;

        public CustomList()
        {
            this.items = new T[InitialSize];
        }

        public int Count
            => this.counter;

        public T this[int i]
        {
            get
            {
                ValidateRange(i);
                return this.items[i];
            }
            set
            {
                ValidateRange(i);
                this.items[i] = value;
            }
        }

        public void Add(T value)
        {
            if (this.counter == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.counter++] = value;
        }

        public T RemoveAt(int index)
        {
            ValidateRange(index);

            T removedValue = this.items[index];

            //rearrange
            for (int i = index; i < this.counter - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.counter--;

            //shrink
            if (this.items.Length / 2 >= this.counter)
            {
                T[] tempArray = new T[this.counter];
                Array.Copy(this.items, tempArray, this.counter);
                this.items = tempArray;
            }
            else
            {
                for (int i = counter; i < this.items.Length; i++)
                {
                    items[i] = default;
                }
            }

            return removedValue;
        }

        public bool Contains(int value)
        {
            for (int i = 0; i < this.counter; i++)
            {
                if (value.CompareTo(this.items[i]) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex,  int secondIndex)
        {
            this.ValidateRange(firstIndex);
            this.ValidateRange(secondIndex);

            T tempValue = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = tempValue;
        }

        public void Insert(int index, T item)
        {
            this.ValidateRange(index);

            T[] tempArray = new T[this.counter + 1];

            for (int i = 0; i < index; i++)
            {
                tempArray[i] = this.items[i];
            }

            tempArray[index] = item;

            this.counter++;

            for (int i = index + 1; i < tempArray.Length; i++)
            {
                tempArray[i] = this.items[i - 1];
            }

            this.items = tempArray;
        }

        private void ValidateRange(int index)
        {
            if (index < 0 || index >= this.counter)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Resize()
        {
            T[] tempArray = new T[this.items.Length * 2];
            Array.Copy(this.items, tempArray, this.items.Length);
            this.items = tempArray;
        }
    }
}
