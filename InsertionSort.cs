//insertion sort, recursive insertion sort

namespace DSaA
{
    class InsertionSort
    {
        public static void insertionSort1(int[] array)
        {
            for(int i = 1; i < array.Length; i++)
            {
                int keyIndex = i;

                while(keyIndex > 0 && array[keyIndex] < array[keyIndex - 1])
                {
                    int key = array[keyIndex];
                    array[keyIndex] = array[keyIndex - 1];
                    array[keyIndex - 1] = key;
                    keyIndex--;
                }
            }
        }

        public static void insertionSort1Recursive(int[] a, int i)
        {
            if(i >= a.Length)
            {
                return;
            }

            int keyIndex = i;

            while(keyIndex > 0 && a[keyIndex - 1] > a[keyIndex])
            {
                int temp = a[keyIndex];
                a[keyIndex] = a[keyIndex - 1];
                a[keyIndex - 1] = temp;
                keyIndex--;
            }

            insertionSort1Recursive(a, i + 1);
        }

        public static void insertionSort2(int[] a)
        {
            for(int i = 1; i < a.Length; i++)
            {
                for(int j = i - 1; j >= 0; j--)
                {
                    if(a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public static void insertionSort2Recursive(int[] a, int rightIndex)
        {
            if(rightIndex >= a.Length)
            {
                return;
            }

            for(int j = rightIndex - 1; j >= 0; j--)
            {
                if(a[j] > a[j + 1])
                {
                    int temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                }
                else
                {
                    break;
                }
            }

            insertionSort2Recursive(a, rightIndex + 1);
        }
    }
}