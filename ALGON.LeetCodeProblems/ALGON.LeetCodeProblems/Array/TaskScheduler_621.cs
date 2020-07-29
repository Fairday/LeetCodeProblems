using System;
using System.Collections.Generic;

namespace ALGON.LeetCodeProblems.PArray
{
    public class Solution_621
    {
        public int LeastInterval1(char[] tasks, int n)
        {
            if (n == 0)
                return tasks.Length;

            int[] cooldowns = new int[26];
            var tasksSet = new HashSet<int>();
            int[] tasksMap = new int[26];

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasksSet.Add(tasks[i] - 'A'))
                    cooldowns[tasks[i] - 'A'] = -1;
                tasksMap[tasks[i] - 'A']++;
            }

            var count = 0;
            var tasksToProcess = tasks.Length;
            int t = 0;
            while (tasksToProcess > 0)
            {
                foreach (var task in tasksSet)
                {
                    if (cooldowns[task] >= 0)
                        cooldowns[task]--;
                }

                if (cooldowns[tasks[t] - 'A'] == -1 && tasksMap[tasks[t] - 'A'] > 0)
                {
                    cooldowns[tasks[t] - 'A'] = n;
                    count++;
                    tasksMap[tasks[t] - 'A']--;
                    t++;
                    tasksToProcess--;
                }
                else
                {
                    var needIdle = false;

                    foreach (var task in tasksSet)
                    {
                        if (cooldowns[task] == -1 && tasksMap[task] > 0)
                        {
                            cooldowns[task] = n;
                            count++;
                            needIdle = false;
                            tasksMap[task]--;
                            tasksToProcess--;
                            break;
                        }
                        else if (tasksMap[task] > 0)
                        {
                            needIdle = true;
                        }
                    }
                    if (needIdle)
                        count++;
                }
            }
            return count;
        }

        public int LeastInterval(char[] tasks, int n)
        {
            int[] char_map = new int[26];
            for (int i = 0; i < tasks.Length; i++)
                char_map[tasks[i] - 'A']++;
            Array.Sort(char_map);
            //A-idle-idle-A-idle-idle-A //4 idle, not 6, we dont need 2 idles after last
            int max_val = char_map[25] - 1;
            int idle_slots = max_val * n;
            for (int i = 24; i >= 0; i--)
            {
                idle_slots -= Math.Min(char_map[i], max_val);
            }
            return idle_slots > 0 ? idle_slots + tasks.Length : tasks.Length;
        }
    }
}
