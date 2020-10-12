using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StartUp
{
    class CustomList
    {
        private const int INITIAL_CAPACITY = 2;

        private int[] items;
        public CustomList()
        {
            this.items = new int [INITIAL_CAPACITY];
        }
        public int Count { get;private set; }
        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= this.Count || firstIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int elementAtFirstIndex = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = elementAtFirstIndex;
        }
        public bool Contains(int searchedItem)
        {
            for (int i = 0; i < this.Count; i++)
            {
                int currentElement = items[i];
                if (currentElement==searchedItem)
                {
                    return true;
                }
            }
            return false;
        }
        public void Insert(int index, int item) {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (this.Count==this.items.Length)
            {
                this.Resize();
            }
            this.ShiftToRight(index);
            this.items[index] = item;
            this.Count++;
        }
        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i < index; i--)
            {
                this.items[i] = this.items[i-1];
            }
        }
        public int RemoveAt(int index)
        {
            if (index>=this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            //Physically remove of the item
            int removedItem = this.items[index];
            this.items[index] = default;
            this.ShiftToLeft(index);

            this.Count--;
            if (this.Count<=this.items.Length/4)
            {
                this.Shrink();

            }
            return removedItem;
        }
        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            items = copy;
        }
        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count-1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            for (int i = this.Count-1; i < this.items.Length; i++)
            {
                this.items[i] = default;
            }

        }
        public void Add(int item)
        {
            if (this.Count==this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }
        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            items = copy;
        }
        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];

            }
            set
            {
                if (index>=this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                 items[index] = value;
            }
        //   private bool IsValidIndex(int index) => this.index < this.Count;
    }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                if (i==this.Count-1)
                {
                    sb.Append($"{this.items[i]}")
                }
                else
                {
                    sb.Append($"{this.items[i]}");
                }
            }
            return sb.ToString().TrimEnd();
        }

    }
}
