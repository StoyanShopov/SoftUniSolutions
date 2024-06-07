namespace _05.GenericCountMethodString
{ 
    public class Box<T>
        where T : IComparable
    {
        public Box()
            => this.Items = new List<T>();

        public List<T> Items { get; set; }

        public void Swap(int firstIndex, int secondIndex)
            => (this.Items[secondIndex], this.Items[firstIndex])
                = (this.Items[firstIndex], this.Items[secondIndex]);

        public int CountOfLargetElements(T value)
            => this.Items.Count(item => item.CompareTo(value) > 0);

        public override string ToString()
            => string.Join(
                Environment.NewLine,
                this.Items.Select(item => $"{typeof(T)}: {item}"));
    }
}
