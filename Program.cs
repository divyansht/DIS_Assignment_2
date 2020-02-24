using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Assignment2_CT_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);
            for (int i = 0; i < r.Length; i++)
            {
                Console.Write(r[i] + " ");
            }
            Console.WriteLine();
            // Write your code to print range r here
            Console.WriteLine("Question 2");
            string s = "University of South Florida";
            string rs = StringReverse(s);
            Console.WriteLine(rs);
            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 2, 2, 3, 5, 6 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);
            Console.WriteLine("Question 4");
            string s2 = "Dell";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString);
            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");
            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            Console.WriteLine("\n");
            Console.WriteLine("Question 6");
            char[] arr = new char[] { 'a', 'g', 'h', 'a' };
            int k = 3;
            Console.WriteLine(ContainsDuplicate(arr, k));
            Console.WriteLine("Question 7");
            int rodLength = 4;
            int priceProduct = RodBreak(rodLength);
            Console.WriteLine(priceProduct);
            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            string keyword = "hhllo";

            Console.WriteLine(DictSearch(userDict, keyword));
            Console.WriteLine("Question 9");
            SolvePuzzle();
        }
        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }
        public static int[] TargetRange(int[] nums, int target)
        {
            try
            {
                //Write your code here;
                return new int[] { Find(nums, true, 0, nums.Length - 1, target), Find(nums, false, 0, nums.Length - 1, target) };
            }
            catch (Exception)
            {
                throw;
            }
        }
        static int Find(int[] nums, bool leftmost, int left, int right, int target)
        {
            if (right < left) return -1;

            int mid = (left + right) / 2;
            if (nums[mid] < target)
            {
                return Find(nums, leftmost, mid + 1, right, target);
            }
            else if (nums[mid] > target)
            {
                return Find(nums, leftmost, left, mid - 1, target);
            }
            else // equals
            {
                if (leftmost && mid > 0 && nums[mid - 1] == target)
                {
                    return Find(nums, leftmost, left, mid - 1, target);
                }
                else if (!leftmost && mid < nums.Length - 1 && nums[mid + 1] == target)
                {
                    return Find(nums, leftmost, mid + 1, right, target);
                }
                else
                {
                    return mid;
                }
            }
        }




        public static string StringReverse(string s)
        {
            try
            {
                char spliter = ' ';
                char[] array = s.ToCharArray();
                int index = 0,
                    startIndex = 0,
                    endIndex = 0;

                while (index <= array.Length - 1)
                {
                    if (array[index] == spliter || index == array.Length - 1)
                    {
                        if (array[index] == spliter)
                            endIndex = index - 1;
                        else
                            endIndex = index;

                        while (startIndex < endIndex)
                        {
                            array[startIndex] = (char)((int)array[startIndex] + (int)array[endIndex]);
                            array[endIndex] = (char)((int)array[startIndex] - (int)array[endIndex]);
                            array[startIndex] = (char)((int)array[startIndex] - (int)array[endIndex]);

                            startIndex++;
                            endIndex--;
                        }

                        startIndex = index + 1;
                    }

                    index++;
                }

                return new string(array);




            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
        public static int MinimumSum(int[] l2)
        {
            int n = l2.Length;
            try
            {
                int sum = l2[0];

                for (int i = 1; i < n; i++)
                {
                    if (l2[i] == l2[i - 1])
                    {

                        // While current element is same as  
                        // previous or has become smaller 
                        // than previous. 
                        int j = i;
                        while (j < n && l2[j] <= l2[j - 1])
                        {
                            l2[j] = l2[j] + 1;
                            j++;
                        }
                    }
                    sum = sum + l2[i];
                }

                return sum;
                //Write your code here;
            }
            catch (Exception)
            {
                throw;
            }
            return 0;
        }
        public static string FreqSort(string s2)
        {


            try
            {

                var dict = new Dictionary<char, int>();
                for (int i = 0; i < s2.Length; i++)
                {
                    if (dict.ContainsKey(s2[i]))
                        dict[s2[i]]++;
                    else
                        dict.Add(s2[i], 1);
                }

                var ordered = from row in dict orderby row.Value descending select row.Key;

                var res = "";
                foreach (char c in ordered)
                    res += new String(c, dict[c]);

                return res;
            }







            catch (Exception)
            {

                throw;
            }
            return null;
        }
        public static int[] Intersect1(int[] nums1, int[] nums2)
        {
            try
            {
                if (nums1 == null || nums2 == null)
                    return new int[0];

                Array.Sort(nums1);
                Array.Sort(nums2);

                var duplicate = new List<int>();
                int index1 = 0;
                int index2 = 0;

                int length1 = nums1.Length;
                int length2 = nums2.Length;

                while (index1 < length1 && index2 < length2)
                {
                    var current1 = nums1[index1];
                    var current2 = nums2[index2];
                    if (current1 == current2)
                    {
                        duplicate.Add(current1);
                        index1++;
                        index2++;
                    }
                    else if (current1 < current2)
                    {
                        index1++;
                    }
                    else
                    {
                        index2++;
                    }
                }

                return duplicate.ToArray();
            }
            catch
            {
                throw;
            }





            return new int[] { };
        }
        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            try
            {

                {


                    {
                        var numAndCount1 = new Dictionary<int, int>();

                        foreach (var num in nums1)
                        {
                            if (!numAndCount1.ContainsKey(num)) numAndCount1[num] = 0;

                            numAndCount1[num]++;
                        }

                        var result = new List<int>();

                        foreach (var num in nums2)
                        {
                            if (numAndCount1.ContainsKey(num) && numAndCount1[num] > 0)
                            {
                                result.Add(num);

                                numAndCount1[num]--;
                            }
                        }

                        return result.ToArray();

                    }
                }
            }
            catch
            {
                throw;
            }
            return new int[] { };
        }
        public static bool ContainsDuplicate(char[] arr, int k)
        {
            try
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (dict.ContainsKey(arr[i]))
                    {
                        if (i - dict[arr[i]] <= k)
                        {
                            return true;
                        }
                    }
                    else
                        dict[arr[i]] = i;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            return default;
        }


        public static int RodBreak(int n)
        {
            try
            {

                {

                    if (n == 2)
                        return 1;
                    else if (n == 3)
                        return 2;
                    else if (n == 4)
                        return 4;
                    else if (n == 5)
                        return 6;
                    else if (n == 6)
                        return 9;
                    else
                        return 3 * RodBreak(n - 3);
                }


            }






            //Write Your Code Here


            catch (Exception)
            {
                throw;
            }
            return 0;
        }
        public static bool DictSearch(string[] userDict, string keyword)
        {
            try
            {
                
                int same = 0;
                
                for (int i = 0; i < userDict.Length; i++)
                {
                    same = 0;
                    for (int j = 0; j < userDict[i].Length; j++)
                    {
                        
                        if (userDict[i][j] == keyword[j])
                        {
                            same = same + 1;
                            
                        }

                    }
                    if (same == keyword.Length - 1)
                        return true;

                }

                return false;

            
            
    




    
    }
            catch (Exception)
            {
                throw;
            }
            return default;
        }
        public static void SolvePuzzle()
        {
            try
            {
                //Write Your Code Here
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
