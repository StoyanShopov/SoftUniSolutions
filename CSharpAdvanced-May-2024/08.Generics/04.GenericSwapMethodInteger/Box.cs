namespace _04.GenericSwapMethodInteger
{ 
    public class Box<T>
    {
        public Box()
            => this.Items = new List<T>();

        public List<T> Items { get; set; }

        public void Swap(int firstIndex, int secondIndex)
            => (this.Items[secondIndex], this.Items[firstIndex])
                = (this.Items[firstIndex], this.Items[secondIndex]);

        public override string ToString()
            => string.Join(
                Environment.NewLine,
                this.Items.Select(item => $"{typeof(T)}: {item}"));
    }
}
