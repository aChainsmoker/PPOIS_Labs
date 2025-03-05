using Lab1;

namespace WeddingTests;

[TestClass]
public class ResultSummarizerTests
{
    [TestMethod]
    public void Summarize_ShouldCalculateCorrectPoints()
    {
        var wedding = new Wedding
        {
            Groom = new Groom
            {
                Suit = new Suit(1000, ""),
                Ring = new Ring (300, ""),
                Budget = 1000
            },
            Fiancee = new Fiancee
            {
                Suit = new Suit (99, ""),
                Budget = 500
            },
            Banquet = new Banquet
            {
                Dishes = new List<Dish>
                {
                    new Dish("", 100, 300)
                }
            }
        };

        Ceremony ceremony = new Ceremony(wedding.Groom, wedding.Fiancee, null);
        wedding.Ceremony = ceremony;
        ceremony.Guests = new List<Guest>
        {
            new Guest ("")
        };

        int expectedPoints = 300 + 100 + 200 + 2 * 30 + (1500 / 100);

        int result = ResultSummarizer.Summarize(wedding);

        Assert.AreEqual(expectedPoints, result);
    }

    [TestMethod]
    public void CalculateDeadEnd_ShouldReturnTrue_WhenBudgetIsTooLow()
    {
        var wedding = new Wedding { SharedBudget = 100 };
        var prices = new List<uint> { 150, 200, 250 };

        bool isDeadEnd = ResultSummarizer.CalculateDeadEnd(wedding, prices);

        Assert.IsTrue(isDeadEnd);
    }

    [TestMethod]
    public void CalculateDeadEnd_ShouldReturnFalse_WhenBudgetIsSufficient()
    {
        var wedding = new Wedding { SharedBudget = 300 };
        var prices = new List<uint> { 150, 200, 250 };

        bool isDeadEnd = ResultSummarizer.CalculateDeadEnd(wedding, prices);

        Assert.IsFalse(isDeadEnd);
    }
}