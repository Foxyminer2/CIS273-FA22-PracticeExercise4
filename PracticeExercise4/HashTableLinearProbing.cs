using System;

namespace PracticeExercise4
{
	public class HashTableLinearProbing<K,V>: IHashTable<K,V>
	{

        private Bucket<K, V>[] buckets;
        private int initialCapacity = 16;


		public HashTableLinearProbing()
		{
            buckets = new Bucket<K, V>[initialCapacity];

            for(int i= 0; i < buckets.Length; i++)
            {
                buckets[i] = new Bucket<K, V>();
            }

		}
        private int count;
        public int Count => count;

        private readonly double MAX_LOAD_FACTOR = 0.6;
        public double LoadFactor => count / (double)buckets.Length;

        public bool Add(K key, V value)
        {

            if(LoadFactor > MAX_LOAD_FACTOR)
            {
                Resize();
            }
            //if hashtable add else dont

            //find hash
            int hash = Hash(key);

            //find starting index
            int startingIndex = hash % buckets.Length;
            int bucketIndex = startingIndex;

            //if key already exists, then update it
            while (buckets[bucketIndex].State == BucketState.Full)
            {
                //if the key already exists, then update it
                if (buckets[bucketIndex].Key.Equals(key))
                {
                    buckets[bucketIndex].Value = value;
                    return true;
                }

                bucketIndex = (bucketIndex + 1) % buckets.Length;

                if (bucketIndex == startingIndex)
                {
                    throw new OutOfMemoryException();
                }
            }

            //if key doesnt exists, add it
            buckets[bucketIndex].Key = key;
            buckets[bucketIndex].Value = value;
            buckets[bucketIndex].State = BucketState.Full;
            count++;
            return false;
        }

        // O(?)
        public bool ContainsKey(K key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsValue(V value)
        {
            throw new NotImplementedException();
        }

        public V Get(K key)
        {
            throw new NotImplementedException();
        }

        public List<K> GetKeys()
        {
            throw new NotImplementedException();
        }

        public List<V> GetValues()
        {
            throw new NotImplementedException();
        }

        public bool Remove(K key)
        {
            throw new NotImplementedException();
        }

        private void Resize()
        {
            var newBuckets = new Bucket<K, V>[2 * buckets.Length];
            var oldBuckets = buckets;

            buckets = newBuckets;
            for(int i=0; i < buckets.Length; i++)
            {
                buckets[i] = new Bucket<K, V>();
            }

            count = 0;

            //rehash all the old/existing buckets into the new array/hashtable
            foreach (var bucket in oldBuckets)
            {
                if (bucket.State == BucketState.Full)
                {
                    Add(bucket.Key, bucket.Value);
                }
            }
        }

        private int Hash(K key)
        {
            int hash = key.GetHashCode();

            return hash < 0 ? -hash : hash;
        }
    }
}

