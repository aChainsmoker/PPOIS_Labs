﻿namespace Lab1;

public static class ResultSummarizer
{
    public static int Summarize(Wedding wedding)
    {
        int amountOfPoints = 0;
        
        amountOfPoints += wedding.Groom.Suit.Prestige switch
        {
            AttributePrestige.Cheap => 100,
            AttributePrestige.Normal => 200,
            AttributePrestige.Premium => 300
        };
        amountOfPoints += wedding.Fiancee.Suit.Prestige switch
        {
            AttributePrestige.Cheap => 100,
            AttributePrestige.Normal => 200,
            AttributePrestige.Premium => 300
        };
        amountOfPoints += wedding.Groom.Ring.Prestige switch
        {
            AttributePrestige.Cheap => 100,
            AttributePrestige.Normal => 200,
            AttributePrestige.Premium => 300
        };
        amountOfPoints += 30 * wedding.Guests.Count;

        int foodPoints = 0, hungryGuests = 0;

        for (int i = 0; i < wedding.Banquet.Dishes.Count; i++)
            foodPoints += (int)wedding.Banquet.Dishes[i].FoodPower;
        
        for (int i = 0; i < wedding.Guests.Count; i++)
        {
            if (foodPoints - wedding.Guests[i].HungerLevel >= 0)
            {
                foodPoints -= (int)wedding.Guests[i].HungerLevel;
            }
        }
        
        amountOfPoints += (wedding.Guests.Count - hungryGuests) * 30;
        amountOfPoints -= hungryGuests * 90;

        amountOfPoints += (int)((wedding.Groom.Budget + wedding.Fiancee.Budget) / 100);
        amountOfPoints -= wedding.SharedBudget < 0 ? wedding.SharedBudget : 0;
        
        return amountOfPoints;
    }
}