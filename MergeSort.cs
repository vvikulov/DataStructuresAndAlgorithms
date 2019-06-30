namespace DSaA
{
    class MergeSort
    {
        public static void mergeSort1(int[] input, int low, int high)
        {
            if(low < high)
            {
                int middle = (low + high) / 2;
                mergeSort1(input, low, middle);
                mergeSort1(input, middle + 1, high);
                merge1(input, low, middle, high);
            }
        }

        public static void merge1(int[] input, int low, int middle, int high)
        {
            int left = low;
            int right = middle + 1;
            int tmpIndex = 0;

            int[] tmp = new int[high - low + 1];

            while(left <= middle && right <= high)
            {
                if(input[left] <= input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left++;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right++;
                }
                tmpIndex++;
            }

            while(left <= middle)
            {
                tmp[tmpIndex] = input[left];
                left++;
                tmpIndex++;
            }

            while(right <= high)
            {
                tmp[tmpIndex] = input[right];
                right++;
                tmpIndex++;
            }

            for(int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }
        }

        public static int[] mergeSort2(int[] input, int low, int high)
        {
            if(low < high)
            {
                int middle = (low + high) / 2;
                int[] leftA = mergeSort2(input, low, middle);
                int[] rightA = mergeSort2(input, middle + 1, high);
                return merge2(leftA, rightA);
            }
            else
            {
                return new int[] { input[low] };
            }
        }

        public static int[] merge2(int[] leftA, int[] rightA)
        {
            int[] tmp = new int[leftA.Length + rightA.Length];

            int left = 0;
            int right = 0;
            int tmpIndex = 0;

            while(left < leftA.Length && right < rightA.Length)
            {
                if(leftA[left] <= rightA[right])
                {
                    tmp[tmpIndex] = leftA[left];
                    left++;
                }
                else
                {
                    tmp[tmpIndex] = rightA[right];
                    right++;
                }
                tmpIndex++;
            }

            while(left < leftA.Length)
            {
                tmp[tmpIndex] = leftA[left];
                left++;
                tmpIndex++;
            }

            while(right < rightA.Length)
            {
                tmp[tmpIndex] = rightA[right];
                right++;
                tmpIndex++;
            }

            return tmp;
        }
    }
}