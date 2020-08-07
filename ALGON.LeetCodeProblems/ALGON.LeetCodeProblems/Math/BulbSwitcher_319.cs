namespace ALGON.LeetCodeProblems.PMath
{
    /*There are n bulbs that are initially off.You first turn on all the bulbs. Then, you turn off every second bulb. On the third round, you toggle every third bulb (turning on if it's off or turning off if it's on). For the i-th round, you toggle every i bulb.For the n-th round, you only toggle the last bulb. Find how many bulbs are on after n rounds.

    Example:

    Input: 3
    Output: 1 
    Explanation: 
    At first, the three bulbs are [off, off, off].
    After first round, the three bulbs are [on, on, on].
    After second round, the three bulbs are [on, off, on].
    After third round, the three bulbs are [on, off, off]. 


    So you should return 1, because there is only one bulb is on.*/
    public class Solution_319
    {
        public int BulbSwitch(int n)
        {

            //1 -> 1
            //2 -> 1
            //3 -> 1
            //4 -> 2
            //5 -> 2
            //6 -> 2
            //7 -> 2
            //8 -> 2
            //9 -> 3
            //10 -> 3
            //11 -> 3
            //12 -> 3
            //13 -> 3
            //14 -> 3
            //15 -> 3
            //16 -> 4
            var count = 0;
            for (int i = 1; i * i <= n; i++)
                count++;
            return count;
        }
    }
}
