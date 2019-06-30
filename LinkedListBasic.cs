namespace DSaA
{
    class Node
    {
        public Node next;
        public int key;
        public int data;

        public Node(int key, int data)
        {
            this.key = key;
            this.data = data;
        }
    }

    class LinkedListBasic
    {
        private Node head;

        public void print()
        {
            Node current = head;
            while(current != null)
            {
                System.Console.WriteLine("key = " + current.key + " data = " + current.data);
                current = current.next;
            }
        }

        public void addFirst(int key, int data)
        {
            Node newNode = new Node(key, data);

            newNode.next = head;
            head = newNode;
        }

        public void addAt(int index, int key, int data)
        {
            Node newNode = new Node(key, data);

            if(head == null)
            {
                if(index == 0)
                {
                    head = newNode;
                }
                else
                {
                    System.Console.WriteLine("Error! addAt. List is empty, but index = " + index);
                }
            }
            else if(index == 0)
            {
                newNode.next = head;
                head = newNode;
            }
            else
            {
                int i = 0;
                Node current = head;
                while(current != null && i < index - 1)
                {
                    current = current.next;
                    i++;
                }

                if(current != null)
                {
                    newNode.next = current.next;
                    current.next = newNode;
                }
                else
                {
                    System.Console.WriteLine("Error! addAt. Wrong index = " + index);
                }
            }
        }

        public Node removeFirst()
        {
            if(head == null)
            {
                return null;
            }
            else
            {
                Node temp = head;

                head = head.next;

                return temp;
            }
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public int length()
        {
            int length = 0;

            Node current = head;
            while(current != null)
            {
                current = current.next;
                length++;
            }

            return length;
        }

        public Node find(int key)
        {
            Node current = head;
            while(current != null)
            {
                if(current.key == key)
                {
                    return current;
                }
                else
                {
                    current = current.next;
                }
            }
            return null;
        }

        public Node remove(int key)
        {
            if(head == null)
            {
                return null;
            }

            Node current = head;
            Node previous = null;

            while(current.key != key)
            {
                if(current.next == null)
                {
                    return null;
                }
                else
                {
                    previous = current;
                    current = current.next;
                }
            }

            if(current == head)
            {
                head = head.next;
            }
            else
            {
                previous.next = current.next;
            }

            return current;
        }

        public void reverse()
        {
            if(head == null)
            {
                return;
            }

            Node prev = head;
            Node current = head.next;
            prev.next = null;

            while(current != null)
            {
                Node next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            head = prev;
        }
    }
}