using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALGON.LeetCodeProblems.BitManipulation
{
    /*Given a positive integer num, output its complement number.The complement strategy is to flip the bits of its binary representation.

    Example 1:

    Input: num = 5
    Output: 2
    Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.
    Example 2:

    Input: num = 1
    Output: 0
    Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.
 

    Constraints:

    The given integer num is guaranteed to fit within the range of a 32-bit signed integer.
    num >= 1
    You could assume no leading zero bit in the integer’s binary representation.
    This question is the same as 1009: https://leetcode.com/problems/complement-of-base-10-integer/*/
    public class Solution_476
    {
        public int FindComplement1(int num)
        {
            var binary = Convert.ToString(num, 2);
            var bitArray = new BitArray(binary.Select(b => b == '1' ? true : false).ToArray());
            bitArray.Not();
            var inversed = new StringBuilder();
            foreach (var item in bitArray)
            {
                var bit = (bool)item == true ? "1" : "0";
                inversed.Append(bit);
            }
            return Convert.ToInt32(inversed.ToString(), 2);
        }
        // To find complement of num = 5 which is 101 in binary.
        // First ~num gives ...11111010 but we only care about the rightmost 3 bits.
        // Then to erase the 1s before 010 we can add 1000    
        public int FindComplement(int num)
        {
            // 5 -> 0101 => Integer.highestOneBit(num) == 0100;
            // mask:   highestOneBit << 1   =>   0100 << 1   =>   1000
            // mask "-1":    1000 - 1  == 0111
            var mask = (HighestOneBit(num) << 1) - 1;
            // ~num   =>   5 is 0101  =>   ~5 is 1010, but we need only last 3 bits
            // ~num & mask    =>    1010 & 0111 == 0010    =>   res = 2
            return ~num & mask;
        }

        int HighestOneBit(int number)
        {
            return (int)Math.Pow(2, Convert.ToString(number, 2).Length - 1);
        }
    }
}
