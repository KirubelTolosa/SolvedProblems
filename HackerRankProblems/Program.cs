using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing solution for Merging 2 Packages.
            int [] arr = {2,7,12,4,1};
            int limit = 6;			
            Console.WriteLine("[" +  GetIndices(arr, limit)[0] + "," +  GetIndices(arr, limit)[1] + "]");

            // Testing solution for Check valid IP
            string myStr = "12.34.5.123";
            Console.WriteLine(CheckIp(myStr).ToString());	

            //Testing solution for Busiest Hour at the Mall
            int [][] data = new int[][]{
                new int [] {1487799425, 14, 1},
                new int [] {1487799425, 4,  0},
                new int [] {1487799425, 2,  0},
                new int [] {1487800378, 10, 1},
                new int [] {1487801478, 18, 0},
                new int [] {1487801478, 18, 1},
                new int [] {1487901013, 1,  0},
                new int [] {1487901211, 7,  1},
                new int [] {1487901211, 7,  0}			
            };		
            Console.WriteLine(GetBusiestHour(data).ToString());
            
            // Testing Sorting
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
        /*
Validate IP Address
Validate an IP address (IPv4). An address is valid if and only if it is in the form "X.X.X.X", 
where each X is a number from 0 to 255. For example, "12.34.5.6", "0.23.25.0", and 
"255.255.255.255" are valid IP addresses, while "12.34.56.oops", "1.2.3.4.5", and
"123.235.153.425" are invalid IP addresses.

Examples:
ip = '192.168.0.1'
output: true

ip = '0.0.0.0'
output: true

ip = '123.24.59.99'
output: true

ip = '192.168.123.456'
output: false

Constraints:
[time limit] 5000ms
[input] string ip
[output] boolean
*/
	public static bool CheckIp(string str)
    {
      bool ipPass = false;
      if(str.Split('.').Length == 4)
      {
        foreach(var x in str.Split('.'))
        {
			ipPass = System.Convert.ToInt32(x) >= 0 && System.Convert.ToInt32(x) <= 255 ? true : false;          
        }
      }
      return ipPass;
    }
    /*
    Busiest Time in The Mall
    The Westfield Mall management is trying to figure out what the busiest moment at the mall was last year.
    You’re given data extracted from the mall’s door detectors. Each data point is represented as an integer
    array whose size is 3. The values at indices 0, 1 and 2 are the timestamp, the count of visitors, and 
    whether the visitors entered or exited the mall (0 for exit and 1 for entrance), respectively. 
    Here’s an example of a data point: [ 1440084737, 4, 0 ].

    Note that time is given in a Unix format called Epoch, which is a nonnegative integer holding the number
    of seconds that have elapsed since 00:00:00 UTC, Thursday, 1 January 1970.

    Given an array, data, of data points, write a function findBusiestPeriod that returns the time at which
    the mall reached its busiest moment last year. The return value is the timestamp, e.g. 1480640292. 
    Note that if there is more than one period with the same visitor peak, return the earliest one.

    Assume that the array data is sorted in an ascending order by the timestamp. Explain your solution and 
    analyze its time and space complexities.

    Example:
    input:  data = [ [1487799425, 14, 1], 
                     [1487799425, 4,  0],
                     [1487799425, 2,  0],
                     [1487800378, 10, 1],
                     [1487801478, 18, 0],
                     [1487801478, 18, 1],
                     [1487901013, 1,  0],
                     [1487901211, 7,  1],
                     [1487901211, 7,  0] ]

    output: 1487800378 # since the increase in the number of people
                       # in the mall is the highest at that point
    Constraints:
    [time limit] 5000ms
    [input] array.array.integer data
    1 ≤ data.length ≤ 100
    [output] integer
    */
        public static int GetBusiestHour(int[][] data){
            int timeStamp = 0;
            int cstInMall = 0;
            int currentCst = 0;
            int tempMax = 0;
            foreach(var rec in data)
            {
                currentCst = rec[1];
                cstInMall = rec[2] == 1 ? + currentCst : - currentCst;
                if(cstInMall > tempMax)
                {
                    timeStamp = rec[0];
                    tempMax = cstInMall;
                }			
            }
            return timeStamp;
        }
    /*
    Merging 2 Packages
    Given a package with a weight limit limit and an array arr of item weights, implement a function
    getIndicesOfItemWeights that finds two items whose sum of weights equals the weight limit limit. 
    Your function should return a pair [i, j] of the indices of the item weights, ordered such 
    that i > j. If such a pair doesn’t exist, return an empty array.

    Analyze the time and space complexities of your solution.

    Example:
    input:  arr = [4, 6, 10, 15, 16],  lim = 21
    output: [3, 1] # since these are the indices of the
                   # weights 6 and 15 whose sum equals to 21
    Constraints:
    [time limit] 5000ms
    [input] array.integer arr
    0 ≤ arr.length ≤ 100
    [input] integer limit
    [output] array.integer
    */
        public static int[] GetIndices(int[] arr, int limit)
        {
		Dictionary <int, int> myDict = new Dictionary<int, int>();
		for(int i = 0; i < arr.Length; i++)
		{
		  if(!myDict.ContainsKey(arr[i]))
					  myDict.Add(arr[i], i);	
		}		
		for(int i = 0; i < arr.Length; i++)
		{			
		if(myDict.ContainsKey(limit-arr[i]))
		{				
		  if(i > myDict[limit - arr[i]]){
		    return new int []{ i, myDict[limit - arr[i]]};
		  }
		  else{
		    return new int []{myDict[limit - arr[i]], i};
		  }          
		}
		}
		return new int[]{};
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

