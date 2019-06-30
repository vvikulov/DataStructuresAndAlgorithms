namespace DSaA
{
    class Quicksort
    {
        public static int[] quickSort2(int[] a)
        {
            if(a.Length <= 1)
            {
                return a;
            }

            int key = partition3(a);

            int[] lessArray = new int[key];
            int[] greaterArray = new int[a.Length - key - 1];
            int indexLess = 0;
            int indexGreater = 0;

            for(int i = 0; i < a.Length; i++)
            {
                if(i < key)
                {
                    lessArray[indexLess] = a[i];
                    indexLess++;
                }
                else if(i > key)
                {
                    greaterArray[indexGreater] = a[i];
                    indexGreater++;
                }
            }

            lessArray = quickSort2(lessArray);
            greaterArray = quickSort2(greaterArray);
            return mergeArrays(lessArray, a[key], greaterArray);
        }

        public static int[] mergeArrays(int[] less, int middle, int[] greater)
        {
            int[] temp = new int[less.Length + greater.Length + 1];
            int aIndex = 0;
            int bIndex = 0;

            for(int i = 0; i < temp.Length; i++)
            {
                if(i < less.Length)
                {
                    temp[i] = less[aIndex];
                    aIndex++;
                }
                else if(i == less.Length)
                {
                    temp[i] = middle;
                }
                else
                {
                    temp[i] = greater[bIndex];
                    bIndex++;
                }
            }

            return temp;
        }

        public static int partition3(int[] a)
        {
            int pivot = a[a.Length - 1];
            int leftIndex = 0;
            int rightIndex = a.Length - 2;

            while(leftIndex <= rightIndex)
            {
                while(leftIndex <= rightIndex && a[leftIndex] <= pivot)
                {
                    leftIndex++;
                }

                while(leftIndex <= rightIndex && a[rightIndex] >= pivot)
                {
                    rightIndex--;
                }

                if(leftIndex < rightIndex)
                {
                    swap(a, leftIndex, rightIndex);
                }
                else
                {
                    swap(a, leftIndex, a.Length - 1);
                }
            }

            return leftIndex;
        }

        public static void quickSort1(int[] a, int startIndex, int endIndex)
        {
            if(startIndex < endIndex)
            {
                int key;
                key = partition1(a, startIndex, endIndex);
                quickSort1(a, startIndex, key - 1);
                quickSort1(a, key + 1, endIndex);
            }
        }

        public static int partition1(int[] a, int startIndex, int endIndex)
        {
            int pivot = a[endIndex];
            int leftIndex = startIndex;
            int rightIndex = endIndex - 1;

            while(leftIndex <= rightIndex)
            {
                while(leftIndex <= rightIndex && a[leftIndex] <= pivot)
                {
                    leftIndex++;
                }

                while(leftIndex <= rightIndex && a[rightIndex] >= pivot)
                {
                    rightIndex--;
                }

                if(leftIndex < rightIndex)
                {
                    swap(a, leftIndex, rightIndex);
                }
                else
                {
                    swap(a, leftIndex, endIndex);
                }
            }

            return leftIndex;
        }

        public static int partition2(int[] a, int startIndex, int endIndex)
        {
            int pivot = a[endIndex];
            int pIndex = startIndex;

            for(int i = startIndex; i < endIndex; i++)
            {
                if(a[i] <= pivot)
                {
                    swap(a, i, pIndex);
                    pIndex++;
                }
            }
            swap(a, pIndex, endIndex);

            return pIndex;
        }

        public static void swap(int[] a, int index1, int index2)
        {
            int temp = a[index1];
            a[index1] = a[index2];
            a[index2] = temp;
        }
    }
}