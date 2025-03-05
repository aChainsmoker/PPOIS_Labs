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

       try { indexOfPlace = Convert.ToInt32(Console.ReadLine()) - 1; } catch {throw new System.FormatException("Invalid input"); }
    }
    public static void ChooseWeddingDressForFiancee(SuitStore suitStore, out int indexOfFianceeDress)
    {
        Console.WriteLine("Choose fiancee wedding dress");
        DisplayWeddingDresses(suitStore.WomenSuits);
        try { indexOfFianceeDress = Convert.ToInt32(Console.ReadLine()) - 1; } catch {throw new System.FormatException("Invalid input"); }
    }
    
    public static void ChooseWeddingDressForGroom(SuitStore suitStore, out int indexOfGroomDress)
    {
        Console.WriteLine("Choose groom wedding dress");
        DisplayWeddingDresses(suitStore.MenSuits);
        try { indexOfGroomDress = Convert.ToInt32(Console.ReadLine()) - 1;} catch {throw new System.FormatException("Invalid input"); }
    }
    
    public static void ChooseWeddingRing(RingStore ringStore, out int indexOfRing)
    {
        Console.WriteLine("Choose wedding rings");
        DisplayWeddingRings(ringStore.Rings);
        try { indexOfRing = Convert.ToInt32(Console.ReadLine()) - 1;} catch {throw new System.FormatException("Invalid input"); }
        
    }

    public static void ChooseWeddingMenu(WeddingMenu weddingMenu, out int[] indexesOfWeddingMenu)
    {
        indexesOfWeddingMenu = new int[Banquet.AmountOfDishes];
        Console.WriteLine("Choose wedding menu");
        DisplayWeddingDishes(weddingMenu.Dishes);
        for(int i = 0; i< Banquet.AmountOfDishes; i++)
            try { indexesOfWeddingMenu[i] = Convert.ToInt32(Console.ReadLine()) - 1;} catch {throw new System.FormatException("Invalid input"); }
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
    
    public static void DeclareMarriage(Groom groom, Fiancee fiancee)
    {
        Console.WriteLine($"{groom.Name} and {fiancee.Name} got married!");
    }
    
    public static void DeclareBanquet()
    {
        Console.WriteLine("Banquet was held");
    }
    
    public static void DeclarePhotoSession()
    {
        Console.WriteLine("Photo session was held");
    }

    public static void DisplaySummarazation(int amountOfPoints)
    {
        Console.WriteLine($"Your final result: {amountOfPoints}");
        Console.WriteLine($"\nRecord: {JsonStateManager.LoadState<string>("WeddingRecord.json")}");
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
            Console.WriteLine(GetPrestigeString(weddingDresses[i].Prestige));
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
            Console.WriteLine(GetPrestigeString(weddingRings[i].Prestige));
            Console.WriteLine();
        }
    }

    private static void DisplayWeddingPlaces(List<WeddingPlace> weddingPlaces)
    {
        for (int i = 0; i < weddingPlaces.Count; i++)
        {
            Console.WriteLine($"====={i+1}=====");
            Console.WriteLine(weddingPlaces[i].Location);
            Console.WriteLine(weddingPlaces[i].Date.ToString("dd.MM.yyyy HH:mm"));
            Console.WriteLine(weddingPlaces[i].GuestCapacity);
            Console.WriteLine(weddingPlaces[i].Price);
            Console.WriteLine();
        }
    }
    
    public static string GetPrestigeString(AttributePrestige attributePrestige)
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

    public static AttributePrestige GetPrestigeFromString(string attributePrestigeString)
    {
        AttributePrestige attributePrestige;
        attributePrestige = attributePrestigeString switch
        {
            "Cheap" => AttributePrestige.Cheap,
            "Normal" => AttributePrestige.Normal,
            "Premium" => AttributePrestige.Premium,
        };
        return attributePrestige;
    }

    public static void PrintBudget(int budget)
    {
        Console.WriteLine($"Current balance: {budget}\n");
    }
    

    public static void PrintLoserScreen()
    {
        Console.WriteLine("You couldn't afford anything from the next list. You lost. That happens");
    }
    
    public static string GetTheWeddingStateString(WeddingPhase weddingPhase)
    {
        string weddingPhaseString = weddingPhase switch
        {
            CreatingNewlywedState => "CreatingNewlywedState",
            ChoosingGroomDressState => "ChoosingGroomDressState",
            ChoosingFianceeDressState => "ChoosingFianceeDressState",
            ChoosingRingState => "ChoosingRingState",
            BanquetState => "BanquetState",
            CeremonyState => "CeremonyState",
            ChoosingWeddingMenuState => "ChoosingWeddingMenuState",
            ChoosingWeddingPlaceState => "ChoosingWeddingPlaceState",
            GuestInvitationState => "GuestInvitationState",
            PhotoSessionState => "PhotoSessionState",
            SummarizeState => "SummarizeState",
        };
        return weddingPhaseString;
    }

    public static WeddingPhase GetTheWeddingPhaseFromString(string weddingPhaseString)
    {
        WeddingPhase weddingPhase = weddingPhaseString switch
        {
            "CreatingNewlywedState" => new CreatingNewlywedState(),
            "ChoosingGroomDressState" => new ChoosingGroomDressState(),
            "ChoosingFianceeDressState" => new ChoosingFianceeDressState(),
            "ChoosingRingState" => new ChoosingRingState(),
            "BanquetState" => new BanquetState(),
            "CeremonyState" => new CeremonyState(),
            "ChoosingWeddingMenuState" => new ChoosingWeddingMenuState(),
            "ChoosingWeddingPlaceState" => new ChoosingWeddingPlaceState(),
            "GuestInvitationState" => new GuestInvitationState(),
            "PhotoSessionState" => new PhotoSessionState(),
            "SummarizeState" => new SummarizeState(),
        };
        return weddingPhase;
    }
}