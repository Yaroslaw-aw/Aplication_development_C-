namespace HomeTask
{
    internal class Program
    {
        static bool FindTripletsWithSum(int[] arr, int targetSum)
        {
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < arr.Length - 2; i++)
            {
                int currentSum = targetSum - arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    int remainingSum = currentSum - arr[j];

                    if (set.Contains(remainingSum))
                    {
                        Console.WriteLine($"Тройка чисел: {arr[i]}, {arr[j]}, {remainingSum}");
                        return true;
                    }

                    set.Add(arr[j]);
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 2, 8, 3, 5, 6 };
            int targetSum = 10;

            if (!FindTripletsWithSum(arr, targetSum))
            {
                Console.WriteLine("Тройка чисел не найдена.");
            }
        }
    }
}
