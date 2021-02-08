using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermutationPalindrome;
using System.Diagnostics;

namespace PalindromeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleTestSetup()
        {
            SimpleTests(new DictionarySearch());
            SimpleTests(new SortAndTraverse());
            SimpleTests(new LINQPermuter());
            SimpleTests(new AndrewTest());
            SimpleTests(new StephenPermuter());
        }
        
        private void SimpleTests(Permuter permuter)
        {
            //I don't like copy/pasting my tests like this.  Any ideas for a better way?
            Assert.IsTrue(permuter.HasPalindrome("abba"));
            Assert.IsTrue(permuter.HasPalindrome("abcba"));
            Assert.IsTrue(permuter.HasPalindrome("aabbc"));
            Assert.IsFalse(permuter.HasPalindrome("abc"));
        }

        
        [TestMethod]
        public void GivenTestSetup()
        {
            GivenTests(new DictionarySearch());
            GivenTests(new SortAndTraverse());
            GivenTests(new LINQPermuter());
            GivenTests(new AndrewTest());
            GivenTests(new StephenPermuter());
        }

        private void GivenTests(Permuter permuter)
        {
            Assert.IsTrue(permuter.HasPalindrome("civic"));
            Assert.IsTrue(permuter.HasPalindrome("ivicc"));
            Assert.IsFalse(permuter.HasPalindrome("civil"));
            Assert.IsFalse(permuter.HasPalindrome("livci"));
        }

        [TestMethod]
        public void EdgeCaseTestSetup()
        {
            EdgeCaseTestSetup(new DictionarySearch());
            EdgeCaseTestSetup(new SortAndTraverse());
            EdgeCaseTestSetup(new LINQPermuter());
            EdgeCaseTestSetup(new AndrewTest());
            EdgeCaseTestSetup(new StephenPermuter());
        }

        private void EdgeCaseTestSetup(Permuter permuter)
        {
            Assert.IsTrue(permuter.HasPalindrome(""));
            Assert.IsTrue(permuter.HasPalindrome(" "));
            Assert.IsTrue(permuter.HasPalindrome(null));
            Assert.IsTrue(permuter.HasPalindrome("a"));
            Assert.IsTrue(permuter.HasPalindrome("aa"));
        }

        [TestMethod]
        public void TimingTest()
        {
            //Test the dictionary           
            TimingTestExecution(new DictionarySearch(), "abcdefghijklmnopqrstuvwxyz", 1000000);
            TimingTestExecution(new DictionarySearch(), "aaaaaaaaaaaaaaaaaaaaaaaaaaabc", 1000000);
            TimingTestExecution(new DictionarySearch(), "aaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabc", 1000000);


            //Test the search and sort
            TimingTestExecution(new SortAndTraverse(), "abcdefghijklmnopqrstuvwxyz", 1000000);
            TimingTestExecution(new SortAndTraverse(), "aaaaaaaaaaaaaaaaaaaaaaaaaaabc", 1000000);
            TimingTestExecution(new SortAndTraverse(), "aaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabc", 1000000);

            TimingTestExecution(new LINQPermuter(), "abcdefghijklmnopqrstuvwxyz", 1000000);
            TimingTestExecution(new LINQPermuter(), "aaaaaaaaaaaaaaaaaaaaaaaaaaabc", 1000000);
            TimingTestExecution(new LINQPermuter(), "aaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabc", 1000000);


            TimingTestExecution(new AndrewTest(), "abcdefghijklmnopqrstuvwxyz", 1000000);
            TimingTestExecution(new AndrewTest(), "aaaaaaaaaaaaaaaaaaaaaaaaaaabc", 1000000);
            TimingTestExecution(new AndrewTest(), "aaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabc", 1000000);

            TimingTestExecution(new StephenPermuter(), "abcdefghijklmnopqrstuvwxyz", 1000000);
            TimingTestExecution(new StephenPermuter(), "aaaaaaaaaaaaaaaaaaaaaaaaaaabc", 1000000);
            TimingTestExecution(new StephenPermuter(), "aaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaabc", 1000000);
        }

        private void TimingTestExecution(Permuter permuter,
                                         string input,
                                         int numberofruns)
        {
            Trace.Write("Testing " + permuter.ToString() + " with " + numberofruns + ": ");
            var watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < numberofruns; i++)
            {
                permuter.HasPalindrome(input);
            }
            watch.Stop();
            Trace.WriteLine(watch.ElapsedMilliseconds);
        }

      
    }
}
