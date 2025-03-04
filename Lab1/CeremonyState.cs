namespace Lab1;

public class CeremonyState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new PhotoSessionState();
        wedding.Ceremony.DeclareHusbandAndWife(wedding.Husband, wedding.Wife);
        IOSystem.DeclareMarriage(wedding.Husband, wedding.Wife);
        Console.ReadKey();
        Console.Clear();
    }
}