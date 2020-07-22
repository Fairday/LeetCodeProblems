using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
  /*Design and implement a data structure for Least Recently Used(LRU) cache.It should support the following operations: get and put.

    get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    put(key, value) - Set or insert the value if the key is not already present.When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

    The cache is initialized with a positive capacity.

    Follow up:
    Could you do both operations in O(1) time complexity?

    Example:

    LRUCache cache = new LRUCache(2  capacity  );

        cache.put(1, 1);
    cache.put(2, 2);
    cache.get(1);        returns 1
    cache.put(3, 3);     evicts key 2
    cache.get(2);        returns -1 (not found)
    cache.put(4, 4);     evicts key 1
    cache.get(1);        returns -1 (not found)
    cache.get(3);        returns 3
    cache.get(4);        returns 4*/
    public class LRUCache
    {
        internal class CacheItem
        {
            public int key;
            public int val;
            public CacheItem next;
            public CacheItem prev;

            public CacheItem(int key, int val)
            {
                this.key = key;
                this.val = val;
            }
        }

        int _Capacity;
        Dictionary<int, CacheItem> _CachedItems;
        CacheItem _Head;
        CacheItem _Tail;

        public LRUCache(int capacity)
        {
            _Capacity = capacity;
            _CachedItems = new Dictionary<int, CacheItem>(_Capacity);
            _Head = new CacheItem(-1, -1); // fake item
            _Tail = _Head;
        }

        public int Get(int key)
        {
            if (_CachedItems.ContainsKey(key))
            {
                Update(key, _CachedItems[key].val);
                return _CachedItems[key].val;
            }
            else
            {
                return -1;
            }
        }

        void Remove(int key)
        {
            var item = _CachedItems[key];
            RemoveFromLinkedList(item);
            _CachedItems.Remove(key);
        }

        void RemoveFromLinkedList(CacheItem item)
        {
            if (item == _Tail) 
            {
                _Tail = _Tail.prev;
            }
            else
            {
                var prev = item.prev;
                var next = item.next;
                prev.next = next;
                if (next != null) next.prev = prev;
            }
        }

        public void Put(int key, int val)
        {
            if (_CachedItems.ContainsKey(key)) 
                Update(key, val);
            else
            {
                if (_CachedItems.Count == _Capacity) RemoveOldest();
                PutNewest(key, val);
            }
        }

        void RemoveOldest()
        {
            var oldest = _Head.next;
            RemoveFromLinkedList(oldest);
            _CachedItems.Remove(oldest.key);
        }

        void PutNewest(int key, int val)
        {
            var item = new CacheItem(key, val);
            _CachedItems[key] = item;
            _Tail.next = item;
            item.prev = _Tail;
            _Tail = item;
        }

        void Update(int key, int val)
        {
            Remove(key);
            PutNewest(key, val);
        }
    }
}
