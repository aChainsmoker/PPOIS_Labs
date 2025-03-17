using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1;

namespace WeddingTests
{
    [TestClass]
    public class JsonStateManagerTests
    {
        private const string TestFileName = "TestState.json";
        private Wedding _testWedding;

        [TestInitialize]
        public void Setup()
        {
            _testWedding = new Wedding(new CreatingNewlywedState())
            {
                Groom = new Groom("John"),
                Fiancee = new Fiancee("Jane"),
                SharedBudget = 5000
            };
        }

        [TestCleanup]
        public void Cleanup()
        {
            JsonStateManager.DeleteState("WeddingState.json");
        }

    [TestMethod]
        public void SaveStateTest()
        {
            JsonStateManager.SaveState(_testWedding, TestFileName);

            string filePath = Path.Combine("SavedStates", TestFileName);
            Assert.IsTrue(File.Exists(filePath));

            string content = File.ReadAllText(filePath);
            StringAssert.Contains(content, "John");
            StringAssert.Contains(content, "Jane");
        }

        [TestMethod]
        public void LoadStateTest()
        {
            JsonStateManager.SaveState(_testWedding, TestFileName);

            var loaded = JsonStateManager.LoadState<Wedding>(TestFileName);

            Assert.IsNotNull(loaded);
            Assert.AreEqual("John", loaded.Groom.Name);
            Assert.AreEqual("Jane", loaded.Fiancee.Name);
            Assert.AreEqual(5000, loaded.SharedBudget);
        }

        [TestMethod]
        public void LoadNonexistingStateTest()
        {
            var result = JsonStateManager.LoadState<Wedding>("GhostFile.json");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteStateTest()
        {
            JsonStateManager.SaveState(_testWedding, TestFileName);
            string filePath = Path.Combine("SavedStates", TestFileName);

            JsonStateManager.DeleteState(TestFileName);

            Assert.IsFalse(File.Exists(filePath));
        }

        [TestMethod]
        public void WeddingPhaseStringTest()
        {
            _testWedding.CurrentWeddingPhase = new ChoosingGroomDressState();

            JsonStateManager.SaveState(_testWedding, TestFileName);
            var loaded = JsonStateManager.LoadState<Wedding>(TestFileName);

            Assert.AreEqual("ChoosingGroomDressState", loaded.CurrentWeddingPhaseString);
        }

        [TestMethod]
        public void SaveStateErrorHandlingTest()
        {
            var invalidObject = new NonSerializableClass();

            JsonStateManager.SaveState(invalidObject, TestFileName);
        }

        private class NonSerializableClass
        {
            public Stream NonSerializableProperty { get; } = new MemoryStream();
        }
    }
}