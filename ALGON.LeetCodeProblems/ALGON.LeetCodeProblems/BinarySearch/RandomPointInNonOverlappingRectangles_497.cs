using System;
using System.Collections.Generic;
using System.Linq;

namespace ALGON.LeetCodeProblems.BinarySearch
{
    //Given a list of non-overlapping axis-aligned rectangles rects, write a function pick which randomly and uniformily picks an integer point in the space covered by the rectangles.

    //Note:

    //An integer point is a point that has integer coordinates. 
    //A point on the perimeter of a rectangle is included in the space covered by the rectangles. 
    //ith rectangle = rects[i] = [x1, y1, x2, y2], where[x1, y1] are the integer coordinates of the bottom-left corner, and[x2, y2] are the integer coordinates of the top-right corner.
    //length and width of each rectangle does not exceed 2000.
    //1 <= rects.length <= 100
    //pick return a point as an array of integer coordinates[p_x, p_y]
    //pick is called at most 10000 times.
    //Example 1:

    //Input: 
    //["Solution","pick","pick","pick"]
    //[[[[1,1,5,5]]],[],[],[]]
    //Output: 
    //[null,[4,1],[4,1],[3,3]]
    //Example 2:

    //Input: 
    //["Solution","pick","pick","pick","pick","pick"]
    //    [[[[-2,-2,-1,-1],[1,0,3,0]]],[],[],[],[],[]]
    //Output: 
    //[null,[-1,-2],[2,0],[-2,-1],[3,0],[-2,-2]]
    //Explanation of Input Syntax:

    //The input is two lists: the subroutines called and their arguments.Solution's constructor has one argument, the array of rectangles rects. pick has no arguments. Arguments are always wrapped with a list, even if there aren't any.
    public class Solution_497
    {
        int PossiblePicks;
        SortedDictionary<int, int> RectangleVariantsDistribution;
        int[][] Rectangles;
        Random Randomizer;

        public Solution_497(int[][] rects)
        {
            Randomizer = new Random();
            Rectangles = rects;

            RectangleVariantsDistribution = new SortedDictionary<int, int>();

            for (int i = 0; i < rects.Length; i++)
            {
                var rect = rects[i];
                // + 1 because we need to include borders, 1155 -> 25, 1111 -> 1
                PossiblePicks += (rect[2] - rect[0] + 1) * (rect[3] - rect[1] + 1);
                RectangleVariantsDistribution.Add(PossiblePicks, i);
            }
        }

        public int[] Pick()
        {
            var randomVariant = Randomizer.Next(PossiblePicks) + 1;
            //Binary Search Tree with '>=' predicate implements binary seacrch index
            //Example: -2-2-1-1, 1030
            //PossiblePicks += (-1 - (-2) + 1) * (-1 - (-2) + 1) = 4 -> {4, 0}
            //PossiblePicks += (3 - 1 + 1) * (0 - 0 + 1) = 3 -> {7, 1}
            //Random from (0, 7) + 1 -> 5 + 1 = 6
            //Find in RectangleVariantsDistribution when first key more than index (6), this is 7
            //Use 7 to find random point in second rectange (1030)
            var rectIndex = RectangleVariantsDistribution.First(kvp => kvp.Key >= randomVariant).Value;
            return GetRandomPickInRectangle(Rectangles[rectIndex]);
        }

        int[] GetRandomPickInRectangle(int[] rect)
        {
            var x = Randomizer.Next(rect[0], rect[2] + 1);
            var y = Randomizer.Next(rect[1], rect[3] + 1);
            return new int[] { x, y };
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(rects);
     * int[] param_1 = obj.Pick();
     */
}
