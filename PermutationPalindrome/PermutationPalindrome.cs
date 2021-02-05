using System;
using System.Collections.Generic;

namespace PermutationPalindrome
{
    class PermutationPalindrome
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Possible solutions
            //Create a tree of matching letter pairs
            //Validate the ordered pairs exist by sorting the string and finding if there's uneven 
                //number of characters for more than one letter
            //Count the number of characters, see if any more than one are uneven

        }
    }

    /// <summary>
    /// Base class for the different types of palindrome permutation searchers
    /// </summary>
    abstract public class Permuter
    {
        public Permuter() { }

        /// <summary>
        /// All instances have to implement the palindrome search algorithm
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public abstract bool HasPalindrome(String Input);

    }

    /// <summary>
    /// Search through the string by doing the following:
    /// 1. Insert the number of instances of each character into a dictionary
    /// 2. Traverse through the values of the dictionary, looking for the number of uneven instances
    /// 3. If we find more than 1 uneven instance, we know the string can't be a palindrome
    /// </summary>
    public class DictionarySearch : Permuter
    {
        public override bool HasPalindrome(string Input)
        {
            Dictionary<char, int> count = new Dictionary<char,int>();
            bool retVal = true;
            if(String.IsNullOrEmpty(Input) == true)
            {
                //Nothing to do, so it's a palindrome
                return retVal;
            }

            //1. Insert the number of instances of each character into a dictionary
            foreach (Char x in Input.ToCharArray())
            {
                if (count.ContainsKey(x))
                {                    
                    count[x]++;
                }
                else
                {
                    count[x] = 1;
                }
            }

            bool hasOdd = false;
            foreach (int x in count.Values)
            {
                // 2.Traverse through the values of the dictionary, looking for the number of uneven instances
                if (x % 2 == 1)
                {
                    //Odd number
                    if(true == hasOdd)
                    {
                        // 3. If we find more than 1 uneven instance, we know the string can't be a palindrome
                        retVal = false;
                        break;
                    }
                    else
                    {
                        //We can only handle one odd value
                        hasOdd = true;
                    }
                }
            }

            return retVal;

        }
    }

    /// <summary>
    /// Sort the string, then traverse through it element by element.  Keep count of
    /// the number of uneven pairs.  If we find more than 1, we know it can't be a palindrome
    /// </summary>
    public class SortAndTraverse : Permuter
    {
        public override bool HasPalindrome(String Input)
        {
            bool retVal = true;
            if(String.IsNullOrEmpty(Input) == true)
            {
                //TODO: Duplicated code.  Refactor
                return retVal;
            }

            //Step 1: Sort the array
            char[] sortedarray = Input.ToCharArray();
            Array.Sort(sortedarray);


            //Go through, looking for uneven balancing of unique characters
            char prev = sortedarray[0];
            bool uneven = false;
            int count = 1;
            for(int i = 1; i < sortedarray.Length; i++)
            {
                if(sortedarray[i] != prev)
                {
                    //New character, count what we have
                    prev = sortedarray[i];
                    if(count % 2 == 1)
                    {
                        //Uneven number of characters
                        if(false == uneven)
                        {
                            //We already have one uneven, abort
                            retVal = false;
                            break;
                        }
                        //Record that we hit an uneven number, continue on
                        uneven = false;                        
                    }
                    //Reset the count
                    count = 1;
                }
                else
                {
                    //Same character continues
                    count++;
                }                
            }

            return retVal;
        }
    }
}
