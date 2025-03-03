namespace Lab1;

public class Wedding
{
    private WeddingPhase _weddingPhase;
    private bool isConcluded = false;
    
    public WeddingPhase WeddingPhase{get => _weddingPhase; set => _weddingPhase = value; }
    public bool IsConcluded{get => isConcluded;
        set
        {
            if(_weddingPhase is SummarizeState summarizeState)
                isConcluded = value;
        }
    }

    public Wedding(WeddingPhase weddingPhase)
    {
        _weddingPhase = weddingPhase;
    }
    
    public void ChangeState()
    {
        _weddingPhase.GetToTheNextPhase(this);
    }
    
}