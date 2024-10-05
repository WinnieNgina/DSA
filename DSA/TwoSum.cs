namespace DSA;

public class TwoSum
{
    public bool FindTwoSum(int[] nums, int target)
    {
        if (nums == null) return false;
        int i = 0;
        int j = nums.Length - 1;
        while (i < j)
        {
            int c = nums[i] + nums[j];
            if (target == c) return true;
            if (c > target)
            {
                j--;
            }
            else
            {
                i++;
            }

        }
        return false;
    }
}
