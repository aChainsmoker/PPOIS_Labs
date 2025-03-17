using Lab1;

namespace WeddingTests;

[TestClass]
public class ResultSummarizerTests
{
    [TestMethod]
    public void SummarizeTest()
    {
        var wedding = new Wedding()
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
            },
        };

        Ceremony ceremony = new Ceremony(wedding.Groom, wedding.Fiancee, null);
        wedding.Ceremony = ceremony;
        wedding.Guests = new List<Guest>
        {
            new Guest ("")
        };

        int expectedPoints = 300 + 100 + 200 + 2 * 30 + (1500 / 100);

        int result = ResultSummarizer.Summarize(wedding);

        Assert.AreEqual(expectedPoints, result);
    }
}