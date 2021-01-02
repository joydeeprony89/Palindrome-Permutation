using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindrome_Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanPermutePalindrome("aab")); //
        }

        static bool CanPermutePalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;
            Dictionary<char, int> trace = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (trace.ContainsKey(c))
                {
                    trace[c] += 1;
                }
                else
                {
                    trace[c] = 1;
                }
            }

            int oddCharCount = 0;
            foreach (int i in trace.Values)
            {
                if (oddCharCount >= 2) return false; // no of char count should be all even to satisfy a string to be palindrom or max one odd char count can be possible
                if (i % 2 != 0) oddCharCount++;
            }

            return oddCharCount <= 1;
        }

        static bool CanPermutePalindromeusingHashSet(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;
            HashSet<char> hash = new HashSet<char>();
            foreach (char c in s)
            {
                if (!hash.Contains(c))
                {
                    hash.Add(c);
                }
                else
                {
                    hash.Remove(c);
                }
            }

            return hash.Count <= 1; // only one odd char count allowed for a string to be a palindrom. Eg= aaaabbbccc // abacccaba or abacbcaba are palindrom not the abaccbcaba/ababcccaba
        }
    }
}
