namespace Lab1;
public static class IOSystem
{
    public static void ChooseNameForNewlyweds(out string husbandName, out string wifeName)
    {
        Console.WriteLine("Enter newlywed's names");
        Console.WriteLine("Enter husband's name");
        husbandName = Console.ReadLine();
        Console.WriteLine("Enters wife's name");
        wifeName = Console.ReadLine();
    }

    public static void ChooseWeddingPlace(WeddingMap weddingMap, out int indexOfPlace)
    {
        Console.WriteLine("Choose wedding place");
        DisplayWeddingPlaces(weddingMap.WeddingPlaces);
        indexOfPlace = Convert.ToInt32(Console.ReadLine()) - 1;
    }
    public static void ChooseWeddingAttributes(SuitStore suitStore, RingStore ringStore, out int indexOfFianceeDress, out int indexOfGroomDress, out int indexOfRing)
    {
        Console.WriteLine("Choose fiancee wedding dress");
        DisplayWeddingDresses(suitStore.WomenSuits);
        indexOfFianceeDress = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.Clear();
        Console.WriteLine("Choose groom wedding dress");
        DisplayWeddingDresses(suitStore.MenSuits);
        indexOfGroomDress = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.Clear();
        Console.WriteLine("Choose wedding rings");
        DisplayWeddingRings(ringStore.Rings);
        indexOfRing = Convert.ToInt32(Console.ReadLine()) - 1;
    }
    

    public static void ChooseWeddingMenu(WeddingMenu weddingMenu, out int[] indexesOfWeddingMenu)
    {
        indexesOfWeddingMenu = new int[Banquet.AmountOfDishes];
        Console.WriteLine("Choose wedding menu");
        DisplayWeddingDishes(weddingMenu.Dishes);
        for(int i = 0; i< Banquet.AmountOfDishes; i++)
            indexesOfWeddingMenu[i] = Convert.ToInt32(Console.ReadLine()) - 1;
    }

    public static void InviteGuests(out string[] names)
    {
        Console.WriteLine("Enter amount of guests");
        int amountOfGuests = Convert.ToInt32(Console.ReadLine());
        names = new string[amountOfGuests];
        for (int i = 0; i < amountOfGuests; i++)
        {
            Console.WriteLine("Enter name of guest");
            string? name = Console.ReadLine();
            names[i] = name;
        }
    }
    
    public static void DeclareMarriage(Husband husband, Wife wife)
    {
        Console.WriteLine($"{husband.Name} and {wife.Name} got married!🎉");
    }
    
    public static void DeclareBanquet()
    {
        Console.WriteLine("Banquet was held");
    }
    
    public static void DeclarePhotoSession()
    {
        Console.WriteLine("Photo session was held");
    }

    public static void Summarize(int amountOfPoints)
    {
        Console.WriteLine($"Your final result: {amountOfPoints}");
    }

    private static void DisplayWeddingDishes(List<Dish> weddingDishes)
    {
        for (int i = 0; i < weddingDishes.Count; i++)
        {
            Console.WriteLine($"====={i+1}=====");
            Console.WriteLine(weddingDishes[i].Name);
            Console.WriteLine(weddingDishes[i].Price);
            Console.WriteLine();
        }
    }
    private static void DisplayWeddingDresses(List<Suit> weddingDresses)
    {
        for (int i = 0; i < weddingDresses.Count; i++)
        {
            Console.WriteLine($"====={i+1}=====");
            Console.WriteLine(weddingDresses[i].Brand);
            Console.WriteLine(weddingDresses[i].Price);
            Console.WriteLine(ReturnPrestige(weddingDresses[i].Prestige));
            Console.WriteLine();
        }
    }

    private static void DisplayWeddingRings(List<Ring> weddingRings)
    {
        for (int i = 0; i < weddingRings.Count; i++)
        {
            Console.WriteLine($"====={i+1}=====");
            Console.WriteLine(weddingRings[i].Brand);
            Console.WriteLine(weddingRings[i].Price);
            Console.WriteLine(ReturnPrestige(weddingRings[i].Prestige));
            Console.WriteLine();
        }
    }

    private static void DisplayWeddingPlaces(List<WeddingPlace> weddingPlaces)
    {
        for (int i = 0; i < weddingPlaces.Count; i++)
        {
            Console.WriteLine($"====={i+1}=====");
            Console.WriteLine(weddingPlaces[i].Location);
            Console.WriteLine(weddingPlaces[i].Date);
            Console.WriteLine(weddingPlaces[i].GuestCapacity);
            Console.WriteLine(weddingPlaces[i].Price);
            Console.WriteLine();
        }
    }
    
    private static string ReturnPrestige(AttributePrestige attributePrestige)
    {
        string stringPrestige;
        stringPrestige = attributePrestige switch
        {
            AttributePrestige.Cheap => "Cheap",
            AttributePrestige.Normal => "Normal",
            AttributePrestige.Premium => "Premium"
        };
        return stringPrestige;
    }

    public static void PrintBudget(int budget)
    {
        Console.WriteLine($"Current balance: {budget}\n");
    }

    public static void NotifyAboutBudgetLimit()
    {
        Console.WriteLine("You cant afford it\n");
    }

    public static void PrintLoserScreen()
    {
        Console.WriteLine("You couldn't afford anything from the next list. You lost. That happens");
    }
}