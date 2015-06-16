using System;
using System.Linq;

namespace GenericListVersion
{
    [VersionAttribute(0,1)]
    class GenericList<T>
    {
        private const int ListCapacity = 16;
        private T[] elements;
        private int count;

        public GenericList(int size = ListCapacity)
        {
            this.elements = new T[size];
            this.Count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Count", "Count cannot be negative.");
                }
                this.count = value;
            }

        }

        public void Add(T element)
        {
            this.AutoGrow();
            this.elements[this.Count] = element;
            this.Count++;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException(string.Format("Index {0} is invalid!", index));
                }
                return this.elements[index];
            }
        }
        public void Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("index", "Index out of range!");
            }
            this.Count--;
            for (int i = index; i < this.Count; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            this.elements[this.Count] = default(T);
        }
        public void Insert(int index, T value)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("index", "Index out of range!");
            }
            this.AutoGrow();
            for (int i = this.Count; i > index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }
            this.elements[index] = value;
            this.Count++;
        }
        public int IndexOf(T value)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.elements[i] = default(T);
            }
            this.Count = 0;
        }
        public bool Contain(T value)
        {
            if (this.IndexOf(value) > -1)
            {
                return true;
            }
            return false;
        }

        private void AutoGrow()
        {
            if (this.Count == this.elements.Length)
            {
                var newElements = new T[elements.Length * 2];
                for (int i = 0; i < this.elements.Length; i++)
                {
                    newElements[i] = this.elements[i];
                }
                this.elements = newElements;
            }
        }

        public override string ToString()
        {
            if (this.Count == 0)
            {
                return "List is empty!";
            }
            var realElements = this.elements.Take(this.Count);
            string output = string.Join(", ", realElements);
            return output;
        }

        public static IComparable Min<U>(GenericList<U> list)
            where U : IComparable
        {
            var currentMin = (IComparable)list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(currentMin) == -1)
                {
                    currentMin = list[i];
                }
            }
            return currentMin;
        }
        public static IComparable Max<U>(GenericList<U> list)
            where U : IComparable
        {
            var currentMax = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(currentMax) == 1)
                {
                    currentMax = list[i];
                }
            }
            return currentMax;
        }
    }
}
