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

        indexOfPlace = TakeTheCorrectNumericIndex(weddingMap.WeddingPlaces) - 1;
    }
    public static void ChooseWeddingDressForFiancee(SuitStore suitStore, out int indexOfFianceeDress)
    {
        Console.WriteLine("Choose fiancee wedding dress");
        DisplayWeddingDresses(suitStore.WomenSuits);
        indexOfFianceeDress = TakeTheCorrectNumericIndex(suitStore.WomenSuits) - 1;
    }
    
    public static void ChooseWeddingDressForGroom(SuitStore suitStore, out int indexOfGroomDress)
    {
        Console.WriteLine("Choose groom wedding dress");
        DisplayWeddingDresses(suitStore.MenSuits);
        indexOfGroomDress = TakeTheCorrectNumericIndex(suitStore.MenSuits) - 1;
    }
    
    public static void ChooseWeddingRing(RingStore ringStore, out int indexOfRing)
    {
        Console.WriteLine("Choose wedding rings");
        DisplayWeddingRings(ringStore.Rings);
        indexOfRing = TakeTheCorrectNumericIndex(ringStore.Rings) - 1;
        
    }

    public static void ChooseWeddingMenu(WeddingMenu weddingMenu, out int[] indexesOfWeddingMenu)
    {
        indexesOfWeddingMenu = new int[Banquet.AmountOfDishes];
        Console.WriteLine("Choose wedding menu");
        DisplayWeddingDishes(weddingMenu.Dishes);
        for(int i = 0; i< Banquet.AmountOfDishes; i++)
            indexesOfWeddingMenu[i] = TakeTheCorrectNumericIndex(weddingMenu.Dishes) - 1;
    }

    public static void InviteGuests(out string[] names)
    {
        Console.WriteLine("Enter amount of guests");
        int amountOfGuests = 0;

        amountOfGuests = TakeTheNumericInput();
        
        while (amountOfGuests < 0)
        {
            Console.WriteLine("Enter correct amount of guests");
            amountOfGuests = TakeTheNumericInput();
        }
        
        
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
        Console.WriteLine("\nPress enter to continue...");
    }
    
    public static void DeclareBanquet()
    {
        Console.WriteLine("Banquet was held");
        Console.WriteLine("\nPress enter to continue...");
    }
    
    public static void DeclarePhotoSession()
    {
        Console.WriteLine("Photo session was held");
        Console.WriteLine("\nPress enter to continue...");
    }

    public static void DisplaySummarazation(int amountOfPoints)
    {
        Console.WriteLine($"Your final result: {amountOfPoints}");
        Console.WriteLine($"\nRecord: {JsonStateManager.LoadState<string>("WeddingRecord.json")}");
        Console.WriteLine("\nPress enter to continue...");
    }

    private static void DisplayWeddingDishes(List<Dish> weddingDishes)
    {
        for (int i = 0; i < weddingDishes.Count; i++)
        {
            Console.WriteLine($"====={i+1}=====");
            Console.WriteLine($"Name: {weddingDishes[i].Name}");
            Console.WriteLine($"Price: {weddingDishes[i].Price}");
            Console.WriteLine();
        }
    }

    private static void DisplayWeddingDresses(List<Suit> weddingDresses)
    {
        for (int i = 0; i < weddingDresses.Count; i++)
        {
            Console.WriteLine($"====={i+1}=====");
            Console.WriteLine($"Brand: {weddingDresses[i].Brand}");
            Console.WriteLine($"Price: {weddingDresses[i].Price}");
            Console.WriteLine($"Prestige: {GetPrestigeString(weddingDresses[i].Prestige)}");
            Console.WriteLine();
        }
    }

    private static void DisplayWeddingRings(List<Ring> weddingRings)
    {
        for (int i = 0; i < weddingRings.Count; i++)
        {
            Console.WriteLine($"====={i+1}=====");
            Console.WriteLine($"Brand: {weddingRings[i].Brand}");
            Console.WriteLine($"Price: {weddingRings[i].Price}");
            Console.WriteLine($"Prestige: {GetPrestigeString(weddingRings[i].Prestige)}");
            Console.WriteLine();
        }
    }

    private static void DisplayWeddingPlaces(List<WeddingPlace> weddingPlaces)
    {
        for (int i = 0; i < weddingPlaces.Count; i++)
        {
            Console.WriteLine($"====={i+1}=====");
            Console.WriteLine($"Location: {weddingPlaces[i].Location}");
            Console.WriteLine($"Date: {weddingPlaces[i].Date.ToString("dd.MM.yyyy HH:mm")}");
            Console.WriteLine($"Guest Capacity: {weddingPlaces[i].GuestCapacity}");
            Console.WriteLine($"Price: {weddingPlaces[i].Price}");
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

    private static int TakeTheNumericInput()
    {
        while (true)
        {
            int numericInput;
            try
            {
                numericInput = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter numeric input!\n");
                continue;
            }
            return numericInput;
        }
    }

    private static bool CheckIfTheIndexInTheArrayBounds<T>(int index, List<T> array)
    {
        if(index > array.Count || index < 0)
            return false;
        return true;
    }

    private static int TakeTheCorrectNumericIndex<T>(List<T> array)
    {
        while (true)
        {
            int numericInput = TakeTheNumericInput();
            if (CheckIfTheIndexInTheArrayBounds(numericInput, array))
                return numericInput;
            else
                Console.WriteLine("Enter correct index of item\n");
        }
    }

    public static void Clear()
    {
        if(!Console.IsOutputRedirected) Console.Clear();
    }
}