namespace ALGON.LeetCodeProblems.Design
{
    /*Design your implementation of the circular double-ended queue(deque).

    Your implementation should support following operations:

    MyCircularDeque(k) : Constructor, set the size of the deque to be k.
     insertFront(): Adds an item at the front of Deque.Return true if the operation is successful.
     insertLast(): Adds an item at the rear of Deque. Return true if the operation is successful.
     deleteFront(): Deletes an item from the front of Deque. Return true if the operation is successful.
     deleteLast(): Deletes an item from the rear of Deque. Return true if the operation is successful.
     getFront(): Gets the front item from the Deque.If the deque is empty, return -1.
     getRear(): Gets the last item from Deque. If the deque is empty, return -1.
     isEmpty(): Checks whether Deque is empty or not.
     isFull(): Checks whether Deque is full or not.*/
    public class CircularDeque
    {
        int[] inner;
        int head = -1;
        int tail = -1;
        int capacity;

        /** Initialize your data structure here. Set the size of the deque to be k. */
        public CircularDeque(int k)
        {
            capacity = k;
            inner = new int[capacity];
        }

        /** Adds an item at the front of Deque. Return true if the operation is successful. */
        public bool InsertFront(int value)
        {
            if (IsFull())
            {
                return false;
            }
            else
            {
                if (IsEmpty())
                    InsertLast(value);
                else
                {
                    head = (head - 1) < 0 ? capacity - 1 : (head - 1);
                    inner[head] = value;
                }
                return true;
            }
        }

        /** Adds an item at the rear of Deque. Return true if the operation is successful. */
        public bool InsertLast(int value)
        {
            if (IsFull())
                return false;
            else
            {
                if (IsEmpty())
                    head = 0;

                tail = (tail + 1) % capacity;
                inner[tail] = value;
                return true;
            }
        }

        /** Deletes an item from the front of Deque. Return true if the operation is successful. */
        public bool DeleteFront()
        {
            if (IsEmpty())
                return false;

            else
            {
                if (head == tail)
                {
                    tail = -1;
                    head = -1;
                    return true;
                }

                head = (head + 1) % capacity;
                return true;
            }
        }

        /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
        public bool DeleteLast()
        {
            if (IsEmpty())
                return false;
            else
            {
                if (head == tail)
                {
                    tail = -1;
                    head = -1;
                    return true;
                }

                tail = (tail - 1) % capacity;
                if (tail < 0)
                    tail = capacity - 1;
                return true;
            }
        }

        /** Get the front item from the deque. */
        public int GetFront()
        {
            if (IsEmpty())
                return -1;
            return inner[head];
        }

        /** Get the last item from the deque. */
        public int GetRear()
        {
            if (IsEmpty())
                return -1;
            return inner[tail];
        }

        /** Checks whether the circular deque is empty or not. */
        public bool IsEmpty()
        {
            return head == -1;
        }

        /** Checks whether the circular deque is full or not. */
        public bool IsFull()
        {
            return ((tail + 1) % capacity) == head;
        }
    }
}
