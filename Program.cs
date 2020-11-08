using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace test_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, C# World!");

            // int largest = findLargestInArray(new[] { 4, 5, 6, 7, 2, 20, 11, 9, 8 });
            // Console.WriteLine("Largest: {0}", largest);

            // int sum = findSumDigitNumber(2467);
            // Console.WriteLine("Sum: {0}", sum);

            // int min = Int32.MinValue;
            // int max = Int32.MaxValue;
            // Console.WriteLine("Min: {0}, Max: {1}", min, max);

            // int x = subArrayWithMax(new[] { -1, 3, -4, 5, 7, -6, 8 });
            // Console.WriteLine("Max in array: {0}", x);

            // Console.WriteLine("Max in array: " + x);

            // TestB obj = new TestB();
            // obj.a = 10;
            // obj.b = 20;
            // obj.Display();

            // int[] pairs = { 9, 3, 9, 3, 6, 7, 6, 8, 2, 7, 8 };
            // int[] TestMe = ShiftRight(array, 3);
            // for (int i = 0; i < TestMe.Length; i++)
            // {
            //     Console.Write("{0}, ", TestMe[i]);
            // }
            // Console.Write("\n");

            // int count = FrogJump(10, 85, 30);
            // Console.WriteLine("Frog jumped {0}x.", count);

            // int odd = OddOccurenceInArray(pairs);
            // Console.WriteLine("Odd in Array: {0}", odd);

            // int[] number = PermMissingElement(new[] {2,3,6,7,5,8,9});
            // for (int x = 0; x < number.Length; x++) {
            //     Console.Write("Missing: {0}, ", number[x]);
            // }
            // for (int i = 1; i < 10; i++)
            // {
            //     int test = i * (i + 1) / 2; // total of 1-5 numbers
            //     Console.WriteLine("Test {0}: {1}", i, test);
            // }
            // int[] array = { 99998, 100000 };

            // int ans = PermMissingElementInt(array);
            // Console.WriteLine("Missing: {0}", ans);

            PrefixSum(6, 15, 2);
        }

        public static void PrefixSum(int a, int b, int k)
        {
            int[] array = new int[b - a];
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if ((a + i) % k == 0)
                {
                    array[i] = a + i;
                }
            }
            for (int x = 0; x < array.Length; x++)
            {
                if (array[x] > 0)
                {
                    count++;
                    Console.Write("{0}, ", array[x]);
                }
            }
            Console.WriteLine("Count: {0}, ", count);
        }

        // public static string PermMissingElementString(string items)
        // {
        //     IEnumerable<string> uniqueItems = items.Select(x => x.ToLower()).Distinct<string>();
        //     TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        //     uniqueItems = uniqueItems.Select(x => textInfo.ToTitleCase(x));
        //     Console.WriteLine("Unique array elements using LINQ without case sensitive: " + string.Join(",", uniqueItems));

        //     Console.ReadLine();

        //     return "ans";
        // }

        public static int PermMissingElementInt(int[] array)
        { // distinct, regular array - okay
            Array.Sort(array);
            int sum = 0, tail = 0, arrCount = 0, uniCount = 0;
            int first = 0, total = 0;
            bool okToGo = false;
            IEnumerable<int> uniqueItems = array.Distinct<int>();
            uniCount = uniqueItems.Count<int>();
            arrCount = array.Length;
            if (arrCount == 0)
            {
                return 0;
            }
            for (int x = 0; x < array.Length; x++)
            {
                if (array[x] >= 0 && array[x] <= 100001)
                {
                    okToGo = true;
                }
                else
                {
                    return 0;
                }
            }
            if (okToGo)
            {
                first = array[0];
                if (uniCount != arrCount)
                { // make sure NO Distinct elements
                    array = uniqueItems.ToArray<int>();
                }
                if (array[0] > 1)
                {
                    tail = ((first - 1) * (first)) / 2;
                }
                int last = array[array.Length - 1];
                total = last * (last + 1) / 2;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
            }
            return total - sum - tail;
        }
        static int subArrayWithMax(int[] array)
        { // something is wrong here...
            int max = Int32.MinValue;
            int min = 0;
            for (int i = 0; i < array.Length; i++)
            {
                min += array[i];
                if (max < min)
                    max = min;
                else
                    min = 0;
            }
            return max;
        }

        static int findSumDigitNumber(int num)
        {
            int temp = 0, digit = 0, sum = 0;
            temp = num;
            while (num > 0)
            {
                digit = num % 10;
                sum += digit;
                num /= 10;
            }
            return sum;
        }

        static int findSmallestInArray(int[] array)
        {
            int smallest = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < smallest)
                    smallest = array[i];
            }
            return smallest;
        }

        static int findLargestInArray(int[] array)
        {
            int largest = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > largest)
                    largest = array[i];
            }
            return largest;
        }

        public int BinaryGap(int N)
        {
            int gap = 0, max_gap = 0;
            if (N > 0 && N < 2147483647)
            {

                string binary = Convert.ToString(N, 2);

                // Console.WriteLine(binary);
                for (int i = 0; i < binary.Length; i++)
                {
                    if (binary[i] == '1')
                    {
                        if (gap > max_gap)
                        {
                            max_gap = gap;
                        }
                        gap = 0;
                    }
                    else
                    {
                        gap++;
                    }
                }
            }
            return max_gap;
        }

        static int[] ShiftRight(int[] array, int K)
        {
            int first = array[0], next = 0;
            for (int x = 0; x < K; x++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    next = array[i + 1];
                    array[i + 1] = first;
                    first = next;
                }
            }
            array[0] = first;
            return array;
        }
        static int[] ShiftLeft(int[] array, int K)
        {
            int first = 0, next = 0, last = 0;
            for (int x = 0; x < K; x++)
            {
                last = array[0];
                for (int i = 0; i < array.Length - 1; i++)
                {
                    first = array[i];
                    next = array[i + 1];
                    array[i] = next;
                }
                array[array.Length - 1] = last;
            }
            return array;
        }

        static int FrogJump(int start, int end, int distance)
        {
            int count = 0, jump = start;
            while (jump < end)
            {
                jump += distance;
                count++;
            };
            return count;
        }

        static int OddOccurenceInArray(int[] array)
        {
            int odd = 0;
            foreach (int x in array)
                odd ^= x;
            return odd;
        }
    }
}
