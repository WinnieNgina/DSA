using DSA;
HashMap hashMap = new HashMap();
int[][] nums = new int[][]
{
    new int[] { 3, 1, 2, 4, 5 },
    new int[] { 1, 2, 3, 4 },
    new int[] { 3, 4, 5, 6 }
};
var ans = hashMap.Intersection(nums);
foreach(int n in ans)
{
    Console.WriteLine(n);
}    