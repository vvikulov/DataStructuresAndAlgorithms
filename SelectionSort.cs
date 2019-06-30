//selection sort, recursive selection sort

namespace DSaA
{
    class SelectionSort
    {
        //O(n^2)
        public static void selectionSort(int[] ar)
        {
            for(int i = 0; i < ar.Length; i++)
            {
                int minIndex = i;
                for(int j = i + 1; j < ar.Length; j++)
                {
                    if(ar[j] < ar[minIndex])
                    {
                        int temp = ar[j];
                        ar[j] = ar[minIndex];
                        ar[minIndex] = temp;
                    }
                }
            }
        }

        public static void selectionSortRecursive(int[] ar, int startIndex)
        {
            if(startIndex >= ar.Length - 1)
            {
                return;
            }

            int minIndex = startIndex;

            for(int j = startIndex + 1; j < ar.Length; j++)
            {
                if(ar[j] < ar[minIndex])
                {
                    int temp = ar[j];
                    ar[j] = ar[minIndex];
                    ar[minIndex] = temp;
                }
            }

            selectionSortRecursive(ar, startIndex + 1);
        }
    }
}