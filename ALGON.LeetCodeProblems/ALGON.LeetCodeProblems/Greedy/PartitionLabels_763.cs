using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.Greedy
{
    public class Solution_763
    {
        //TC: O(N)
        //SC: O(1)
        public IList<int> PartitionLabels(string S)
        {
            var lastOccurs = new int[26];
            //Find when letter last occurs in S
            //For example: abacbx
            //a last occurs on 2
            //b last occurs on 4
            //c last occurs on 3
            //x last occrus on 5
            for (int i = 0; i < S.Length; i++)
                lastOccurs[S[i] - 'a'] = i;

            var maxEnd = 0; var start = 0;
            var ans = new List<int>();
            for (int i = 0; i < S.Length; i++)
            {
                var letter = S[i];
                //Find letter that occurs last of partition
                //For example: abacbx
                //b last occurs on 4 and partition all before index 4 in label
                //abacb - label, maxEnd = 4, i = 4
                maxEnd = Math.Max(maxEnd, lastOccurs[letter - 'a']);
                //if end of partition equals current character position
                if (maxEnd == i)
                {
                    ans.Add(maxEnd - start + 1);
                    start = i + 1;
                }
            }

            return ans;
            //abacbx
            //a = 0
            //b = 1
            //a = 2
            //c = 3
            //b = 4
            //x = 5
            //Queueu

            //a = 2
            //b = 4
            //c = 3
            //x = 5

            //j = 2 (a last occurs on 2) i = 0
            //j = 4 (b last occurs on 4) i = 1
            //j = 4 (a last occurs on 2) i = 2
            //j = 4 (c last occurs on 3) i = 3
            //j = 4 (b last occurs on 4) i = 4
            //i = j -> add(4 - 0 + 1) -> add(5)
            //anchor = i + 1= 5 
            //j = 5 (x last occurs on 5) i = 5
            //i = j -> add(5 - 5 + 1) -> add(1)
            //anchor = i + 1 = 6
        }
    }
}
