namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<K>
    {
        private ListNode<K> head;
        private ListNode<K> tail;

        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public ListNode<T> NextNode { get; set; }

            public ListNode<T> PreviousNode { get; set; }

        }

        public int Count { get; private set; }

        public void AddFirst(K element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<K>(element);
            }
            else
            {
                ListNode<K> newHead = new ListNode<K>(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(K element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<K>(element);
            }
            else
            {
                ListNode<K> newTail = new ListNode<K>(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public K RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public K RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<K> action)
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public K[] ToArray()
        {
            K[] array = new K[this.Count];
            int counter = 0;
            var currentNode = this.head;

            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }

            return array;
        }

    }
}
