namespace Lab1;

public class WeddingAttribute
{
    protected uint _price;
    protected AttributePrestige _attributePrestige;
    protected string _brand;
    
    public uint Price { get => _price; set => _price = value; }
    public string Brand { get => _brand; set => _brand = value; }
    public AttributePrestige Prestige { get => _attributePrestige; set => _attributePrestige = value; }
    
    public WeddingAttribute(uint price, string brand)
    {
        _price = price;
        _brand = brand;

        _attributePrestige = _price switch
        {
            < 100 => AttributePrestige.Cheap,
            >= 100 and < 1000 => AttributePrestige.Normal,
            >= 1000 => AttributePrestige.Premium
        };
    }
}

public enum AttributePrestige
{
    Cheap,
    Normal,
    Premium
}