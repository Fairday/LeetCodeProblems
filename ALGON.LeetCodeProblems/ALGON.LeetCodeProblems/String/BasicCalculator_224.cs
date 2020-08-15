using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.String
{
    /*Implement a basic calculator to evaluate a simple expression string.
    The expression string may contain open(and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces.

    Example 1:

    Input: "1 + 1"
    Output: 2
    Example 2:

    Input: " 2-1 + 2 "
    Output: 3
    Example 3:

    Input: "(1+(4+5+2)-3)+(6+8)"
    Output: 23
    Note:
    You may assume that the given expression is always valid.
    Do not use the eval built-in library function.*/
    public class Solution_224
    {
        //Time: O(n)
        //Space: O(n)
        public int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var tokens = new Stack<char>();
            for (int i = s.Length - 1; i >= 0; i--)
                if (s[i] != ' ')
                    tokens.Push(s[i]);

            return Helper(tokens);
        }

        int Helper(Stack<char> tokens)
        {
            var stack = new Stack<int>();
            var sign = '+';
            var num = 0;

            while (tokens.Count > 0)
            {
                var token = tokens.Pop();
                if (char.IsDigit(token))
                    num = num * 10 + token - '0';
                if (token == '(')
                    num = Helper(tokens);
                if (!char.IsDigit(token) || tokens.Count == 0)
                {
                    switch (sign)
                    {
                        case '+':
                            {
                                stack.Push(num);
                                break;
                            }
                        case '-':
                            {
                                stack.Push(-num);
                                break;
                            }
                    }

                    if (token == ')')
                        break;

                    sign = token;
                    num = 0;
                }
            }

            var sum = 0;
            while (stack.Count > 0)
                sum += stack.Pop();
            return sum;
        }
    }
}
