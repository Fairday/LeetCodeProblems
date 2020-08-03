using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    /*Implement the following operations of a stack using queues.

    push(x) -- Push element x onto stack.
    pop() -- Removes the element on top of the stack.
    top() -- Get the top element.
    empty() -- Return whether the stack is empty.
    Example:

    MyStack stack = new MyStack();

        stack.push(1);
    stack.push(2);  
    stack.top();   // returns 2
    stack.pop();   // returns 2
    stack.empty(); // returns false
    Notes:

    You must use only standard operations of a queue -- which means only push to back, peek/pop from front, size, and is empty operations are valid.
    Depending on your language, queue may not be supported natively. You may simulate a queue by using a list or deque(double-ended queue), as long as you use only standard operations of a queue.
    You may assume that all operations are valid (for example, no pop or top operations will be called on an empty stack).*/
    public class MyStack
    {
        Queue<int> q1;
        Queue<int> q2;
        int top;

        /** Initialize your data structure here. */
        public MyStack()
        {
            q1 = new Queue<int>();
            q2 = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            q1.Enqueue(x);
            top = x;
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            var actualTop = top;
            while (q1.Count > 1)
            {
                top = q1.Dequeue();
                q2.Enqueue(top);
            }
            q1.Dequeue();

            var temp = q1;
            q1 = q2;
            q2 = temp;

            return actualTop;
        }

        /** Get the top element. */
        public int Top()
        {
            return top;
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return q1.Count == 0;
        }
    }

    /**
     * Your MyStack object will be instantiated and called as such:
     * MyStack obj = new MyStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Top();
     * bool param_4 = obj.Empty();
     */
}
