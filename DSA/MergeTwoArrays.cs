namespace DSA;

public class MergeTwoArrays
{
    public int[] MergeArrays(int[] array1, int[] array2)
    {
        int i = 0;
        int j = 0;
        int k = 0;
        int len = array1.Length + array2.Length;
        var newArray = new int[len];
        while (i < array1.Length && j < array2.Length)
        {
            if (array1[i] < array2[j])
            {
                newArray[k] = array1[i];
                i++;
                k++;
            }
            else
            {
                newArray[k] = array2[j];
                j++;
                k++;
            }
        }
        while (i < array1.Length)
        {
            newArray[k++] = array1[i++];
        }
        while (j < array2.Length)
        {
            newArray[k++] = array2[j++];

        }
        return newArray;
    }
}
