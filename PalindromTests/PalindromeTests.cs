using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PermutationPalindrome;


namespace PalindromTests
{
    [TestClass]
    public class PalindromeTests
    {
        [TestMethod]
        public void TestSimple()
        {
            SortAndSearch Search = new SortAndSearch();
            Assert.IsTrue(Search.HasPalindrome("abba"));
        }
    }
}
