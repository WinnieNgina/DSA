﻿using System.Collections.Generic;

namespace DSA;

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
    public List<int> FindNumbers(int[] nums)
    {
        HashSet<int> num = new HashSet<int>();
        var numbers = new List<int>();
        for (int i = 1; i < nums.Length;i++)
        {
                num.Add(nums[i]);    
        }
        for (int j = 0; j < nums.Length; j++)
        {
            int x = nums[j] - 1;
            int y = nums[j] + 1;
            if (!num.Contains(x) && !nums.Contains(y))
            {
                numbers.Add(nums[j]);
            }
        }
        return numbers;
       
    }
    public bool CheckIfPangram(string sentence)
    {
        HashSet<char> chars = new();
        for (int i = 0; i < sentence.Length; i++)
        {
            chars.Add(sentence[i]);
        }
        for (char a = 'a'; a <= 'z'; a++)
        {
            if (!chars.Contains(a))
            {
                return false;
            }
        }
        return true;

    }
    public int MissingNumber(int[] nums)
    {
        HashSet<int> numbers = new();
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            numbers.Add(nums[i]);
        }
        for (int j = 0; j <= n; j++)
        {
            if (!numbers.Contains(j))
            {
                return j;
            }
        }
        return -1;

    }
    public int MissingNumberSol2(int[] nums)
    {
        int sum = 0;
        int totalSum = 0;
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            totalSum += i + 1;
        }
        return totalSum - sum;

    }
    public int CountElements(int[] arr)
    {
        HashSet<int> nums = new(arr);
        int count = 0;

        for (int j = 0; j < arr.Length; j++)
        {
            int x = arr[j] + 1;
            if (nums.Contains(x))
            {
                count++;
            }
        }
        return count;
    }
    public int Find_Longest_Substring(string s, int k)
    {
        var counts = new Dictionary<char, int>();
        int left = 0;
        int ans = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            if (counts.ContainsKey(c))
            {
                counts[c] ++;
            }
            else
            {
                counts[c] = 1;
            }


            while (counts.Count > k)
            {
                char remove = s[left];
                counts[remove]--;
                if (counts[remove] == 0)
                {
                    counts.Remove(remove);
                }

                left++;
            }
            int temp = right - left + 1;

            if (temp > ans)
            {
                ans = temp;
            }
        }
        return ans;
    }
    public IList<int> Intersection (int[][] arr)
    {
        int n = arr.GetLength(0);
        Dictionary <int, int> counts = new Dictionary<int, int>();
        for (int i = 0; i < arr[0].Length; i++)
        {
            int num = arr[0][i];
            counts[num] = 1;
        }
        for (int i = 1; i < n; i++)
        {
            for (int j = 0;  j < arr[i].Length; j++)
            {
                int num2 = arr[i][j];
                if (counts.ContainsKey(num2))
                {
                    counts[num2]++;
                }
            }
        }
       return counts
           .Where(v => v.Value == n)
           .Select(p => p.Key)
           .OrderBy(key => key)
           .ToList();
    }
    public bool AreOccurrencesEqual(string s)
    {
        Dictionary<char, int> chars = new();
        char c;
        for (int i = 0; i < s.Length; i++)
        {
            c = s[i];
            if (chars.ContainsKey(c))
            {
                chars[c] ++;
            }
            else
            {
                chars[c] = 1;
            }
        }
        char k = s[0];
        int num = chars[k];
        foreach (var item in chars.Values)
        {
            if (item != num)
            {
                return false;
            }
        }
        return true;
    }
    // Prefix Sum
    public int SubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> prefix = new();
        int count = 0;
        int sum = 0;
        prefix[0] = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            int temp = sum - k;
            if (prefix.ContainsKey(temp))
            {
                count += prefix[temp];
            }
            if (prefix.ContainsKey(sum))
            {
                prefix[sum]++;
            }
            else
            {
                prefix[sum] = 1;
            }
        }
        return count;
    }
    public int NumberOfSubarrays(int[] nums, int k)
    {
        Dictionary<int, int> prefix = new();
        prefix[0] = 1;
        int count = 0;
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = nums[i] % 2;
        }

        for (int j = 0; j < nums.Length; j++)
        {
            sum += nums[j];
            int temp = sum - k;
            if (prefix.ContainsKey(temp))
            {
                count += prefix[temp];
            }
            if (prefix.ContainsKey(sum))
            {
                prefix[sum]++;
            }
            else
            {
                prefix[sum] = 1;
            }
        }
        return count;
    }
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        Dictionary<int, int[]> counts = new();
        int winner;
        int loser;
        IList<int> wins = new List<int>();
        IList<int> lose = new List<int>();
        IList<IList<int>> answers = new List<IList<int>>();

        for (int i = 0; i < matches.Length; i++)
        {
            winner = matches[i][0];
            loser = matches[i][1];
            if (!counts.ContainsKey(winner))
            {
                counts[winner] = new int[2];
            }
            if (!counts.ContainsKey(loser))
            {
                counts[loser] = new int[2];
            }
            counts[winner][0]++;
            counts[loser][1]++;
        }
        foreach (int key in counts.Keys)
        {
            if (counts[key][1] == 0)
            {
                wins.Add(key);
            }
            if (counts[key][1] == 1)
            {
                lose.Add(key);
            }
        }
        wins = wins.OrderBy(x => x).ToList();
        lose = lose.OrderBy(x => x).ToList();
        answers.Add(wins);
        answers.Add(lose);
        return answers;
    }
    public int LargestUniqueNumber(int[] nums)
    {
        Dictionary<int, int> counts = new();
        int large = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            int key = nums[i];
            if (counts.ContainsKey(key))
            {
                counts[key]++;
            }
            else
            {
                counts[key] = 1;
            }
        }
        foreach (int key in counts.Keys)
        {
            if (counts[key] == 1)
            {
                if (key > large)
                {
                    large = key;
                }
            }
        }
        return large;

    }
}
