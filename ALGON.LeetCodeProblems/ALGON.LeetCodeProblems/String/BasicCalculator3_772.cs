using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.String
{
    //The expression string contains only non-negative integers, +, -, *, / operators, open(and closing parentheses ) and empty spaces.
    //Examples:
    //Input: "1 + 1" 
    //Return: 2
    //Input: " 6-4 / 2 " 
    //Return: 4
    //Input: "2*(5+5*2)/3+(6/2+8)" 
    //Return: 21
    //Input: "(2+6* 3+5- (3*14/7+2)*5)+3" 
    //Return: -12
    //Time: O(n)
    //Space: O(n)
    public class Solution_772
    {
        public int Calculate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                return 0;

            var tokens = new Stack<char>();
            for (int i = expression.Length - 1; i >= 0; i--)
                if (expression[i] != ' ')
                    tokens.Push(expression[i]);
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
                        case '*':
                            {
                                stack.Push(stack.Pop() * num);
                                break;
                            }
                        case '/':
                            {
                                stack.Push(stack.Pop() / num);
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
