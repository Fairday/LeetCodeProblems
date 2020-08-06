using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    /*Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right.You can only see the k numbers in the window. Each time the sliding window moves right by one position. Return the max sliding window.

    Follow up:
    Could you solve it in linear time?

    Example:

    Input: nums = [1, 3, -1, -3, 5, 3, 6, 7], and k = 3
    Output: [3,3,5,5,6,7]
    Explanation: 

    Window position                Max
    ---------------               -----
    [1  3  -1] -3  5  3  6  7       3
     1 [3  -1  -3] 5  3  6  7       3
     1  3 [-1  -3  5] 3  6  7       5
     1  3  -1 [-3  5  3] 6  7       5
     1  3  -1  -3 [5  3  6] 7       6
     1  3  -1  -3  5 [3  6  7]      7

    Constraints:

    1 <= nums.length <= 10^5
    -10^4 <= nums[i] <= 10^4
    1 <= k <= nums.length*/
    public class Solution_239
    {
        //Space O(n * k)
        //Time O(n * logn)
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { };

            var res = new int[nums.Length - k + 1];

            var maxHeap = new MaxHeap(k);
            var toDrop = new MaxHeap();

            for (int i = 0; i < k; i++)
            {
                maxHeap.Add(nums[i]);
            }

            var index = 0;
            res[index++] = maxHeap.Peek();
            for (int i = k; i < nums.Length && index < res.Length; i++)
            {
                if (nums[i - k] == maxHeap.Peek())
                {
                    maxHeap.Pop();
                }
                else
                {
                    toDrop.Add(nums[i - k]);
                }

                while (!toDrop.IsEmpty && maxHeap.Peek() == toDrop.Peek())
                {
                    maxHeap.Pop();
                    toDrop.Pop();
                }

                maxHeap.Add(nums[i]);
                res[index++] = maxHeap.Peek();
            }

            return res;
        }
    }

    public class MaxHeap
    {
        List<int> heap;
        int count = 0;

        public MaxHeap(int capacity = 0)
        {
            heap = new List<int>(capacity);
        }

        public bool IsEmpty => count == 0;

        //(N * logN)
        public void Add(int x)
        {
            heap.Add(x);
            count++;
            var i = count - 1;
            var parent = Parent(i);
            while (i >= 0 && heap[i] > heap[parent])
            {
                Swap(parent, i);
                i = parent;
                parent = Parent(i);
            }
        }

        public int Peek()
        {
            return heap[0];
        }

        public int Pop()
        {
            var top = heap[0];
            heap[0] = heap[count - 1];
            heap.RemoveAt(count - 1);
            count--;
            Heapify(0);
            return top;
        }

        void Heapify(int i)
        {
            var left = Left(i);
            var right = Right(i);
            var largest = i;

            if (left < count && heap[left] > heap[largest])
                largest = left;
            if (right < count && heap[right] > heap[largest])
                largest = right;

            if (largest != i)
            {
                Swap(largest, i);
                Heapify(largest);
            }
        }

        void Swap(int i, int j)
        {
            var temp = heap[j];
            heap[j] = heap[i];
            heap[i] = temp;
        }

        int Left(int i) => i * 2 + 1;
        int Right(int i) => i * 2 + 2;
        int Parent(int i) => (i - 1) / 2;
    }
}
