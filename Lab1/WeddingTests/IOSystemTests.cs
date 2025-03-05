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

    [TestMethod]
    public void ChooseNameForNewlyweds_ValidInput_ReturnsCorrectNames()
    {
        _stringReader = new StringReader("John\nJane\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseNameForNewlyweds(out string husbandName, out string wifeName);

        Assert.AreEqual("John", husbandName);
        Assert.AreEqual("Jane", wifeName);
    }

    [TestMethod]
    public void ChooseWeddingPlace_ValidInput_ReturnsCorrectIndex()
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
    [ExpectedException(typeof(System.FormatException))]
    public void ChooseWeddingPlace_InvalidInput_ThrowsFormatException()
    {
        var weddingMap = new WeddingMap
        {
            WeddingPlaces = new List<WeddingPlace>
            {
                new WeddingPlace (1000, DateTime.Now, 100, "Location1")
            }
        };
        _stringReader = new StringReader("invalid\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseWeddingPlace(weddingMap, out int indexOfPlace);
    }

    [TestMethod]
    public void DeclareMarriage_ValidInput_PrintsCorrectMessage()
    {
        var groom = new Groom { Name = "John" };
        var fiancee = new Fiancee { Name = "Jane" };

        IOSystem.DeclareMarriage(groom, fiancee);

        var output = _stringWriter.ToString();
        Assert.AreEqual("John and Jane got married!\r\n", output);
    }

    [TestMethod]
    public void GetPrestigeString_ValidInput_ReturnsCorrectString()
    {
        var prestige = AttributePrestige.Premium;

        var result = IOSystem.GetPrestigeString(prestige);

        Assert.AreEqual("Premium", result);
    }

    [TestMethod]
    public void GetPrestigeFromString_ValidInput_ReturnsCorrectPrestige()
    {
        var prestigeString = "Premium";

        var result = IOSystem.GetPrestigeFromString(prestigeString);

        Assert.AreEqual(AttributePrestige.Premium, result);
    }
    
    [TestMethod]
    public void ChooseWeddingDressForFiancee_ValidInput_ReturnsCorrectIndex()
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
    [ExpectedException(typeof(System.FormatException))]
    public void ChooseWeddingDressForFiancee_InvalidInput_ThrowsFormatException()
    {
        var suitStore = new SuitStore
        {
            WomenSuits = new List<Suit>
            {
                new Suit (1000, "Brand1")
            }
        };
        _stringReader = new StringReader("invalid\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseWeddingDressForFiancee(suitStore, out int indexOfFianceeDress);
    }

    [TestMethod]
    public void ChooseWeddingDressForGroom_ValidInput_ReturnsCorrectIndex()
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
    [ExpectedException(typeof(System.FormatException))]
    public void ChooseWeddingDressForGroom_InvalidInput_ThrowsFormatException()
    {
        var suitStore = new SuitStore
        {
            MenSuits = new List<Suit>
            {
                new Suit (1000, "Brand1")
            }
        };
        _stringReader = new StringReader("invalid\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseWeddingDressForGroom(suitStore, out int indexOfGroomDress);
    }

    [TestMethod]
    public void ChooseWeddingRing_ValidInput_ReturnsCorrectIndex()
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
    [ExpectedException(typeof(System.FormatException))]
    public void ChooseWeddingRing_InvalidInput_ThrowsFormatException()
    {
        var ringStore = new RingStore
        {
            Rings = new List<Ring>
            {
                new Ring (1000, "Brand1")
            }
        };
        _stringReader = new StringReader("invalid\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseWeddingRing(ringStore, out int indexOfRing);
    }

    [TestMethod]
    public void ChooseWeddingMenu_ValidInput_ReturnsCorrectIndexes()
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
    [ExpectedException(typeof(System.FormatException))]
    public void ChooseWeddingMenu_InvalidInput_ThrowsFormatException()
    {
        var weddingMenu = new WeddingMenu
        {
            Dishes = new List<Dish>
            {
                new Dish ("Dish1", 100, 50) ,
            }
        };
        _stringReader = new StringReader("invalid\n");
        Console.SetIn(_stringReader);

        IOSystem.ChooseWeddingMenu(weddingMenu, out int[] indexesOfWeddingMenu);
    }

    [TestMethod]
    public void InviteGuests_ValidInput_ReturnsCorrectNames()
    {
        _stringReader = new StringReader("2\nGuest1\nGuest2\n");
        Console.SetIn(_stringReader);

        IOSystem.InviteGuests(out string[] names);

        CollectionAssert.AreEqual(new string[] { "Guest1", "Guest2" }, names);
    }

    [TestMethod]
    [ExpectedException(typeof(System.FormatException))]
    public void InviteGuests_InvalidInput_ThrowsFormatException()
    {
        _stringReader = new StringReader("invalid\n");
        Console.SetIn(_stringReader);

        IOSystem.InviteGuests(out string[] names);
    }

    [TestMethod]
    public void DeclareBanquet_PrintsCorrectMessage()
    {
        IOSystem.DeclareBanquet();

        var output = _stringWriter.ToString();
        Assert.AreEqual("Banquet was held\r\n", output);
    }

    [TestMethod]
    public void DeclarePhotoSession_PrintsCorrectMessage()
    {
        IOSystem.DeclarePhotoSession();

        var output = _stringWriter.ToString();
        Assert.AreEqual("Photo session was held\r\n", output);
    }

    [TestMethod]
    public void DisplaySummarazation_PrintsCorrectMessage()
    {
        int amountOfPoints = 1000;
        var expectedOutput = $"Your final result: {amountOfPoints}\r\nNo saved state found.\n\r\n\nRecord: \r\n";

        IOSystem.DisplaySummarazation(amountOfPoints);

        var output = _stringWriter.ToString();
        Assert.AreEqual(expectedOutput, output);
    }

    [TestMethod]
    public void PrintBudget_PrintsCorrectMessage()
    {
        int budget = 5000;

        IOSystem.PrintBudget(budget);

        var output = _stringWriter.ToString();
        Assert.AreEqual($"Current balance: {budget}\n\r\n", output);
    }

    [TestMethod]
    public void PrintLoserScreen_PrintsCorrectMessage()
    {
        IOSystem.PrintLoserScreen();

        var output = _stringWriter.ToString();
        Assert.AreEqual("You couldn't afford anything from the next list. You lost. That happens\r\n", output);
    }
}