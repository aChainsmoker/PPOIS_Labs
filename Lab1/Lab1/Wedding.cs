using System.Text.Json.Serialization;

namespace Lab1;

public class Wedding
{
    private WeddingPhase _currentCurrentWeddingPhase;
    private Groom _groom;
    private Fiancee _fiancee;
    private Ceremony _ceremony;
    private Banquet _banquet;
    private WeddingPlace _weddingPlace;
    private List<Guest> _guests;
    private int _sharedBudget;
    private bool _isConcluded = false;

    public Groom Groom {get => _groom; set => _groom = value; }
    public Fiancee Fiancee { get => _fiancee; set => _fiancee = value; }
    public Ceremony Ceremony { get => _ceremony; set => _ceremony = value; }
    public Banquet Banquet { get => _banquet; set => _banquet = value; }
    public WeddingPlace WeddingPlace { get => _weddingPlace; set => _weddingPlace = value; }
    public List<Guest> Guests { get => _guests; set => _guests = value; }

    public string CurrentWeddingPhaseString { get; set; }
    
    [JsonIgnore]public WeddingPhase CurrentWeddingPhase{get => _currentCurrentWeddingPhase; set => _currentCurrentWeddingPhase = value; }

    public int SharedBudget
    {
        get => _sharedBudget;
        set => _sharedBudget = value;
    }

    public bool IsConcluded{get => _isConcluded;
        set
        {
            if((_currentCurrentWeddingPhase is SummarizeState summarizeState))
                _isConcluded = value;
        }
    }

    public Wedding(WeddingPhase currentCurrentWeddingPhase)
    {
        _currentCurrentWeddingPhase = currentCurrentWeddingPhase;
        _guests = new List<Guest>();
        _banquet = new Banquet(_guests);
        _ceremony = new Ceremony();
        
    }

    public Wedding() { }

    public void ChangeState()
    {
        _currentCurrentWeddingPhase.GetToTheNextPhase(this);
    }
}