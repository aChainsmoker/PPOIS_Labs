namespace Lab1;

public class WeddingAttribute
{
    protected uint _price;
    protected AttributePrestige _attributePrestige;
    protected string _brand;
    
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