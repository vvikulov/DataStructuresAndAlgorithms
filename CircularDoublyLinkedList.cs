namespace DSaA
{
    class CircularDoublyLinkedList
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
            System.Console.WriteLine("key = " + current.key + " data = " + current.data);
            current = current.next;

            while(current != null && current != head)
            {
                System.Console.WriteLine("key = " + current.key + " data = " + current.data);
                current = current.next;
            }
        }

        public void printBackward()
        {
            Node current = tail;
            System.Console.WriteLine("key = " + current.key + " data = " + current.data);
            current = current.prev;

            while(current != null && current != tail)
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
                newNode.next = newNode;
                newNode.prev = newNode;
            }
            else
            {
                newNode.next = head;
                newNode.prev = head.prev;
                head.prev = newNode;
                tail.next = newNode;
            }

            head = newNode;
        }

        public void addLast(int key, int data)
        {
            Node newNode = new Node(key, data);

            if(tail == null)
            {
                head = newNode;
                newNode.next = newNode;
                newNode.prev = newNode;
            }
            else
            {
                newNode.next = tail.next;
                newNode.prev = tail;
                tail.next = newNode;
                head.prev = newNode;
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
                    newNode.next.prev = newNode;

                    if(current == tail)
                    {
                        tail = newNode;
                    }

                    return true;
                }
                else
                {
                    current = current.next;

                    if(current == head)
                    {
                        break;
                    }
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

                if(head.next != head)
                {
                    head = head.next;
                    head.prev = temp.prev;
                    temp.prev.next = head;
                }
                else
                {
                    head = null;
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

                if(tail.prev != tail)
                {
                    tail = tail.prev;
                    tail.next = temp.next;
                    temp.next.prev = tail;
                }
                else
                {
                    head = null;
                    tail = null;
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
            if(head == null)
            {
                return 0;
            }

            int length = 1;
            Node current = head.next;

            while(current != head)
            {
                length++;
                current = current.next;
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
                    if(current == head)
                    {
                        break;
                    }
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

                    if(current == head)
                    {
                        return null;
                    }
                }
            }

            if(current == head)
            {
                head = head.next;
                head.prev = current.prev;
                current.prev.next = head;
            }
            else
            {
                current.prev.next = current.next;
            }

            if(current == tail)
            {
                tail = tail.prev;
                tail.next = current.next;
                current.next.prev = tail;
            }
            else
            {
                current.next.prev = current.prev;
            }

            return current;
        }
    }
}