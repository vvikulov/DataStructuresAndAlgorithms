namespace DSaA
{
    class ShellSort
    {
        public static void shellSort1(int[] a)
        {
            int length = a.Length;

            for(int interval = length / 2; interval > 0; interval /= 2)
            {
                for(int i = interval; i < length; i++)
                {
                    for(int j = i; j >= interval && a[j] < a[j - interval]; j -= interval)
                    {
                        swap(a, j, j - interval);
                    }
                }
            }
        }

        public static void shellSort2(int[] a)
        {
            int length = a.Length;
            int interval = 1;

            while(interval < length / 3)
            {
                interval = interval * 3 + 1;
            }

            while(interval >= 1)
            {
                for(int i = interval; i < length; i++)
                {
                    for(int j = i; j >= interval && a[j] < a[j - interval]; j -= interval)
                    {
                        swap(a, j, j - interval);
                    }
                }

                interval = interval / 3;
            }
        }

        private static void swap(int[] a, int ind1, int ind2)
        {
            int temp = a[ind1];
            a[ind1] = a[ind2];
            a[ind2] = temp;
        }
    }
}