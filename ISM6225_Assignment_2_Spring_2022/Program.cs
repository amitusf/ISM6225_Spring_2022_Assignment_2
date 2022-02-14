/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is: {0}", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is: {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.

                //declaring variable for storing index location
                int index_loc;

                //declaring variable to length of the array
                int high = nums.Length-1;
                 
                //declaring variable to store lowest value of the array
                int low = 0;

                //finding the middle index using highest index and lowest index of the array
                int mid = (high + low) / 2;

                //case 1 - when the array contains target variable
                if (nums.Contains(target))
                {
                    return index_loc = nums.ToList().IndexOf(target);
                }

                //case 2 - when the target variable is higher than max value in the array
                else if (target > nums.Max()) { return nums.Length; }

                //case 3 - when the target variable is lower than the lowest value in the array
                else if (target < nums.Min()) { return 0; }

                //case 4 - finding index of the target variable using binary seacrh algorithm
                else if (target > nums[mid])
                {
                    while (target > nums[mid])
                    {
                        low = mid+1;
                        mid = (high + low) / 2;
                        if (nums[mid] < target) { mid++; break; }
                    }

                }
                else if (target < nums[mid])
                {
                    while (target < nums[mid])
                    {
                        high = mid-1;
                        mid = (high + low) / 2;
                        if (nums[mid] > target) { mid++; break; }
                    }
                }
                return mid;


            }
            catch (Exception)
            {
                throw;
            }
        }
        //reflection - while developing the solution I got to know more arrays and indexes, I became more familier with index and arrays

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                //write your code here.

                //Removing special characters and lowering every char
                paragraph = paragraph.ToLower().Replace("!", " ").Replace("?", " ").Replace("'", " ").Replace(",", " ").Replace(";", " ").Replace(".", " ").Trim();

                //storing paragraph in a list
                List<string> para_list = paragraph.Split(' ').ToList();

                //using loop to remove banned words from the list
                if (banned.Count() > 0)
                {
                    for (int i = 0; i < banned.Count(); i++)
                    {
                        para_list.RemoveAll(x => x == banned[i]);
                    }
                }

                //declaring empty string
                string word;

                //declaring empty integer
                int counter = 0;

                //declaring empty dictionary
                Dictionary<string, int> dict = new Dictionary<string, int>();

                //using loop to measure frequency of each word
                for (int i = 0; i < para_list.Count; i++)
                {
                    if (para_list[i].Length > 0)
                    {
                        word = para_list[i];

                        if (dict.Keys.Contains(word))
                        {
                            //increasing frequency of existing words
                            dict[word] = dict[word] + 1;
                        }
                        else
                        {
                            //adding words to dictionary
                            dict.Add(word, 1);
                        }
                    }
                }

                //finding word with max frequecny
                int index_max = dict.Values.ToList().FindIndex(x => x == dict.Values.ToList().Max());

                //returing word from dictionary
                return dict.Keys.ElementAt(index_max).ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }
        //reflection - the question involved lot of smaller steps, it gave good understanding of dictionary and lists, I felt its better to store strings in list and then work with them

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                //write your code here.

                //declaring empty dictionary
                Dictionary<int, int> dict = new Dictionary<int, int>();

                //storing length of array
                int len = arr.Length;

                //declaring empty variable
                int val = 0;

                //using loop to measure frequency of each element from array
                for (int i = 0; i < len; i++)
                {
                    //similar to above problem, adding new element to dict and incrementing freq if element already exists
                    val = arr[i];
                    if (dict.Keys.Contains(val))
                    {
                        dict[val] = dict[val] + 1;
                    }
                    else
                    {
                        dict.Add(val, 1);
                    }
                }

                //List to save lucky numbers
                List<int> list_lucky = new List<int>();

                //using loop to check if key and value are same for each pair from dictionary
                for (int i = 0; i < dict.Count; i++)
                {
                    if (dict.Keys.ToList()[i] == dict.Values.ToList()[i])
                        list_lucky.Add(dict.Keys.ToList()[i]);
                }

                //finding largest lucky number
                if (list_lucky.Count > 0)
                { return list_lucky.Max(); }

                else return -1;

            }
            catch (Exception)
            {
                throw;
            }
        }
        //reflection - Question was good for practising dictionary add methods

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "180 7"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                //write your code here.

                //storing length of secret string
                int len = secret.Length;

                //declaring empty variables
                int i = 0;
                int counter_a = 0;
                int counter_b = 0;

                //copying input strings into new strings
                string new_secret = secret;
                string new_guess = guess;

                //using loop to compare each char with same index between the two strings
                foreach (char c in guess)
                {
                    if (c == secret[i])
                    {
                        counter_a++;

                        //removing matched char and adding blank space to keep length consistent
                        new_secret = " " + new_secret.Remove(i, 1);
                        new_guess = " " + new_guess.Remove(i, 1);
                    }
                    i++;
                }

                //removing spaces from last step
                new_secret = new_secret.Replace(" ", "");
                new_guess = new_guess.Replace(" ", "");

                //using loop and checking if guess and secret have any common chars
                foreach (char d in new_guess)
                {
                    if (new_secret.Contains(d))
                    {
                        //if char if found then it is removed 
                        new_secret = new_secret.Remove(new_secret.IndexOf(d), 1);
                        counter_b++;
                    }

                };

                //returing results in requested format
                return counter_a + "A" + counter_b + "B";
            }
            catch (Exception)
            {

                throw;
            }
        }
        //reflection - question was very tricky, faced lot issue when guess string had duplicate values, tried Replace method but string lenght was decreasing finally tried Remove method to remove matched char and added empty space 

        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                //write your code here.

                //declaring empty variables
                int lastindex = 0;
                int new_last_index = 0;
                int firstindex = 0;
                int dist = 0;
                string word = "";
                char c;

                //declaring empty lists
                List<string> labels = new List<string>();
                List<string> words = new List<string>();

                //using while loop till string is not empty
                while (s.Length > 0)
                {
                    //storing 1st char from string
                    c = s[0];

                    //storing index of first occurance
                    firstindex = s.IndexOf(c);

                    //storing index of last occurance
                    lastindex = s.LastIndexOf(c);

                    //storing distance between 1st & last occurance of each char
                    dist = lastindex - firstindex;

                    //using substring to make 1st word from 1st & last occurance
                    word = s.Substring(firstindex, lastindex + 1 - firstindex);

                    //delacting empty char
                    char d;

                    //using for loop to on newly extracted word from inut string
                    for (int p = 0; p < word.Length; p++)
                    {
                        d = word[p];

                        //storing last indext of each char from the word
                        new_last_index = s.LastIndexOf(d);

                        //comparing last index of new char from earlier last index
                        if (new_last_index > lastindex)
                        {
                            //using substring to extend the word using new last index
                            word = s.Substring(firstindex, new_last_index + 1);

                            //overwriting variable with new last index
                            lastindex = word.LastIndexOf(d);
                        }

                    }

                    //removing words from input string
                    s = s.Remove(firstindex, lastindex + 1);

                    //adding new words to list
                    labels.Add(word);
                }

                //declaring empty list
                List<int> f_res = new List<int>();

                //using for loop to calculate length of each word
                for (int i = 0; i < labels.Count; i++)
                {
                    //storing length in list
                    f_res.Add(labels[i].Length);
                }
                return f_res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //reflection - question was difficut to solve, tried foreach loop but it did not work as expected, it is not flexible. Replaced foreach loop with while and for loop. Got to know shortcomings of foreach loop

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths, string bulls_String9)
        {
            try
            {
                //write your code here.

                //storing alphabets in variable
                string alpha = "abcdefghijklmnopqrstuvwxyz";

                //storing length of input string
                int len = bulls_String9.Length;

                //dec;aring empty variables
                int sum = 0;
                int i = 0;
                int counter = 0;
                int result = 0;
                int index = 0;

                //using while loop
                while (i < len)
                {
                    //using while loop till sum is less than 100
                    while ((sum + widths[alpha.ToList().IndexOf(bulls_String9.ToList()[i])]) <= 100)
                    {
                        //storing index of input string
                        index = alpha.ToList().IndexOf(bulls_String9.ToList()[i]);

                        //adding value from array based on index
                        sum = sum + widths[index];

                        //incrementing variable
                        i++;

                        //breaking loop when string ends
                        if (i == len) break;
                    }

                    //incrementing variable
                    counter++;

                    //storing sum into different variable for final result
                    result = sum;

                    //clearing sum variable for new iteration
                    sum = 0;
                }

                return new List<int>() { counter, result };
            }
            catch (Exception)
            {
                throw;
            }

        }
        //reflection - question was trickier to understand, tried few times with wrong understanding and  got wrong answers then tried again from scratch and solved it

        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                //storing 3 types of brackets
                List<string> match = new List<string> { "{}", "[]", "()" };

                //declaring empty variables
                int index = 0;

                while (bulls_string10.Length > 0)
                {
                    //checking for 1st type of brackets
                    if (bulls_string10.Contains(match[0]))
                    {
                        //if it exists then removing it
                        index = bulls_string10.IndexOf(match[0]);
                        bulls_string10 = bulls_string10.Remove(index, 2);
                    }

                    //checking for 2nd type bracket
                    else if (bulls_string10.Contains(match[1]))
                    {
                        //if it exists then removing it
                        index = bulls_string10.IndexOf(match[1]);
                        bulls_string10 = bulls_string10.Remove(index, 2);
                    }

                    //checking for 3nd type bracket
                    else if (bulls_string10.Contains(match[2]))
                    {
                        //if it exists then removing it
                        index = bulls_string10.IndexOf(match[2]);
                        bulls_string10 = bulls_string10.Remove(index, 2);
                    }

                    //when length is not zero after removing all 3 types of brackets
                    else return false;
                }
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }
        //reflection - tried few solutions before coming to this solution, other solutions were failing at few other cases 


        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //write your code here.

                //storing all morse codes as per order
                string[] morse = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

                //storing engish alphabets
                string alpha = "abcdefghijklmnopqrstuvwxyz";

                //declaring empty variables
                string s = "";
                int index = 0;
                string mcode = "";
                int i = 0;
                int j = 0;

                //dclaring empty list
                List<string> mlist = new List<string>();

                while (i < words.Length)
                {
                    //storing 1st char from input string
                    s = words[i];

                    j = 0;
                    while (j < s.Length)
                    {
                        //finding index of char
                        index = alpha.IndexOf(s[j]);

                        //finding morse code corresponding char
                        mcode = mcode.ToString() + morse[index].ToString();

                        //incrementing variable
                        j++;
                    }

                    //storing loop count
                    i++;

                    //adding word to the list
                    mlist.Add(mcode);

                    //clearing word varible
                    mcode = "";

                }

                //returing count of distinct words
                return mlist.Distinct().Count();

            }
            catch (Exception)
            {
                throw;
            }

        }
        //reflection - question was easy to solve, did not involve lot of steps and did not use any complicated methods

        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                int start = grid[0, 0];

                List<int> neighbours = new List<int>();

                int[,] grid_new;



                for (int i = 1; i < grid.Length; i++)

                {
                    //neighbours.Add(grid[i, 0]);
                    //neighbours.Add(grid[0,i]);


                }
                Console.WriteLine();
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                int counter = 0;
                int index = 0;

                Console.WriteLine(word1.CompareTo(word2));

                for (int i = 0; i < word1.Length; i++)
                {
                    if (word2.Contains(word1[i]))
                    {
                        index = word2.IndexOf(word1[i]);
                        if(index != word1.IndexOf(word1[i]))
                        {
                            counter++;
                        }
                    }
                    else
                    {
                        counter++;
                        word1 = word1.Remove(i, 1);
                        //Console.WriteLine(word1);
                    }
                    
                }
                return counter;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}