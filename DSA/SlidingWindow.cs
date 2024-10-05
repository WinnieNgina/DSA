using System.Text;

namespace DSA;

public class SlidingWindow
{
    public int FindLongestArray(int[] nums, int target)
    {
        int j = 0;
        int sum = 0;
        int n = 0;
        int len = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            while (sum > target)
            {
                sum -= nums[j];
                j++;
            }
            len = i - j + 1;
            if (n < len)
            {
                n = len;
            }
        }
        return n;
    }
    public int FindLength(string s)
    {
        int len = 0; // length of the substring
        int j = 0; // Track the number of zeros
        int ans = 0; // 

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
            {
                j++;
            }
            while (j > 1)
            {
                if (s[len] == '0')
                {
                    j--;
                }
                len++;
            }
            int temp = i - len + 1;
            if (temp > ans)
            {
                ans = temp;
            }

        }
        return ans;
    }
    public int FindProduct(int[] nums, int k)
    {
        int left = 0;
        int prod = 1;
        int len = 0;
        if (k <= 1)
        {
            return 0;
        }
        for (int right = 0; right < nums.Length; right++)
        {
            prod *= nums[right];
            while (prod >= k)
            {
                prod /= nums[left];
                left++;
            }
            int temp = right - left + 1;
            len += temp;
        }
        return len;
    }
    public int FindBestSubarray(int[] nums, int k)
    {
        int curr = 0;
        for (int i = 0; i < k; i++)
        {
            curr += nums[i];
        }
        int ans = curr;
        for (int i = k; i < nums.Length; i++)
        {
            curr += nums[i];
            curr -= nums[i - k];
            if (curr > ans)
            {
                ans = curr;
            }
        }
        return ans;
    }
    public double FindMaxAverage(int[] nums, int k)
    {
        int curr = 0;
        for (int i = 0; i < k; i++)
        {
            curr += nums[i];
        }
        int ans = curr;
        for (int i = k; i < nums.Length; i++)
        {
            curr += nums[i];
            curr -= nums[i - k];
            if (curr > ans)
            {
                ans = curr;
            }
        }
        double result = (double)ans / k;
        return Math.Round(result, 5);
    }
    public int LongestOnes(int[] nums, int k)
    {
        int left = 0; // Track the window
        int zeroCount = 0; // Track number of zeros
        int ans = 0; // Stores the longest

        for (int right = 0; right < nums.Length; right++) // iterate over all the elements
        {
            if (nums[right] == 0) // increment zero count
            {
                zeroCount++;
                while (zeroCount > k)
                {
                    if (nums[left] == 0)
                    {
                        zeroCount--;
                    }
                    left++;
                }

            }
            if (right - left + 1 > ans)
            {
                ans = right - left + 1;
            }
        }
        return ans;
    }
    public string ReverseWords(string s)
    {
        string reverse = "";
        string answer = "";
        string[] subs = s.Split(' ');
        for (int i = 0; i < subs.Length; i++)
        {
            string result = subs[i];
            for (int j = (result.Length - 1); j > -1; j--)
            {
                reverse += result[j];
            }
            if (i < (subs.Length - 1))
            {
                answer += reverse + " ";
                reverse = "";
            }
            else
            {
                answer += reverse;
            }
        }
        return answer;
    }
    public string ReverseWordsSolu2(string s)
    {
        string[] words = s.Split(' ');  // Split the input sentence into words
        StringBuilder result = new StringBuilder();

        foreach (string word in words)
        {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);  // Reverse the characters in each word
            result.Append(new string(charArray)).Append(' ');  // Append the reversed word
        }

        return result.ToString().Trim();  // Trim the trailing space and return the result
    }
    public int GetCommon(int[] nums1, int[] nums2)
    {
        int j = 0;
        int len1 = nums1.Length;
        int len2 = nums2.Length;
        int i = 0;
        while (i < len1 && j < len2)
        {
            if (nums1[i] == nums2[j])
            {
                return nums1[i];
            }
            if (nums1[i] > nums2[j])
            {
                j++;
            }
            else
            {
                i++;
            }
        }
        return -1;
    }
    public void MoveZeroes(int[] nums)
    {
        int j = 0;
        if (nums.Length <= 1)
        {
            return;
        }
        for (int i = 0; i < nums.Length;)
        {
            if (nums[i] != 0)
            {
                nums[j] = nums[i];
                j++;
                i++;
            }
            else
            {
                i++;
            }
        }
        while (j < nums.Length)
        {
            nums[j] = 0;
            j++;
        }

    }
    public string ReversePrefix(string word, char ch)
    {
        char[] reversed = new char[word.Length];
        int i = 0;
        int j = 0;
        if (word.Length == 0)
        {
            return word;
        }
        while (i < word.Length && word[i] != ch)
        {
            i++;
        }
        if (i == word.Length)
        {
            return word;
        }
        j = 0;
        while (j <= i)
        {
            reversed[j] = word[i - j];
            j++;
        }
        while (i + 1 < word.Length)
        {
            reversed[i + 1] = word[i + 1];
            i++;
        }
        return new string(reversed);
    }
    public int MinSubArrayLen(int target, int[] nums)
    {
        int j = 0;
        int sum = 0;
        int len = int.MaxValue;
        int temp = 0;
        int k = 0;
        while (sum < target && k < nums.Length)
        {
            sum += nums[k];
            k++;
        }
        if (sum < target)
        {
            return 0;
        }
        len = k;
        for (int i = k; i < nums.Length; i++)
        {
            sum += nums[i];
            while (sum >= target)
            {
                temp = i - j + 1;
                if (temp < len)
                {
                    len = temp;
                }
                sum -= nums[j];
                j++;
            }
        }
        while (sum >= target && j < nums.Length)
        {
            temp = nums.Length - j;
            if (temp < len)
            {
                len = temp;
            }
            sum -= nums[j];
            j++;
        }

        return len;
    }
    public int MaxVowels(string s, int k)
    {

        int j = 0;
        int temp = 0;
        int len = 0;
        string st = "aeiou";
        for (int i = 0; i < s.Length; i++)
        {
            if (st.Contains(s[i]))
            {
                temp++;
            }
            if (k == (i - j + 1))
            {
                if (temp > len)
                {
                    len = temp;
                }
                if (st.Contains(s[j]))
                {
                    temp--;
                }
                j++;
            }

        }
        return len;
    }
    public int EqualSubstring(string s, string t, int maxCost)
    {
        int cost = 0;
        int j = 0;
        int len = 0;

        for (int i = 0; i < s.Length; i++)
        {
            cost += Math.Abs(s[i] - t[i]);
            while (cost > maxCost)
            {
                cost -= Math.Abs(s[j] - t[j]);
                j++;
            }

            int temp = i - j + 1;
            if (temp > len)
            {
                len = temp;
            }
        }

        return len;
    }
}