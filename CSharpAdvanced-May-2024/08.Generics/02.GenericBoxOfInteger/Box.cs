namespace _02.GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box()
            => this.Items = new List<T>();

        public List<T> Items { get; set; }

        public override string ToString()
            => string.Join(
                Environment.NewLine,
                this.Items.Select(item => $"{typeof(T)}: {item}"));
    }
}
