using DSA;
HashMap hashMap = new HashMap();
int[][] grid = new int[][]
{
    new int[] { 3, 2, 1},
    new int[] {1, 7, 6},
    new int[] {2, 7, 7}
};
Console.WriteLine(hashMap.EqualPairs(grid));