namespace ALGON.LeetCodeProblems.DynamicProgramming
{
    /*A message containing letters from A-Z is being encoded to numbers using the following mapping:

    'A' -> 1
    'B' -> 2
    ...
    'Z' -> 26
    Given a non-empty string containing only digits, determine the total number of ways to decode it.

    Example 1:

    Input: "12"
    Output: 2
    Explanation: It could be decoded as "AB" (1 2) or "L" (12).
    Example 2:

    Input: "226"
    Output: 3
    Explanation: It could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).*/
    public class Solution_91
    {
        // https://leetcode.com/problems/decode-ways/discuss/30358/java-clean-dp-solution-with-explanation
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            var dp = new int[s.Length + 1];
            dp[0] = 1;
            //if s == "0"
            dp[1] = s[0] == '0' ? 0 : 1;
            for (int i = 2; i <= s.Length; i++)
            {
                //take one digit
                var first = int.Parse(s.Substring(i - 1, 1));
                //take two digits
                var second = int.Parse(s.Substring(i - 2, 2));

                if (first >= 1 && first <= 9)
                {
                    dp[i] += dp[i - 1];
                }

                if (second >= 10 && second <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }
            return dp[s.Length];
        }
    }
}
