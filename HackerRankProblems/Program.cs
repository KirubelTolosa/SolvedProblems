using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] myArray = { 1, 2, 4, 5, 3};
            int[] myArray = { 2, 4, 6, 8, 3 };
            int[] clouds = { 0, 0, 0, 1, 0, 0 };
            string str = "a";
            //Console.WriteLine(CountPairs(myArray).ToString());
            //Console.WriteLine(CountValleys(5, "UDDUUUDD").ToString());
            //Console.WriteLine(JumpCounter(clouds).ToString());
            //Console.WriteLine(CountOccurences(str, 1000000000000).ToString());
            InsertionSort2(myArray);
        }
        public static int CountPairs(int[] input)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int totalPairCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int pairCount = 0;
                int element = input[i];
                if (!dict.ContainsKey(element))
                {
                    dict.Add(element, 1);
                }
                else
                {
                    dict[element]++;
                    if (dict[element] % 2 == 0)
                    {
                        pairCount++;
                    }
                }
                totalPairCount += pairCount;
            }

            return totalPairCount;
        }
        public static int CountValleys(string path)
        {
            int valleyCount = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int counter = 0;
            bool hikeUP = true;
            foreach (char x in path)
            {
                if (x == 'D')
                {
                    counter--;
                    hikeUP = false;
                }
                else if (x == 'U')
                {
                    counter++;
                    hikeUP = true;
                }
                if (counter == 0 && hikeUP == true)
                {
                    valleyCount++;
                }
            }
            return valleyCount;
        }
        public static int JumpCounter(int[] c)
        {
            int jumpCount = 0;
            int i = 0;
            while (i + 1 < c.Length)
            {
                if (i + 2 < c.Length)
                {
                    if (c[i + 2] == 0)
                    {
                        jumpCount++;
                        i += 2;
                    }
                    else
                    {
                        jumpCount++;
                        i += 1;
                    }
                }
                else
                {
                    jumpCount++;
                    i += 1;
                }
            }

            return jumpCount;
        }
        public static long CountOccurences(string str, long n)
        {

            int repCounter = 0;
            string strTemp = "";
            while (strTemp.Length <= n)
            {
                if (str == "a")
                {
                    return n;
                }
                else
                {
                    foreach (char x in str)
                    {

                        if (strTemp.Length == n)
                        {
                            return repCounter;
                        }
                        else
                        {
                            strTemp += x;
                        }
                        if (x == 'a')
                        {
                            repCounter++;
                        }
                    }

                }
            }
            return repCounter;
        }
        public static int[] InsertionSort1(int[] arr)
        {
            int i = 1;
            int j = 0;
            int temp = 0;
            while (i < arr.Length)
            {
                j = i;
                while (j > 0 && arr[j] < arr[j - 1])
                {
                    temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                    j--;
                }
                i++;
            }
            return arr;
        }
        public static void InsertionSort2(int[] arr)
        {
            int i = arr.Length - 1;
            int j = 0;
            var temp = arr[i];
            while (i > 0)
            {
                string temporary = "";
                if (temp < arr[i - 1])
                {
                    arr[i] = arr[i - 1];
                    foreach (int x in arr)
                    {
                        temporary += " " + x;
                    }
                    Console.WriteLine(temporary);
                }
                else
                {
                    arr[i] = temp;
                    foreach (int x in arr)
                    {
                        temporary += " " + x;
                    }
                    Console.WriteLine(temporary);
                    break;
                }
                i--;
            }
        }
    }
}

