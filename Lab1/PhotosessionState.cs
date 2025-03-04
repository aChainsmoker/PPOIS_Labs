﻿namespace Lab1;

public class PhotoSessionState : WeddingPhase
{
    public override void GetToTheNextPhase(Wedding wedding)
    {
        wedding.WeddingPhase = new BanquetState();
        IOSystem.DeclarePhotoSession();
        Console.ReadKey();
        Console.Clear();
    }
}