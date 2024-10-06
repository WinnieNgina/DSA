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
}
