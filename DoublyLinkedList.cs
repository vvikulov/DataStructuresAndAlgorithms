namespace DSaA
{
    class DoublyLinkedList
    {
        public class Node
        {
            public Node prev;
            public Node next;
            public int key;
            public int data;

            public Node(int key, int data)
            {
                this.key = key;
                this.data = data;
            }
        }

        private Node head;
        private Node tail;

        public void printForward()
        {
            Node current = head;
            while(current != null)
            {
                System.Console.WriteLine("key = " + current.key + " data = " + current.data);
                current = current.next;
            }
        }

        public void printBackward()
        {
            Node current = tail;
            while(current != null)
            {
                System.Console.WriteLine("key = " + current.key + " data = " + current.data);
                current = current.prev;
            }
        }

        public void addFirst(int key, int data)
        {
            Node newNode = new Node(key, data);

            if(head == null)
            {
                tail = newNode;
            }
            else
            {
                head.prev = newNode;
                newNode.next = head;
            }

            head = newNode;
        }

        public void addLast(int key, int data)
        {
            Node newNode = new Node(key, data);

            if(tail == null)
            {
                head = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
            }

            tail = newNode;
        }

        public bool addAfter(int key, int newKey, int data)
        {
            Node current = head;
            while(current != null)
            {
                if(current.key == key)
                {
                    Node newNode = new Node(newKey, data);

                    newNode.prev = current;
                    newNode.next = current.next;
                    current.next = newNode;

                    if(current == tail)
                    {
                        tail = newNode;
                    }

                    return true;
                }
                else
                {
                    current = current.next;
                }
            }

            return false;
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

                if(head != null)
                {
                    head.prev = null;
                }
                else
                {
                    tail = null;
                }

                return temp;
            }
        }

        public Node removeLast()
        {
            if(tail == null)
            {
                return null;
            }
            else
            {
                Node temp = tail;

                tail = tail.prev;

                if(head != null)
                {
                    head.next = null;
                }
                else
                {
                    head = null;
                }

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

            while(current.key != key)
            {
                if(current.next == null)
                {
                    return null;
                }
                else
                {
                    current = current.next;
                }
            }

            if(current == head)
            {
                head = head.next;
                head.prev = null;
            }
            else
            {
                current.prev.next = current.next;
            }

            if(current == tail)
            {
                tail = tail.prev;
                tail.next = null;
            }
            else
            {
                current.next.prev = current.prev;
            }

            return current;
        }
    }
}