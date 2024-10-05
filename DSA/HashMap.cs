﻿namespace DSA;

public class HashMap
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            int complement = target - num;

            if (dic.ContainsKey(complement))
            {
                return new int[] { dic[complement], i };
            }

            dic[num] = i;
        }

        return new int[] { -1, -1 };
    }
    public char RepeatedCharacter(string s)
    {
        HashSet<char> chars = new HashSet<char>();
        int i = 1;
        char c = s[1];
        chars.Add(s[0]);
        while (!chars.Contains(c))
        {
            i++;
            chars.Add(c);
            c = s[i];
        }
        return c;
    }
}
