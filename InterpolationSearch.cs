//Interpolation search. It is an improved variant of binary search. 
//The data collection should be in a sorted form and equally distributed.

namespace DSaA
{
    class InterpolationSearch
    {
        public static int interpolationSearch(int[] a, int val, int startIndex, int endIndex)
        {
            int midIndex = (int)(startIndex +
                ((float)(endIndex - startIndex) / (a[endIndex] - a[startIndex])) *
                (val - a[startIndex]));

            if(a[midIndex] == val)
            {
                return midIndex;
            }
            else
            {
                if(val > a[midIndex])
                {
                    return interpolationSearch(a, val, midIndex + 1, endIndex);
                }
                else
                {
                    return interpolationSearch(a, val, startIndex, midIndex - 1);
                }
            }
        }
    }
}