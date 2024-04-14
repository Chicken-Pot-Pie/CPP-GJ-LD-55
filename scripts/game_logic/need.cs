using System;
namespace hellBarman
{
    public class Need
    {
        public double Sweet { get; set; }
        public double Spicy { get; set; }
        public double Sour { get; set; }
        public double Salty { get; set; }

        public Need(double sweet, double spicy, double sour, double salty)
        {
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

        public double GetScore(Recipe recipe)
        {
            // Get the mean characteristics of the recipe
            double[] tabmean = recipe.GetCharacteristicsMean();
            // Compute the average difference between recipe and need characteristics
            double diffSweet = Math.Abs(tabmean[(int)Characteristic.Sweet] - Sweet);
            double diffSpicy = Math.Abs(tabmean[(int)Characteristic.Spicy] - Spicy);
            double diffSour = Math.Abs(tabmean[(int)Characteristic.Sour] - Sour);
            double diffSalty = Math.Abs(tabmean[(int)Characteristic.Salty] - Salty);

            // Compute the average difference
            double averageDifference = (diffSweet + diffSpicy + diffSour + diffSalty) / 4;

            return 1 - averageDifference;
        }

        public void Display()
        {
            Console.WriteLine($"Sweet: {Sweet}");
            Console.WriteLine($"Spicy: {Spicy}");
            Console.WriteLine($"Sour: {Sour}");
            Console.WriteLine($"Salty: {Salty}");
        }

    }
}