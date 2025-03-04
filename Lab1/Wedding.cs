namespace Lab1;

public class Wedding
{
    private WeddingPhase _weddingPhase;
    private Husband _husband;
    private Wife _wife;
    private Ceremony _ceremony;
    private Banquet _banquet;
    private WeddingPlace _weddingPlace;
    private List<Guest> _guests;
    private int _sharedBudget;
    private bool isConcluded = false;

    public Husband Husband {get => _husband; set => _husband = value; }
    public Wife Wife { get => _wife; set => _wife = value; }
    public Ceremony Ceremony { get => _ceremony; set => _ceremony = value; }
    public Banquet Banquet { get => _banquet; set => _banquet = value; }
    public WeddingPlace WeddingPlace { get => _weddingPlace; set => _weddingPlace = value; }
    public List<Guest> Guests { get => _guests; set => _guests = value; }
    
    public WeddingPhase WeddingPhase{get => _weddingPhase; set => _weddingPhase = value; }

    public int SharedBudget
    {
        get => _sharedBudget;
        set
        {
            if(_sharedBudget<0)
                IOSystem.NotifyAboutBudgetLimit();
            else
                _sharedBudget = value;
        }
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
        
    }
    
    public void ChangeState()
    {
        _weddingPhase.GetToTheNextPhase(this);
        _banquet = new Banquet(_guests);
    }
    
}