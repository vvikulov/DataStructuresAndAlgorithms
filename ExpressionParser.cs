namespace DSaA
{
    class Stack<T>
    {
        private T[] stack;
        public int topIndex;
        private int size;

        public Stack(int size)
        {
            stack = new T[size];
            topIndex = -1;
            this.size = size;
        }

        public void push(T val)
        {
            if(!isFull())
            {
                topIndex++;
                stack[topIndex] = val;
            }
        }

        public T pop()
        {
            if(!isEmpty())
            {
                T val = stack[topIndex];
                stack[topIndex] = default(T);
                topIndex--;
                return val;
            }
            else
            {
                return default(T);
            }
        }

        public T peek()
        {
            if(!isEmpty())
            {
                return stack[topIndex];
            }
            else
            {
                return default(T);
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

    class ExpressionParser
    {
        private int precedence(char symbol)
        {
            switch(symbol)
            {
                case '+':
                case '-':
                    return 2;
                case '*':
                case '/':
                    return 3;
                case '^':
                    return 4;
                case '(':
                case ')':
                case '#':
                    return 1;
            }
            return 0;
        }

        private bool isOperator(char symbol)
        {
            switch(symbol)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '^':
                case '(':
                case ')':
                    return true;
                default:
                    return false;
            }
        }

        public void convert(char[] infix, char[] postfix)
        {
            Stack<char> stack = new Stack<char>(25);

            int postfixIndex = 0;
            char symbol = (char)0;
            stack.push('#');

            for(int i = 0; i < infix.Length; i++)
            {
                symbol = infix[i];

                if(!isOperator(symbol))
                {
                    postfix[postfixIndex] = symbol;
                    postfixIndex++;
                }
                else
                {
                    if(symbol == '(')
                    {
                        stack.push(symbol);
                    }
                    else
                    {
                        if(symbol == ')')
                        {

                            while(stack.peek() != '(')
                            {
                                postfix[postfixIndex] = stack.pop();
                                postfixIndex++;
                            }

                            stack.pop();
                        }
                        else
                        {
                            while(precedence(stack.peek()) >= precedence(symbol))
                            {
                                postfix[postfixIndex] = stack.pop();
                                postfixIndex++;
                            }

                            stack.push(symbol);
                        }
                    }
                }
            }

            while(stack.peek() != '#')
            {
                postfix[postfixIndex] = stack.pop();
                postfixIndex++;
            }

            postfix[postfixIndex] = '\0';  //null terminate string. 
        }

        public int evaluate(char[] postfix)
        {
            Stack<int> stack = new Stack<int>(25);

            char ch;
            int postfixIndex = 0, operand1, operand2;

            while((ch = postfix[postfixIndex++]) != '\0')
            {

                if(!isOperator(ch))
                {
                    stack.push(ch - '0');
                }
                else
                {
                    operand2 = stack.pop();
                    operand1 = stack.pop();

                    switch(ch)
                    {
                        case '+':
                            stack.push(operand1 + operand2);
                            break;
                        case '-':
                            stack.push(operand1 - operand2);
                            break;
                        case '*':
                            stack.push(operand1 * operand2);
                            break;
                        case '/':
                            stack.push(operand1 / operand2);
                            break;
                        case '^':
                            stack.push((int)System.Math.Pow(operand1, operand2));
                            break;
                    }
                }
            }

            return stack.peek();
        }
    }
}
