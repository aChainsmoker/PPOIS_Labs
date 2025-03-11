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
            _wedding = new Wedding(new CreatingNewlywedState());
            Console.SetIn(new StringReader(
                "John\nJane\n" +
                "1\n" +
                "1\n" +
                "1\n" +
                "1\n" +
                "1\n1\n1\n1\n1\n" +
                "2\nAlice\nBob\n" +
                "\n\n\n\n"
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
            _wedding.ChangeState();
            Assert.IsInstanceOfType(_wedding.WeddingPhase, typeof(ChoosingWeddingPlaceState));
            
            _wedding.ChangeState();
            Assert.IsInstanceOfType(_wedding.WeddingPhase, typeof(ChoosingFianceeDressState));
            
            _wedding.ChangeState();
            Assert.IsInstanceOfType(_wedding.WeddingPhase, typeof(ChoosingGroomDressState));
            
            _wedding.ChangeState();
            Assert.IsInstanceOfType(_wedding.WeddingPhase, typeof(ChoosingRingState));
            
            _wedding.ChangeState();
            Assert.IsInstanceOfType(_wedding.WeddingPhase, typeof(ChoosingWeddingMenuState));
            
            _wedding.ChangeState();
            Assert.IsInstanceOfType(_wedding.WeddingPhase, typeof(GuestInvitationState));
            
            _wedding.ChangeState();
            Assert.IsInstanceOfType(_wedding.WeddingPhase, typeof(CeremonyState));
            
            _wedding.ChangeState();
            Assert.IsInstanceOfType(_wedding.WeddingPhase, typeof(PhotoSessionState));
            
            _wedding.ChangeState();
            Assert.IsInstanceOfType(_wedding.WeddingPhase, typeof(BanquetState));
            
            _wedding.ChangeState();
            Assert.IsInstanceOfType(_wedding.WeddingPhase, typeof(SummarizeState));
            
            _wedding.ChangeState();
            
            Assert.IsTrue(_wedding.IsConcluded);
        }
    }
}