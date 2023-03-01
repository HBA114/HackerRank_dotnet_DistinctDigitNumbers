class Program
{
    // Complete the countNumbers function below.
    static void countNumbers(List<List<int>> arr)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            int n = arr[i][0];
            int m = arr[i][1];
            int[] generatedArray = Enumerable.Range(n, m - (n - 1)).ToArray();  //! Mistake 1: count was (m - n)

            List<int> validArr = new List<int>();
            for (int j = 0; j < generatedArray.Count(); j++)
            {
                if (isValid(generatedArray[j])) validArr.Add(generatedArray[j]);
            }
            Console.WriteLine(validArr.Count());
        }
    }

    static bool isValid(int number)
    {
        char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }; //! Mistake 2: array type and elements was string
        string strNumber = number.ToString();

        for (int i = 0; i < numbers.Count(); i++)
        {
            int count = 0;
            for (int j = 0; j < strNumber.Count(); j++)
            {
                if (strNumber[j] == numbers[i])     //! Mistake 3: control logic was strNumber[j].Equals(numbers[i]) with string(numbers[i]) and char(strNumber[j]) type
                {                                   //! so i failed test because of this simple mistakes
                    count++;
                }
            }
            if (count > 1) return false;
        }
        return true;
    }

    static void Main(string[] args)
    {
        int arrRows = Convert.ToInt32(Console.ReadLine()!.Trim());
        int arrColumns = Convert.ToInt32(Console.ReadLine()!.Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < arrRows; i++)
        {
            arr.Add(Console.ReadLine()!.TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        countNumbers(arr);
    }
}
