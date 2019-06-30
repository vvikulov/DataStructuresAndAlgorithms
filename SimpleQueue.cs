namespace DSaA
{
    class SimpleQueue<T>
    {
        T[] queue;
        private int frontIndex;
        private int backIndex;

        public SimpleQueue(int size)
        {
            queue = new T[size];
            frontIndex = -1;
            backIndex = -1;
        }

        public bool enqueue(T val)
        {
            if(isFull())
            {
                return false;
            }
            else
            {
                if(frontIndex < 0)
                {
                    frontIndex = 0;
                }

                backIndex++;
                queue[backIndex] = val;
                return true;
            }
        }

        public T dequeue()
        {
            if(isEmpty())
            {
                return default(T);
            }
            else
            {
                T data = queue[frontIndex];
                queue[frontIndex] = default(T);
                frontIndex++;
                return data;
            }
        }

        public T peek()
        {
            if(!isEmpty())
            {
                return queue[frontIndex];
            }
            else
            {
                return default(T);
            }
        }

        public bool isFull()
        {
            return backIndex == queue.Length - 1;
        }

        public bool isEmpty()
        {
            return frontIndex < 0 || frontIndex > backIndex;
        }
    }
}
