//linear search, binary search, recursive binary search

namespace DSaA
{
    class LinearAndBinarySearch
    {
        //O(n)
        public static int linearSearch(int[] array, int findVal)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] == findVal)
                    return i;
            }
            return -1;
        }

        //O(logn)
        public static int binarySearchRecursive(int[] array, int findVal, int minIndex, int maxIndex)
        {
            if(maxIndex < minIndex)
            {
                return -1;
            }

            int index = minIndex + (maxIndex - minIndex) / 2;
            int middleElement = array[index];

            if(findVal == middleElement)
            {
                return index;
            }
            else if(findVal < middleElement)
            {
                maxIndex = index - 1;
            }
            else
            {
                minIndex = index + 1;
            }

            return binarySearchRecursive(array, findVal, minIndex, maxIndex);
        }

        //O(logn)
        public static int binarySearch(int[] array, int findVal)
        {
            int index = 0;
            int minIndex = 0;
            int maxIndex = array.Length - 1;
            int middleElement = 0;

            while(maxIndex >= minIndex)
            {
                index = minIndex + (maxIndex - minIndex) / 2;
                middleElement = array[index];

                if(findVal == middleElement)
                {
                    return index;
                }
                else if(findVal < middleElement)
                {
                    maxIndex = index - 1;
                }
                else
                {
                    minIndex = index + 1;
                }
            }

            return -1;
        }
    }
}