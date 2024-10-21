using System;
using System.Collections.Generic;
using System.Collections.Immutable;

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
    public int MaxNumberOfBalloons(string text)
    {
        Dictionary<char, int> counts = new();
        foreach (char c in "balloon")
        {
            counts[c] = 0;
        }
        for (int i = 0; i < text.Length; i++)
        {
            char key = text[i];
            if (counts.ContainsKey(key))
            {
                counts[key]++;
            }
        }
        int val = counts['b'] >= counts['a'] ? counts['a'] : counts['b'];
        val = val > counts['n'] ? counts['n'] : val;
        int twin = counts['l'] >= counts['o'] ? counts['o'] : counts['l'];
        twin = twin / 2;
        return val >= twin ? twin : val;
    }
    public int RearrangeCharacters(string s, string target)
    {
        Dictionary<char, int> counts = new();
        Dictionary<char, int> nums = new();
        foreach (char c in target)
        {
            counts[c] = 0;
            if (nums.ContainsKey(c))
            {
                nums[c]++;
            }
            else
            {
                nums[c] = 1;
            }
        }
        foreach (char c in s)
        {
            if (counts.ContainsKey(c))
            {
                counts[c]++;
            }
        }
        int val = counts[target[0]] / nums[target[0]];
        for (int i = 1; i < target.Length; i++)
        {
            char c = target[i];
            int temp = counts[c] / nums[c];
            if (temp < val)
            {
                val = temp;
            }
        }
        return val;
    }
    public IList<IList<string>> GroupAnagrams (string[] s)
    {
        Dictionary<string,  IList<string>> counts = new();  
        List<IList<string>> ans = new();
        foreach (string str in s)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            string key = new string(chars);
            if (counts.ContainsKey(key))
            {
                counts[key].Add(str);
            }
            else
            {
                counts[key] = new List<string> { str };
            }
        }
        foreach(string key in counts.Keys)
        {
            ans.Add(counts[key]);
        }
        return ans;

    }
    public int MinimumCardPickup(int[] cards)
    {
        Dictionary<int, List<int>> counts = new();
        int ans = -1;
        for (int i = 0; i < cards.Length; i++)
        {
            int key = cards[i];
            if (counts.ContainsKey(key))
            {
                counts[key].Add(i);
            }
            else
            {
                counts[key] = new List<int> { i };
            }
        }

        // Find the minimum difference between two occurrences of the same card
        foreach (int key in counts.Keys)
        {
            if (counts[key].Count >= 2)
            {
                List<int> nums = counts[key];

                // Compare all consecutive pairs
                for (int i = 1; i < nums.Count; i++)
                {
                    int temp = nums[i] - nums[i - 1] + 1;
                    if (ans == -1 || temp < ans)
                    {
                        ans = temp;
                    }
                }
            }
        }

        return ans;
    }
    public int MinimumCardPickup2(int[] cards)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int ans = int.MaxValue;

        for (int i = 0; i < cards.Length; i++)
        {
            int num = cards[i];

            if (dic.ContainsKey(num))
            {
                ans = Math.Min(ans, i - dic[num] + 1);
            }

            dic[num] = i;
        }

        return ans == int.MaxValue ? -1 : ans;
    }
    public int MaximumSum(int[] nums)
    {
        Dictionary<int, int> counts = new();
        int ans = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];
            int num = n;
            int key = 0;
            while (n > 0)
            {
                key = key + n % 10;
                n = n / 10;
            }
            if (counts.ContainsKey(key))
            {
                int j = counts[key];
                int temp = num + nums[j];
                if (ans < temp)
                {
                    ans = temp;
                }
                if (num > nums[j])
                {
                    counts[key] = i;
                }
            }
            else
            {
                counts[key] = i;

            }

        }
        return ans;
    }
    public int EqualPairs(int[][] grid)
    {
        Dictionary<string, int> counts = new();
        int n = grid.Length;
        for (int r = 0; r < n; r++)
        {
            var row = string.Join(",", grid[r]);
            if (counts.ContainsKey(row))
            {
                counts[row]++;
            }
            else
            {
                counts[row] = 1;
            }
        }
        int equals = 0;
        for (int c = 0; c < n; c++)
        {
            var column = new List<int>();
            for (int r = 0; r < n; r++)
            {
                column.Add(grid[r][c]);
            }
            var colKey = string.Join(",", column);
            if (counts.ContainsKey(colKey))
            {
                equals += counts[colKey];
            }
        }
        return equals;
    }
    public bool CanConstruct(string ransomNote, string magazine)
    {
        Dictionary<char, int> counts = new();
        Dictionary<char, int> notes = new();
        for (int i = 0; i < magazine.Length; i++)
        {
            char key = magazine[i];
            if (counts.ContainsKey(key))
            {
                counts[key]++;
            }
            else
            {
                counts[key] = 1;
            }
        }
        for (int i = 0; i < ransomNote.Length; i++)
        {
            char key = ransomNote[i];
            if (notes.ContainsKey(key))
            {
                notes[key]++;
            }
            else
            {
                notes[key] = 1;
            }
        }
        foreach (char key in notes.Keys)
        {
            if (counts.ContainsKey(key))
            {
                if (notes[key] > counts[key])
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    public bool CanConstruct2(string ransomNote, string magazine)
    {
        Dictionary<char, int> counts = new();
        for (int i = 0; i < magazine.Length; i++)
        {
            char key = magazine[i];
            if (counts.ContainsKey(key))
            {
                counts[key]++;
            }
            else
            {
                counts[key] = 1;
            }
        }
        for (int i = 0; i < ransomNote.Length; i++)
        {
            char key = ransomNote[i];
            if (counts.ContainsKey(key))
            {
                counts[key]--;
                if (counts[key] < 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }
    public int NumJewelsInStones(string jewels, string stones)
    {
        Dictionary<char, int> counts = new();
        int count = 0;
        for (int i = 0; i < stones.Length; i++)
        {
            char key = stones[i];
            if (counts.ContainsKey(key))
            {
                counts[key]++;
            }
            else
            {
                counts[key] = 1;
            }
        }
        for (int i = 0; i < jewels.Length; i++)
        {
            char key = jewels[i];
            if (counts.ContainsKey(key))
            {
                count += counts[key];
            }
        }
        return count;

    }
    
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<string, int> counts = new();
        string subs = "";
        int n = 0;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (subs.Contains(c))
            {
                counts[subs] = subs.Length;
                subs = subs.Substring(subs.IndexOf(c) + 1);
            }
            subs += c;

        }
        if (!string.IsNullOrEmpty(subs))
        {
            counts[subs] = subs.Length;
        }
        foreach (string key in counts.Keys)
        {
            if (counts[key] > n)
            {
                n = counts[key];
            }
        }
        return n;
    }
    public bool ContainsDuplicate(int[] nums)
    {
        Dictionary<int, int> counts = new();
        foreach (int key in nums)
        {
            if (counts.ContainsKey(key))
            {
                return true;
            }
            else
            {
                counts[key] = 1;
            }

        }
        return false;
    }
    public string DestCity(IList<IList<string>> paths)
    {
        Dictionary<string, string> counts = new();
        HashSet<string> cities = new();
        string ans = "";
        foreach (IList<string> dest in paths)
        {
            string fromCity = dest[0];
            string toCity = dest[1];
            cities.Add(fromCity);
            cities.Add(toCity);
            counts[fromCity] = toCity;
        }
        foreach (string key in cities)
        {
            if (!counts.ContainsKey(key))
            {
                ans = key;
            }
        }
        return ans;

    }
}
