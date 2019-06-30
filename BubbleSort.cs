//Optimized bubble sort, Recursive bubble sort

namespace DSaA
{
    class BubbleSort
    {
        //If for a particular iteration, no swapping took place, 
        //it means the array has been sorted and we can jump out of the for loop, 
        //instead of executing all the iterations.
        public static void bubbleSortOptimized(int[] array)
        {
            int lastSort = array.Length;

            while(lastSort > 0)
            {
                bool flag = false;
                for(int i = 0; i < lastSort - 1; i++)
                {
                    if(array[i] > array[i + 1])
                    {
                        int temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;

                        flag = true;
                    }
                }

                if(!flag)
                {
                    break;
                }

                lastSort--;
            }
        }

        public static void bubbleSort1(int[] array)
        {
            int lastSort = array.Length;

            while(lastSort > 0)
            {
                for(int i = 0; i < lastSort - 1; i++)
                {
                    if(array[i] > array[i + 1])
                    {
                        int temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                    }
                }
                lastSort--;
            }
        }

        public static void bubbleSort2(int[] ar)
        {
            for(int i = 0; i < ar.Length; i++)
            {
                for(int j = 0; j < ar.Length - i - 1; j++)
                {
                    if(ar[j] > ar[j + 1])
                    {
                        int temp = ar[j];
                        ar[j] = ar[j + 1];
                        ar[j + 1] = temp;
                    }
                }
            }
        }

        public static void bubbleSortRecursive(int[] array, int n)
        {
            if(n <= 0)
            {
                return;
            }
            else
            {
                for(int i = 0; i < n - 1; i++)
                {
                    if(array[i] > array[i + 1])
                    {
                        int temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                    }
                }

                bubbleSortRecursive(array, --n);
            }
        }
    }
}