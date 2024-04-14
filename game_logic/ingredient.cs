using System;

public enum Category
{
    Fruit,
    Liquid,
    IceCube
}

public class Ingredients
{

    public string Name { get; set; }
    public Category Category { get; set; }
    public double Sweet { get; set; }
    public double Spicy { get; set; }
    public double Sour { get; set; }
    public double Salty { get; set; }

    
    public Ingredients(string name, Category category, double sweet, double spicy, double sour, double salty)
    {
        Name = name;
        Category = category;

        // Ensure that the sum of attributes is equal to 1
        double sum = sweet + spicy + sour + salty;
        if (sum != 1)
        {
            throw new ArgumentException("Sum of sweet, spicy, sour, and salty should be equal to 1.");
        }

        Sweet = sweet;
        Spicy = spicy;
        Sour = sour;
        Salty = salty;
    }
}
