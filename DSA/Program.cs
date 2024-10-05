using DSA;
HashMap hashMap = new HashMap();
int[] nums = [1, 2, 3, 5, 6, 8, 10];
var num = hashMap.FindNumbers(nums);
foreach (int i in num)
{
    Console.WriteLine(i);
}
