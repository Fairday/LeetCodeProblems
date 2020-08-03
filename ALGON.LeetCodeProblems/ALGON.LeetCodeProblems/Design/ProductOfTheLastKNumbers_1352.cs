using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Design
{
    /*Implement the class ProductOfNumbers that supports two methods:

    1. add(int num)

    Adds the number num to the back of the current list of numbers.
    2. getProduct(int k)

    Returns the product of the last k numbers in the current list.
    You can assume that always the current list has at least k numbers.
    At any time, the product of any contiguous sequence of numbers will fit into a single 32-bit integer without overflowing.



    Example:

    Input
    ["ProductOfNumbers", "add", "add", "add", "add", "add", "getProduct", "getProduct", "getProduct", "add", "getProduct"]
    [[], [3], [0], [2], [5], [4], [2], [3], [4], [8], [2]]

    Output
    [null, null, null, null, null, null, 20, 40, 0, null, 32]

    Explanation
    ProductOfNumbers productOfNumbers = new ProductOfNumbers();
        productOfNumbers.add(3);        // [3]
    productOfNumbers.add(0);        // [3,0]
    productOfNumbers.add(2);        // [3,0,2]
    productOfNumbers.add(5);        // [3,0,2,5]
    productOfNumbers.add(4);        // [3,0,2,5,4]
    productOfNumbers.getProduct(2); // return 20. The product of the last 2 numbers is 5 * 4 = 20
    productOfNumbers.getProduct(3); // return 40. The product of the last 3 numbers is 2 * 5 * 4 = 40
    productOfNumbers.getProduct(4); // return 0. The product of the last 4 numbers is 0 * 2 * 5 * 4 = 0
    productOfNumbers.add(8);        // [3,0,2,5,4,8]
    productOfNumbers.getProduct(2); // return 32. The product of the last 2 numbers is 4 * 8 = 32 
 

    Constraints:

    There will be at most 40000 operations considering both add and getProduct.
    0 <= num <= 100
    1 <= k <= 40000*/
    public class ProductOfNumbers1
    {
        Stack<int> stack;
        Dictionary<int, int> cached;

        public ProductOfNumbers1()
        {
            stack = new Stack<int>();
            cached = new Dictionary<int, int>();
        }

        public void Add(int num)
        {
            stack.Push(num);

            if (cached.Count != 0)
                cached.Clear();
        }

        // O(N^2)
        public int GetProduct(int k)
        {
            if (cached.ContainsKey(k))
                return cached[k];

            var temp = new Stack<int>();
            var res = 1;
            var depth = 1;
            while (depth <= k)
            {
                var el = stack.Pop();
                res *= el;
                temp.Push(el);
                cached[depth] = res;
                depth++;
            }

            while (temp.Count > 0)
                stack.Push(temp.Pop());

            return res;
        }
    }

    /**
     * Your ProductOfNumbers object will be instantiated and called as such:
     * ProductOfNumbers obj = new ProductOfNumbers();
     * obj.Add(num);
     * int param_2 = obj.GetProduct(k);
     */

    public class ProductOfNumbers2
    {
        List<int> ls;

        public ProductOfNumbers2()
        {
            ls = new List<int>();
            ls.Add(1);
        }

        public void Add(int num)
        {
            if (num > 0)
                ls.Add(ls[ls.Count - 1] * num);
            else
            {
                ls = new List<int>();
                ls.Add(1);
            }
        }

        public int GetProduct(int k)
        {
            var sz = ls.Count;
            return k < sz ? ls[sz - 1] / ls[sz - k - 1] : 0;
        }
    }

    /**
     * Your ProductOfNumbers object will be instantiated and called as such:
     * ProductOfNumbers obj = new ProductOfNumbers();
     * obj.Add(num);
     * int param_2 = obj.GetProduct(k);
     */
}
