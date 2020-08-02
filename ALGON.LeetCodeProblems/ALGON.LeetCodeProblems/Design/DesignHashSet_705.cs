using System;

namespace ALGON.LeetCodeProblems.Design
{
    /*Design a HashMap without using any built-in hash table libraries.

    To be specific, your design should include these functions:

    put(key, value) : Insert a(key, value) pair into the HashMap.If the value already exists in the HashMap, update the value.
    get(key): Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key.
    remove(key) : Remove the mapping for the value key if this map contains the mapping for the key.


    Example:


    MyHashMap hashMap = new MyHashMap();
        hashMap.put(1, 1);          
    hashMap.put(2, 2);         
    hashMap.get(1);            // returns 1
    hashMap.get(3);            // returns -1 (not found)
    hashMap.put(2, 1);          // update the existing value
    hashMap.get(2);            // returns 1 
    hashMap.remove(2);          // remove the mapping for 2
    hashMap.get(2);            // returns -1 (not found) 

    Note:

    All keys and values will be in the range of[0, 1000000].
    The number of operations will be in the range of[1, 10000].
    Please do not use the built-in HashMap library.*/
    public class MyHashSet
    {

        int[] hash;
        /** Initialize your data structure here. */
        public MyHashSet()
        {
            hash = new int[10];
        }

        public void Add(int key)
        {
            if (key >= hash.Length)
                hash = ExtendArr(hash, key);
            hash[key] = 1;
        }

        public void Remove(int key)
        {
            if (key < hash.Length)
                hash[key] = 0;
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            if (key >= hash.Length)
                return false;
            return hash[key] == 1 ? true : false;
        }

        int[] ExtendArr(int[] arr, int target)
        {
            var newArr = new int[target + 1];
            Array.Copy(arr, 0, newArr, 0, arr.Length);
            return newArr;
        }
    }

    /**
     * Your MyHashSet object will be instantiated and called as such:
     * MyHashSet obj = new MyHashSet();
     * obj.Add(key);
     * obj.Remove(key);
     * bool param_3 = obj.Contains(key);
     */
}
