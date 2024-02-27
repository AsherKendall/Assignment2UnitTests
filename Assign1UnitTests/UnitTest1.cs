using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hello_World;

namespace Assign1UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("6")]
        [DataRow("-1")]
        public void InvalidNumber(string input)
        {
            var hello = new Hello_World.Program();
            var menu = "\n1: Select Random Number 1-10\n" +
                    "2: Print Current Date in ShortDate format\n" +
                    "3: Sort and print random Name of 10 Dinos\n" +
                    "4: Random String Manipulation\n\n";
            using (var writer = new StringWriter())
            {
                
                using (var reader = new StringReader(input))
                {
                    Console.SetOut(writer);
                    Console.SetIn(reader);

                    string yea = writer.ToString();
                    Assert.AreEqual(menu, writer.ToString());
                }
            }
        }
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}