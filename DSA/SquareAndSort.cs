namespace DSA;

public class SquareAndSort
{
    public int[] SortedSquares(int[] nums)
    {
        int n = nums.Length;
        int i = 0;
        int j = n - 1;
        int pos = n - 1;
        int[] result = new int[n];
        while (pos > -1)
        {
            if (Math.Abs(nums[i]) > Math.Abs(nums[j]))
            {
                result[pos] = nums[i] * nums[i];
                pos--;
                i++;
            }
            else
            {
                result[pos] = nums[j] * nums[j];
                pos--;
                j--;
            }
        }
        return result;
    }
}
