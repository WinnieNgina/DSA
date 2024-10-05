namespace DSA;

public class PrefixSum
{
    public bool[] AnswerQueries(int[] nums, int[,] queries, int limit)
    {

        int n = queries.GetLength(0);
        bool[] results = new bool[n];
        for (int i = 0; i < n; i++)
        {
            int x = queries[i, 0];
            int y = queries[i, 1];
            int sum = 0;
            for (int j = x; j <= y; j++)
            {
                sum += nums[j];
            }
            if (sum < limit)
            {
                results[i] = true;
            }
            else
            {
                results[i] = false;
            }
        }
        return results;
    }
    public int ArraySections(int[] nums)
    {
        int n = nums.Length;
        if (n <= 1)
        {
            return 0;
        }
        int j = 0;
        int i = 0;
        int totalSum = 0;
        int prefixSum = 0;
        while (i < n)
        {
            totalSum += nums[i];
            i++;
        }
        for (int k = 0; k < (n - 1); k++)
        {
            prefixSum += nums[k];
            totalSum -= nums[k];
            if (prefixSum >= totalSum)
            {
                j++;
            }
        }
        return j;
    }
    public int[] RunningSum(int[] nums)
    {
        int temp = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            temp += nums[i];
            nums[i] = temp;
        }
        return nums;
    }
    public int MinStartValue(int[] nums)
    {
        int temp = 0;
        int startValue = 0;
        for (int i = 0; i < nums.Length;)
        {
            temp += nums[i];
            if (temp >= 1)
            {
                i++;
            }
            else
            {
                int tar = 1 - temp;
                startValue += tar;
                temp += tar;
                temp -= nums[i];
            }
        }
        if (startValue == 0)
        {
            return 1;
        }
        return startValue;

    }
    public int PivotIndex(int[] nums)
    {
        if (nums.Length == 0)
        {
            return -1;
        }
        int rsum = 0;
        int lsum = 0;
        foreach (int num in nums)
        {
            rsum += num;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            rsum -= nums[i];
            if (rsum == lsum)
            {
                return i;
            }
            lsum += nums[i];
        }
        return -1;
    }
    public int LargestAltitude(int[] gain)
    {
        int sum = 0;
        int temp = 0;
        for (int i = 0; i < gain.Length; i++)
        {
            temp += gain[i];
            if (temp > sum)
            {
                sum = temp;
            }
        }
        return sum;

    }
}
