namespace Lab1;

public class ResultSummarizer
{
    public static int Summarize(Wedding wedding)
    {
        int amountOfPoints = 0;
        
        amountOfPoints += wedding.Husband.Suit.Prestige switch
        {
            AttributePrestige.Cheap => 100,
            AttributePrestige.Normal => 200,
            AttributePrestige.Premium => 300
        };
        amountOfPoints += wedding.Wife.Suit.Prestige switch
        {
            AttributePrestige.Cheap => 100,
            AttributePrestige.Normal => 200,
            AttributePrestige.Premium => 300
        };
        amountOfPoints += wedding.Husband.Ring.Prestige switch
        {
            AttributePrestige.Cheap => 100,
            AttributePrestige.Normal => 200,
            AttributePrestige.Premium => 300
        };
        amountOfPoints += 30 * wedding.Ceremony.Guests.Count;

        int foodPoints = 0, hungryGuests = 0;

        for (int i = 0; i < wedding.Banquet.Dishes.Count; i++)
            foodPoints += (int)wedding.Banquet.Dishes[i].FoodPower;

        for (int i = 0; i < wedding.Ceremony.Guests.Count; i++)
        {
            if (foodPoints - wedding.Ceremony.Guests[i].HungerLevel >= 0)
            {
                foodPoints -= (int)wedding.Ceremony.Guests[i].HungerLevel;
            }
        }
        
        amountOfPoints += (wedding.Ceremony.Guests.Count - hungryGuests) * 30;
        amountOfPoints -= hungryGuests * 90;

        amountOfPoints += (int)((wedding.Husband.Budget + wedding.Wife.Budget) / 10);
        
        return amountOfPoints;
    }

    public static bool CalculateDeadEnd(Wedding wedding, List<uint> prices)
    {
        if (prices.Min() > wedding.SharedBudget)
        {
            wedding.WeddingPhase = new LostGameState();
            return true;
        }

        return false;
    }
}