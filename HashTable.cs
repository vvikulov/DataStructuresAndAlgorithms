namespace DSaA
{
    class HashTable<T>
    {
        public class DataItem<T2>
        {
            public T2 data;
            public int key;
        }

        private DataItem<T>[] hashArray;

        public HashTable(int size)
        {
            hashArray = new DataItem<T>[size];
        }

        public DataItem<T> search(int key)
        {
            int hashIndex = hashCode(key);

            while(hashArray[hashIndex] != null)
            {
                if(hashArray[hashIndex].key == key)
                {
                    return hashArray[hashIndex];
                }

                hashIndex++;
                hashIndex %= hashArray.Length;
            }

            return null;
        }

        public void insert(int key, T data)
        {
            DataItem<T> item = new DataItem<T>();
            item.key = key;
            item.data = data;

            int hashIndex = hashCode(key);

            //move in array until an empty or deleted cell
            while(hashArray[hashIndex] != null && hashArray[hashIndex].key != -1)
            {
                hashIndex++;
                hashIndex %= hashArray.Length;
            }

            hashArray[hashIndex] = item;
        }

        public DataItem<T> delete(int key)
        {
            int hashIndex = hashCode(key);

            while(hashArray[hashIndex] != null)
            {
                if(hashArray[hashIndex].key == key)
                {
                    DataItem<T> temp = hashArray[hashIndex];
                    DataItem<T> dummyItem = new DataItem<T>();
                    dummyItem.key = -1;
                    hashArray[hashIndex] = dummyItem;
                    return temp;
                }

                hashIndex++;
                hashIndex %= hashArray.Length;
            }

            return null;
        }

        private int hashCode(int key)
        {
            return key % hashArray.Length;
        }
    }
}
