namespace DSaA
{
    class Stack
    {
        private int[] stack;
        private int topIndex;
        private int size;

        public Stack(int size)
        {
            stack = new int[size];
            topIndex = -1;
            this.size = size;
        }

        public void push(int val)
        {
            if(!isFull())
            {
                topIndex++;
                stack[topIndex] = val;
            }
        }

        public int pop()
        {
            if(!isEmpty())
            {
                int val = stack[topIndex];
                stack[topIndex] = 0;
                topIndex--;
                return val;
            }
            else
            {
                return 0;
            }
        }

        public int peek()
        {
            if(!isEmpty())
            {
                return stack[topIndex];
            }
            else
            {
                return 0;
            }
        }

        public bool isFull()
        {
            return topIndex == size - 1;
        }

        public bool isEmpty()
        {
            return topIndex < 0;
        }
    }
}
