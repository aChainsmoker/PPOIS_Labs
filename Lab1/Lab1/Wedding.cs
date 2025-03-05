using System.Text.Json.Serialization;

namespace Lab1;

public class Wedding
{
    private WeddingPhase _weddingPhase;
    private Groom _groom;
    private Fiancee _fiancee;
    private Ceremony _ceremony;
    private Banquet _banquet;
    private WeddingPlace _weddingPlace;
    private List<Guest> _guests;
    private int _sharedBudget;
    private bool isConcluded = false;

    public Groom Groom {get => _groom; set => _groom = value; }
    public Fiancee Fiancee { get => _fiancee; set => _fiancee = value; }
    public Ceremony Ceremony { get => _ceremony; set => _ceremony = value; }
    public Banquet Banquet { get => _banquet; set => _banquet = value; }
    public WeddingPlace WeddingPlace { get => _weddingPlace; set => _weddingPlace = value; }
    public List<Guest> Guests { get => _guests; set => _guests = value; }

    public string WeddingPhaseString { get; set; }
    
    [JsonIgnore]public WeddingPhase WeddingPhase{get => _weddingPhase; set => _weddingPhase = value; }

    public int SharedBudget
    {
        get => _sharedBudget;
        set => _sharedBudget = value;
    }

    public bool IsConcluded{get => isConcluded;
        set
        {
            if((_weddingPhase is SummarizeState summarizeState) || (_weddingPhase is LostGameState lostGameState))
                isConcluded = value;
        }
    }

    public Wedding(WeddingPhase weddingPhase)
    {
        _weddingPhase = weddingPhase;
        _guests = new List<Guest>();
        _banquet = new Banquet(_guests);
        
    }

    public Wedding() { }
    public void ChangeState()
    {
        _weddingPhase.GetToTheNextPhase(this);
    }
    
}