namespace ALGON.LeetCodeProblems.Design
{
    /*Design your implementation of the circular queue.The circular queue is a linear data structure in which the operations are performed based on FIFO(First In First Out) principle and the last position is connected back to the first position to make a circle.It is also called "Ring Buffer".


     One of the benefits of the circular queue is that we can make use of the spaces in front of the queue. In a normal queue, once the queue becomes full, we cannot insert the next element even if there is a space in front of the queue. But using the circular queue, we can use the space to store new values.

     Your implementation should support following operations:

    MyCircularQueue(k) : Constructor, set the size of the queue to be k.
        Front: Get the front item from the queue.If the queue is empty, return -1.
        Rear: Get the last item from the queue.If the queue is empty, return -1.
        enQueue(value) : Insert an element into the circular queue.Return true if the operation is successful.
        deQueue(): Delete an element from the circular queue.Return true if the operation is successful.
        isEmpty(): Checks whether the circular queue is empty or not.
        isFull(): Checks whether the circular queue is full or not.


    Example:

        MyCircularQueue circularQueue = new MyCircularQueue(3); // set the size to be 3
            circularQueue.enQueue(1);  // return true
        circularQueue.enQueue(2);  // return true
        circularQueue.enQueue(3);  // return true
        circularQueue.enQueue(4);  // return false, the queue is full
        circularQueue.Rear();  // return 3
        circularQueue.isFull();  // return true
        circularQueue.deQueue();  // return true
        circularQueue.enQueue(4);  // return true
        circularQueue.Rear();  // return 4
 
    Note:

        All values will be in the range of[0, 1000].
        The number of operations will be in the range of[1, 1000].
        Please do not use the built-in Queue library.*/
    public class OptimizedSpaceCapacityQueue
    {
        int[] inner;
        int head = -1;
        int tail = -1;
        int capacity;

        /** Initialize your data structure here. Set the size of the queue to be k. */
        public OptimizedSpaceCapacityQueue(int k)
        {
            inner = new int[k];
            capacity = k;
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            if (IsFull())
                return false;
            else
            {
                if (IsEmpty())
                    head = 0;

                //example: capacity 5, tail = 4, we need to reuse space of queue -> (4 + 1) % 5 = 0 (from start)
                tail = (tail + 1) % capacity;
                inner[tail] = value;
                return true;
            }
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {
            if (IsEmpty())
                return false;

            if (head == tail)
            {
                tail = -1;
                head = -1;
                return true;
            }
            //example: capacity 5, tail = 0, head = 4, we need to dequeue new elements frm start of queue -> (4 + 1) % 5 = 0 (from start)   
            head = (head + 1) % capacity;
            return true;

        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (IsEmpty())
                return -1;
            else
                return inner[head];
        }

        /** Get the last item from the queue. */
        public int Rear()
        {
            if (IsEmpty())
                return -1;
            else
                return inner[tail];
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {
            return head == -1;
        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {
            return ((tail + 1) % capacity) == head;
        }
    }

    /**
     * Your MyCircularQueue object will be instantiated and called as such:
     * MyCircularQueue obj = new MyCircularQueue(k);
     * bool param_1 = obj.EnQueue(value);
     * bool param_2 = obj.DeQueue();
     * int param_3 = obj.Front();
     * int param_4 = obj.Rear();
     * bool param_5 = obj.IsEmpty();
     * bool param_6 = obj.IsFull();
     */
}
