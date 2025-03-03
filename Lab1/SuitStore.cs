﻿namespace Lab1;

public class SuitStore
{
    private string[] _menBrands;
    private string[] _womenBrands;
    private List<Suit> _menSuits;
    private List<Suit> _womenSuits;

    public SuitStore()
    {
        _menSuits = new List<Suit>();
        _womenSuits = new List<Suit>();
        
        _menBrands = new string[]
            { "Lubiam", "Cesare Attolini", "L.B.M. 1911", "Fradi", "Eduard Dressler", "Adidas", "Nike" };
        _womenBrands = new string[]
            { "Vera Wang", "Oscar de la Renta", "Naeem Khan", "Carolina Herrera", "Monique Lhuillier", "Valentine Avoh", "Lela Rose" };

        for (int i = 0; i < _menBrands.Length; i++)
        {
            _menSuits.Add(new Suit((uint)(new Random().Next(1, 10000)), _menBrands[i]));
        }
        for (int i = 0; i < _womenBrands.Length; i++)
        {
            _womenSuits.Add(new Suit((uint)(new Random().Next(1, 10000)), _womenBrands[i]));
        }
    }
}