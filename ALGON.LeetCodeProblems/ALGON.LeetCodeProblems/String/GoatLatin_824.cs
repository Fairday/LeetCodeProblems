using System.Collections.Generic;
using System.Text;

namespace ALGON.LeetCodeProblems.PString
{
    //A sentence S is given, composed of words separated by spaces.Each word consists of lowercase and uppercase letters only.

    //We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)

    //The rules of Goat Latin are as follows:

    //If a word begins with a vowel(a, e, i, o, or u), append "ma" to the end of the word.
    //For example, the word 'apple' becomes 'applema'.


    //If a word begins with a consonant (i.e.not a vowel), remove the first letter and append it to the end, then add "ma".
    //For example, the word "goat" becomes "oatgma".

    //Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
    //For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
    //Return the final sentence representing the conversion from S to Goat Latin.

    //Example 1:

    //Input: "I speak Goat Latin"
    //Output: "Imaa peaksmaaa oatGmaaaa atinLmaaaaa"
    //Example 2:

    //Input: "The quick brown fox jumped over the lazy dog"
    //Output: "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa"

    //Notes:

    //S contains only uppercase, lowercase and spaces.Exactly one space between each word.
    //1 <= S.length <= 150.
    //https://leetcode.com/problems/goat-latin/solution/
    public class Solution_824
    {
        //Time: O(n + k^2)
        //Space: O(n^2)
        public string ToGoatLatin(string S)
        {
            if (string.IsNullOrEmpty(S))
                return "";

            var words = S.Split(' ');

            var sb = new StringBuilder();
            var postfix = "a";

            var vowels = new HashSet<char>();
            vowels.Add('a');
            vowels.Add('e');
            vowels.Add('i');
            vowels.Add('o');
            vowels.Add('u');
            vowels.Add('A');
            vowels.Add('E');
            vowels.Add('I');
            vowels.Add('O');
            vowels.Add('U');

            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                // started with vowel
                if (vowels.Contains(word[0]))
                {
                    var gl = word + "ma";
                    sb.Append(gl);
                }
                else
                {
                    var gl = word.Substring(1, word.Length - 1) + word[0] + "ma";
                    sb.Append(gl);
                }

                sb.Append(postfix);
                // O(1, 2, 3, k ^ 2)
                postfix += "a";
                sb.Append(" ");
            }

            return sb.ToString().Trim(' ');
        }
    }
}
