namespace DSA;

public class Palindrome
{
    public bool CheckPalindrome(string s)
    {
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            if (s[i] == s[j])
            {
                i++;
                j--;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}
