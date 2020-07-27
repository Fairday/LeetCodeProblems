namespace ALGON.LeetCodeProblemsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            int buff = 0;
            string s = "abcd";
            string t = "abcd";
            for (int i = 0; i < s.Length; i++)
            {
                var x1 = (int)s[i];
                var b1 = System.Convert.ToString(x1, 2);
                var b2 = System.Convert.ToString(buff, 2);
                var x2 = buff ^ x1;
                buff = x2;
            }
            for (int i = 0; i < t.Length; i++)
            {
                var x1 = (int)t[i];
                var x2 = buff ^ x1;
                buff = x2;
            }
            var r = (char)buff;
        }
    }
}
