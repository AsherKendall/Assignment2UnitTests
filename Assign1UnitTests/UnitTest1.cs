using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hello_World;
using System;

namespace Hello_World.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod]
        public void PrintMenuTest()
        {

            var menu = "\n1: Select Random Number 1-10\n" +
                    "2: Print Current Date in ShortDate format\n" +
                    "3: Sort and print random Name of 10 Dinos\n" +
                    "4: Random String Manipulation\n\n";
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                Functions.PrintMenu();
                string yea = writer.ToString();
                Assert.AreEqual(menu, writer.ToString());
            }
        }
        [TestMethod]
        public void RandomNumber()
        {
            for (var i = 0; i < 100; i++)
            {
                var num = Functions.RandomNumber();
                Assert.IsTrue(num >= 1 && num < 11);
            }

        }

        [TestMethod]
        public void CheckShortDate()
        {
            string date = Functions.PrintDate();

            Assert.AreEqual(DateTime.Now.ToShortDateString(), date);
        }

        [TestMethod]
        public void CheckShortDateFail()
        {
            Assert.IsNotNull(null);
        }

        [TestMethod]
        public void CheckDinoSort()
        {
            List<string> dinos = new List<string>()
                    {
                        "Hypacrosaurus",
                        "Aeolosaurus",
                        "Zanabazar",
                        "Alamosaurus",
                        "Nuthetes",
                        "Szechuanosaurus",
                        "Torvosaurus",
                        "Vulcanodon",
                        "Acrotholus",
                        "Pampadromaeus",
                    };

            var finalres = dinos.OrderBy(n => n).ToList<string>();
            for (var x = 0; x < 100; x++)
            {
                bool check = false;
                string output = Functions.RandomDinoSort();
                for (int i = 0; i < finalres.Count; i++)
                {
                    if (output == finalres[i].ToString() + " index " + i)
                    {
                        check = true;
                    }
                }
                Assert.IsTrue(check);
            }
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz")]
        [DataRow("exmaple strings yeah")]
        [DataRow("\n\n\n\n\n\n\n;;;;...sdsd")]
        [DataRow("\n")]
        [DataRow("                                                ")]
        public void CheckRandomStringManipulation(string input)
        {
            for (var x = 0; x < 100; x++)
            {
                var output = Functions.RandomStringManipulation(input);
                Assert.IsNotNull(output);
            }
        }
    }
}