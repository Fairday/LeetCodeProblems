namespace Day6.SlidingWindow
{
    //Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.

    //In other words, return true if one of s1's permutations is the substring of s2.

    //Example 1:

    //Input: s1 = "ab", s2 = "eidbaooo"
    //Output: true
    //Explanation: s2 contains one permutation of s1("ba").
    //Example 2:

    //Input: s1 = "ab", s2 = "eidboaoo"
    //Output: false


    //Constraints:

    //1 <= s1.length, s2.length <= 104
    //s1 and s2 consist of lowercase English letters.
    public class PermutatioInString_567
    {
        //TC: O(l1 + 26 * (l2 - l1) ??? -> O(N)
        //SC: O(1)
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return false;

            int[] s1_map = new int[26];
            int[] s2_map = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                s1_map[s1[i] - 'a']++;
                //first sliding window of s1.Length
                s2_map[s2[i] - 'a']++;
            }

            for (int i = 0; i < s2.Length - s1.Length; i++)
            {
                if (IsEqual(s1_map, s2_map))
                    return true;
                else
                {
                    s2_map[s2[i + s1.Length] - 'a']++;
                    s2_map[s2[i] - 'a']--;
                }
            }

            return IsEqual(s1_map, s2_map);
        }

        private bool IsEqual(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
                if (arr1[i] != arr2[i])
                    return false;

            return true;
        }

        private bool res = false;

        //TC: O(N!)
        //SC: O(N^2) - depth of the  recursion tree
        //Time limit exceeded
        public bool CheckInclusion(string s1, string s2)
        {
            Permute(s1, s2, 0);
            return res;
        }

        private void Permute(string s1, string s2, int start)
        {
            if (start == s1.Length)
            {
                if (s2.Contains(s1))
                    res = true;
            }
            else
            {
                for (int i = start; i < s1.Length; i++)
                {
                    s1 = Swap(s1, start, i);
                    Permute(s1, s2, start + 1);
                    s1 = Swap(s1, start, i);
                }
            }
        }

        private string Swap(string s, int swapFirst, int swapSecond)
        {
            //swapping same char
            if (swapFirst == swapSecond)
                return s;
            //Console.WriteLine("swapFirst: " + swapFirst);
            //Console.WriteLine("swapSecond: " + swapSecond);     
            //Console.WriteLine("s: " + s);     
            var s1 = s.Substring(0, swapFirst);
            //Console.WriteLine("s1: " + s1);        
            var s2 = s.Substring(swapFirst + 1, swapSecond - swapFirst - 1);
            //Console.WriteLine("s2: " + s2);        
            var s3 = s.Substring(swapSecond + 1);
            //Console.WriteLine("s3: " + s3);

            var o = s1 + s[swapSecond] + s2 + s[swapFirst] + s3;
            //Console.WriteLine("o: " + o);
            return o;
        }
    }
}
