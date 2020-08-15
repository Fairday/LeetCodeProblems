using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PString
{
    /*Implement a basic calculator to evaluate a simple expression string.

    The expression string contains only non-negative integers, +, -, *, / operators and empty spaces.The integer division should truncate toward zero.

    Example 1:

    Input: "3+2*2"
    Output: 7
    Example 2:

    Input: " 3/2 "
    Output: 1
    Example 3:

    Input: " 3+5 / 2 "
    Output: 5
    Note:

    You may assume that the given expression is always valid.
    Do not use the eval built-in library function.*/
    //Time: O(n)
    //Space: O(n)
    public class Solution_227
    {
        public int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            s = s.Replace(" ", "");

            var stack = new Stack<int>();
            var sign = '+';
            var num = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];

                if (char.IsDigit(ch))
                    num = num * 10 + ch - '0';
                if (!char.IsDigit(ch) || i == s.Length - 1)
                {
                    //previous sign
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
                    //assign new sigh
                    sign = ch;
                    num = 0;
                }
            }

            var res = 0;
            while (stack.Count > 0)
                res += stack.Pop();
            return res;
        }

        public int Calculate1(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var q = new Stack<string>();
            var l = s.Length;
            var i = 0;

            while (i < l)
            {
                SkipWhitespaces(ref i, l, s);
                var number = ParseDigit(ref i, l, s);
                if (number != string.Empty) 
                {
                    q.Push(number);
                    continue;
                }

                if (i >= l)
                    break;

                if (!IsPlusOrMinus(s[i]))
                {
                    var left = q.Pop();
                    var oper = s[i++];
                    var expression = new Stack<string>();
                    expression.Push(left);
                    expression.Push(oper.ToString());
                    var lastDigitFounded = false;
                    while (i < l && !lastDigitFounded)
                    {
                        SkipWhitespaces(ref i, l, s);
                        number = ParseDigit(ref i, l, s);

                        if (number != string.Empty)
                        {
                            expression.Push(number);
                            continue;
                        }

                        if (i >= l)
                            break;

                        if (IsPlusOrMinus(s[i]))
                            lastDigitFounded = true;
                        else
                        {
                            expression.Push(s[i++].ToString());
                        }
                    }
                    var res = Eval(expression);
                    q.Push(res.ToString());
                }
                else
                {
                    q.Push(s[i++].ToString());
                }
            }

            return Eval(q);
        }

        public Stack<string> ReverseStack(Stack<string> s)
        {
            var ls = new List<string>(s.Count);

            while (s.Count > 0)
                ls.Add(s.Pop());

            var reversed = new Stack<string>();

            foreach (var item in ls)
                reversed.Push(item);

            return reversed; 
        }

        public int Eval(Stack<string> expression)
        {
            expression = ReverseStack(expression);

            var left = string.Empty;
            var oper = string.Empty;
            var right = string.Empty;
            while (expression.Count > 0)
            {
                var next = expression.Pop();
                if (!IsOperator(next) && left == string.Empty)
                {
                    left = next;
                }
                else if (!IsOperator(next) && right == string.Empty)
                {
                    right = next;
                }
                else if (IsOperator(next))
                {
                    oper = next;
                }

                if (left != string.Empty && right != string.Empty && oper != string.Empty)
                {
                    left = Eval(left, right, oper).ToString();
                    right = string.Empty;
                    oper = string.Empty;
                }
            }
            return int.Parse(left);
        }

        int Eval(string left, string right, string oper)
        {
            Console.WriteLine(left);
            Console.WriteLine(oper);
            Console.WriteLine(right);
            var first = int.Parse(left);
            var second = int.Parse(right);

            switch (oper)
            {
                case "*":
                    {
                        return first * second;
                    }
                case "/":
                    {
                        return first / second;
                    }
                case "+":
                    {
                        return first + second;
                    }
                case "-":
                    {
                        return first - second;
                    }
            }

            throw new Exception("Unknown operator");
        }

        string ParseDigit(ref int i, int l, string s)
        {
            var number = string.Empty;
            while (i < l && char.IsDigit(s[i]))
            {
                number += s[i];
                i++;
            }

            return number;
        }

        bool IsOperator(string oper)
        {
            if ((oper[0] == '+') || (oper[0] == '-') || (oper[0] == '*') || (oper[0] == '/'))
                return true;
            else
                return false;
        }

        bool IsPlusOrMinus(char oper)
        {
            if (oper == '+' || oper == '-')
                return true;
            else
                return false;
        }

        void SkipWhitespaces(ref int i, int l, string s)
        {
            while (i < l && s[i] == ' ')
                i++;
        }
    }
}
