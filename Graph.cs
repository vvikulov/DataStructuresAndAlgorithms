//Graph with Depth First Traversal

using System;

namespace DSaA
{
    class Graph<T2> where T2 : IComparable
    {
        class Stack<T3>
        {
            private T3[] stack;
            public int topIndex;
            private int size;

            public Stack(int size)
            {
                stack = new T3[size];
                topIndex = -1;
                this.size = size;
            }

            public void push(T3 val)
            {
                if(!isFull())
                {
                    topIndex++;
                    stack[topIndex] = val;
                }
            }

            public T3 pop()
            {
                if(!isEmpty())
                {
                    T3 val = stack[topIndex];
                    stack[topIndex] = default(T3);
                    topIndex--;
                    return val;
                }
                else
                {
                    return default(T3);
                }
            }

            public T3 peek()
            {
                if(!isEmpty())
                {
                    return stack[topIndex];
                }
                else
                {
                    return default(T3);
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

        public class Vertex<T> where T : IComparable
        {
            public T label;
            public bool visited;
        }

        private Vertex<T2>[] vertices;
        private bool[,] adjMatrix;
        int vertexCount = 0;

        public Graph(int size)
        {
            vertices = new Vertex<T2>[size];
            adjMatrix = new bool[size, size];

            for(int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < adjMatrix.GetLength(1); j++)
                {
                    adjMatrix[i, j] = false;
                }
            }
        }

        public void addVertex(T2 label)
        {
            Vertex<T2> vertex = new Vertex<T2>();
            vertex.label = label;
            vertex.visited = false;
            vertices[vertexCount] = vertex;
            vertexCount++;
        }

        public void addEdge(int start, int end)
        {
            adjMatrix[start, end] = true;
            adjMatrix[end, start] = true;
        }

        public void displayVertex(int vertexIndex)
        {
            System.Console.WriteLine(vertices[vertexIndex].label);
        }

        private int getAdjUnvisitedVertex(int vertexIndex)
        {
            for(int i = 0; i < vertexCount; i++)
            {
                if(adjMatrix[vertexIndex, i] && !vertices[i].visited)
                {
                    return i;
                }
            }

            return -1;
        }

        public void depthFirstSearch()
        {
            Graph<T2>.Stack<int> stack = new Stack<int>(vertices.Length);

            //mark first node as visited
            vertices[0].visited = true;

            displayVertex(0);

            //push vertex index in stack
            stack.push(0);

            while(!stack.isEmpty())
            {
                int unvisitedVertex = getAdjUnvisitedVertex(stack.peek());

                //no adjacent vertex found
                if(unvisitedVertex == -1)
                {
                    stack.pop();
                }
                else
                {
                    vertices[unvisitedVertex].visited = true;
                    displayVertex(unvisitedVertex);
                    stack.push(unvisitedVertex);
                }
            }

            //stack is empty, search is complete, reset the visited flag        
            for(int i = 0; i < vertexCount; i++)
            {
                vertices[i].visited = false;
            }
        }
    }
}