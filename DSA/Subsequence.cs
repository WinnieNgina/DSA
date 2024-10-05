namespace DSA;

public class Subsequence
{
    public bool IsSubsequence(string s, string t)
    {
        int i = 0;
        int j = 0;
        while (i < s.Length && j < t.Length)
        {
            if (s[i] == t[j])
            {
                if (i == (s.Length - 1))
                {
                    return true;
                }
                i++;
                j++;
            }
            else
            {
                j++;
            }
        }
        return false;

    }
}
