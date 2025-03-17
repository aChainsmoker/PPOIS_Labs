using Lab1;

namespace WeddingTests;

[TestClass]
public class IOSystemTests
{
    private StringWriter _stringWriter;
    private StringReader _stringReader;

    [TestInitialize]
    public void Initialize()
    {
        _stringWriter = new StringWriter();
        Console.SetOut(_stringWriter);
    }

    [TestCleanup]
    public void Cleanup()
    {
        JsonStateManager.DeleteState("WeddingState.json");
    }

    [TestMethod]
    public void ChooseNameForNewlywedsTest()
    {
        _stringReader = new StringReader("John\nJane\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseNameForNewlyweds(out string husbandName, out string wifeName);

        Assert.AreEqual("John", husbandName);
        Assert.AreEqual("Jane", wifeName);
    }

    [TestMethod]
    public void ChooseWeddingPlaceTest()
    {
        var weddingMap = new WeddingMap
        {
            WeddingPlaces = new List<WeddingPlace>
            {
                new WeddingPlace (1000, DateTime.Now, 100, "Location1"),
                new WeddingPlace  (2000, DateTime.Now, 200, "Location2")
            }
        };
        _stringReader = new StringReader("1\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseWeddingPlace(weddingMap, out int indexOfPlace);

        Assert.AreEqual(0, indexOfPlace);
    }

   

    [TestMethod]
    public void DeclareMarriageTest()
    {
        var groom = new Groom { Name = "John" };
        var fiancee = new Fiancee { Name = "Jane" };

        IOSystem.DeclareMarriage(groom, fiancee);

        var output = _stringWriter.ToString();
        Assert.AreEqual("John and Jane got married!\r\n\nPress enter to continue...\r\n", output);
    }

    [TestMethod]
    public void GetPrestigeStringTest()
    {
        var prestige = AttributePrestige.Premium;

        var result = IOSystem.GetPrestigeString(prestige);

        Assert.AreEqual("Premium", result);
    }

    [TestMethod]
    public void GetPrestigeFromStringTest()
    {
        var prestigeString = "Premium";

        var result = IOSystem.GetPrestigeFromString(prestigeString);

        Assert.AreEqual(AttributePrestige.Premium, result);
    }
    
    [TestMethod]
    public void ChooseWeddingDressForFianceeTest()
    {
        var suitStore = new SuitStore
        {
            WomenSuits = new List<Suit>
            {
                new Suit (1000, "Brand1") ,
                new Suit (2000, "Brand2")
            }
        };
        _stringReader = new StringReader("1\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseWeddingDressForFiancee(suitStore, out int indexOfFianceeDress);

        Assert.AreEqual(0, indexOfFianceeDress);
    }



    [TestMethod]
    public void ChooseWeddingDressForGroomTest()
    {
        var suitStore = new SuitStore
        {
            MenSuits = new List<Suit>
            {
                new Suit (1000, "Brand1"),
                new Suit (2000, "Brand2")
            }
        };
        _stringReader = new StringReader("2\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseWeddingDressForGroom(suitStore, out int indexOfGroomDress);

        Assert.AreEqual(1, indexOfGroomDress);
    }
    

    [TestMethod]
    public void ChooseWeddingRingTest()
    {
        var ringStore = new RingStore
        {
            Rings = new List<Ring>
            {
                new Ring (1000, "Brand1"), 
                new Ring (2000, "Brand2")
            }
        };
        _stringReader = new StringReader("1\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseWeddingRing(ringStore, out int indexOfRing);

        Assert.AreEqual(0, indexOfRing);
    }

    [TestMethod]
    public void ChooseWeddingMenuTest()
    {
        var weddingMenu = new WeddingMenu
        {
            Dishes = new List<Dish>
            {
                new Dish("Dish1", 100, 50) ,
                new Dish ("Dish2", 200, 100)
            }
        };
        _stringReader = new StringReader("1\n2\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseWeddingMenu(weddingMenu, out int[] indexesOfWeddingMenu);

        CollectionAssert.AreEqual(new int[] { 0, 1, -1, -1, -1 }, indexesOfWeddingMenu);
    }

    

    [TestMethod]
    public void InviteGuestsTest()
    {
        _stringReader = new StringReader("2\nGuest1\nGuest2\n");
        Console.SetIn(_stringReader);

        IOSystem.InviteGuests(out string[] names);

        CollectionAssert.AreEqual(new string[] { "Guest1", "Guest2" }, names);
    }
    

    [TestMethod]
    public void DeclareBanquetTest()
    {
        IOSystem.DeclareBanquet();

        var output = _stringWriter.ToString();
        Assert.AreEqual("Banquet was held\r\n\nPress enter to continue...\r\n", output);
    }

    [TestMethod]
    public void DeclarePhotoSessionTest()
    {
        IOSystem.DeclarePhotoSession();

        var output = _stringWriter.ToString();
        Assert.AreEqual("Photo session was held\r\n\nPress enter to continue...\r\n", output);
    }

    [TestMethod]
    public void DisplaySummarazationTest()
    {
        int amountOfPoints = 1000;
        var expectedOutput = $"Your final result: 1000\r\nNo saved state found.\n\r\n\nRecord: \r\n";

        IOSystem.DisplaySummarazation(amountOfPoints);

        var output = _stringWriter.ToString();
        Assert.AreEqual(expectedOutput, output);
    }

    [TestMethod]
    public void PrintBudgetTest()
    {
        int budget = 5000;

        IOSystem.PrintBudget(budget);

        var output = _stringWriter.ToString();
        Assert.AreEqual($"Current balance: {budget}\n\r\n", output);
    }
    
    [TestMethod]
public void GetTheWeddingStateStringTest()
{
    Assert.AreEqual("CreatingNewlywedState", IOSystem.GetTheWeddingStateString(new CreatingNewlywedState()));
    Assert.AreEqual("ChoosingGroomDressState", IOSystem.GetTheWeddingStateString(new ChoosingGroomDressState()));
    Assert.AreEqual("ChoosingFianceeDressState", IOSystem.GetTheWeddingStateString(new ChoosingFianceeDressState()));
    Assert.AreEqual("ChoosingRingState", IOSystem.GetTheWeddingStateString(new ChoosingRingState()));
    Assert.AreEqual("BanquetState", IOSystem.GetTheWeddingStateString(new BanquetState()));
    Assert.AreEqual("CeremonyState", IOSystem.GetTheWeddingStateString(new CeremonyState()));
    Assert.AreEqual("ChoosingWeddingMenuState", IOSystem.GetTheWeddingStateString(new ChoosingWeddingMenuState()));
    Assert.AreEqual("ChoosingWeddingPlaceState", IOSystem.GetTheWeddingStateString(new ChoosingWeddingPlaceState()));
    Assert.AreEqual("GuestInvitationState", IOSystem.GetTheWeddingStateString(new GuestInvitationState()));
    Assert.AreEqual("PhotoSessionState", IOSystem.GetTheWeddingStateString(new PhotoSessionState()));
    Assert.AreEqual("SummarizeState", IOSystem.GetTheWeddingStateString(new SummarizeState()));
}

[TestMethod]
public void GetTheWeddingPhaseFromStringTest()
{
    Assert.IsInstanceOfType(IOSystem.GetTheWeddingPhaseFromString("CreatingNewlywedState"), typeof(CreatingNewlywedState));
    Assert.IsInstanceOfType(IOSystem.GetTheWeddingPhaseFromString("ChoosingGroomDressState"), typeof(ChoosingGroomDressState));
    Assert.IsInstanceOfType(IOSystem.GetTheWeddingPhaseFromString("ChoosingFianceeDressState"), typeof(ChoosingFianceeDressState));
    Assert.IsInstanceOfType(IOSystem.GetTheWeddingPhaseFromString("ChoosingRingState"), typeof(ChoosingRingState));
    Assert.IsInstanceOfType(IOSystem.GetTheWeddingPhaseFromString("BanquetState"), typeof(BanquetState));
    Assert.IsInstanceOfType(IOSystem.GetTheWeddingPhaseFromString("CeremonyState"), typeof(CeremonyState));
    Assert.IsInstanceOfType(IOSystem.GetTheWeddingPhaseFromString("ChoosingWeddingMenuState"), typeof(ChoosingWeddingMenuState));
    Assert.IsInstanceOfType(IOSystem.GetTheWeddingPhaseFromString("ChoosingWeddingPlaceState"), typeof(ChoosingWeddingPlaceState));
    Assert.IsInstanceOfType(IOSystem.GetTheWeddingPhaseFromString("GuestInvitationState"), typeof(GuestInvitationState));
    Assert.IsInstanceOfType(IOSystem.GetTheWeddingPhaseFromString("PhotoSessionState"), typeof(PhotoSessionState));
    Assert.IsInstanceOfType(IOSystem.GetTheWeddingPhaseFromString("SummarizeState"), typeof(SummarizeState));
}

[TestMethod]
public void DisplayFinalResultUnmarriedTest()
{
    var wedding = new Wedding { 
        Groom = new Groom("John"), 
        Fiancee = new Fiancee("Jane")
    };
    var stringWriter = new StringWriter();
    Console.SetOut(stringWriter);

    IOSystem.DisplayFinalResult(wedding);

    StringAssert.Contains(stringWriter.ToString(), "did not get married :/");
}

[TestMethod]
public void DisplayCeremonyRequirementsTest()
{
    var stringWriter = new StringWriter();
    Console.SetOut(stringWriter);

    IOSystem.DisplayCeremonyRequirements();

    StringAssert.Contains(stringWriter.ToString(), "names for newlyweds, rings");
}

[TestMethod]
public void ClearTest()
{
    var originalOut = Console.Out;
    Console.SetOut(TextWriter.Null);
    
    try 
    {
        IOSystem.Clear();
    }
    finally 
    {
        Console.SetOut(originalOut);
    }
}

[TestMethod]
public void ShowAlreadyMarriedStatusTest()
{
    var stringWriter = new StringWriter();
    Console.SetOut(stringWriter);

    IOSystem.ShowAlreadyMarriedStatus();

    StringAssert.Contains(stringWriter.ToString(), "Ceremony was already held.");
}

[TestMethod]
public void ShowAlreadyHeldBanquetStatusTest()
{
    var stringWriter = new StringWriter();
    Console.SetOut(stringWriter);

    IOSystem.ShowAlreadyHeldBanquetStatus();
    StringAssert.Contains(stringWriter.ToString(), "Banquet was already held.");
}

}