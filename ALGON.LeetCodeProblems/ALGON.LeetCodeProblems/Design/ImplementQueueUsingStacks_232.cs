using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    /*Implement the following operations of a queue using stacks.

    push(x) -- Push element x to the back of queue.
    pop() -- Removes the element from in front of queue.
    peek() -- Get the front element.
    empty() -- Return whether the queue is empty.
    Example:

    MyQueue queue = new MyQueue();

        queue.push(1);
    queue.push(2);  
    queue.peek();  // returns 1
    queue.pop();   // returns 1
    queue.empty(); // returns false
    Notes:

    You must use only standard operations of a stack -- which means only push to top, peek/pop from top, size, and is empty operations are valid.
    Depending on your language, stack may not be supported natively. You may simulate a stack by using a list or deque(double-ended queue), as long as you use only standard operations of a stack.
    You may assume that all operations are valid (for example, no pop or peek operations will be called on an empty queue).*/
    public class MyQueue
    {
        Stack<int> s1;
        Stack<int> s2;
        int front;

        /** Initialize your data structure here. */
        public MyQueue()
        {
            s1 = new Stack<int>();
            s2 = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            if (s1.Count == 0)
                front = x;
            s1.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            if (s2.Count == 0)
            {
                while (s1.Count > 0)
                    s2.Push(s1.Pop());
            }

            return s2.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            if (s2.Count == 0)
                return front;
            else
                return s2.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return s1.Count == 0 && s2.Count == 0;
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */
}
