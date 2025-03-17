using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1;
using System;
using System.Diagnostics;

namespace WeddingTests
{
    [TestClass]
    public class WeddingPhaseTransitionsTests
    {
        private Wedding _wedding;

        [TestInitialize]
        public void Setup()
        {
            _wedding = new Wedding(new ChoosingWeddingPhaseState());
            Console.SetIn(new StringReader(
                "1\n" + "John\nJane\n" + "8\n9\n10\n11\n" +
                "2\n" + "1\n" +
                "3\n" + "1\n" +
                "4\n" + "1\n" +
                "5\n" + "1\n" + "8\n9\n10\n11\n" +
                "6\n1\n1\n1\n1\n1\n" +
                "7\n2\nAlice\nBob\n" +
                "8\n\n" +
                "9\n\n" +
                "10\n\n" +
                "11\n\n" +
                "\n"
            ));
        }

        [TestCleanup]
        public void CleanUp()
        {
            JsonStateManager.DeleteState("WeddingRecord.json");
        }

        [TestMethod]
        public void StateTransitionTest()
        {
            while(_wedding.IsConcluded == false)
                _wedding.ChangeState();

            
            Assert.IsTrue(_wedding.IsConcluded);
        }
    }
}