using System;
using System.Collections.Generic;
namespace hellBarman
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredients> IngredientsList { get; set; }

        public Recipe(string name)
        {
            Name = name;
            IngredientsList = new List<Ingredients>();
        }

        // Method to add ingredient to the recipe
        public void AddIngredient(Ingredients ingredient)
        {
            // Check if an ingredient with the same category already exists
            foreach (Ingredients existingIngredient in IngredientsList)
            {
                if (existingIngredient.Category == ingredient.Category)
                {
                    throw new InvalidOperationException($"An ingredient with category '{ingredient.Category}' already exists in the recipe.");
                }
            }

            // If no ingredient with the same category exists, add the ingredient to the list
            IngredientsList.Add(ingredient);
        }

        // Method to compute the mean of sweetness, saltiness, etc...
        public double[] GetCharacteristicsMean()
        {
            // Check if there are no ingredients
            if (IngredientsList.Count == 0)
            {
                throw new InvalidOperationException("No ingredients added to the recipe.");
            }

            double[] tabtotal = new double[4];
            // Initialize variables to store sum of attributes
            foreach (var Char in Enum.GetValues(typeof(Characteristic)))
            {
                tabtotal[(int)Char] = 0;
            }
            // Sum up attributes of all ingredients
            foreach (var ingredient in IngredientsList)
            {
                tabtotal[(int)Characteristic.Sweet] += ingredient.Sweet;
                tabtotal[(int)Characteristic.Spicy] += ingredient.Spicy;
                tabtotal[(int)Characteristic.Sour] += ingredient.Sour;
                tabtotal[(int)Characteristic.Salty] += ingredient.Salty;
            }

            // Compute mean of each attribute
            double[] tabmean = new double[4];
            foreach (var Char in Enum.GetValues(typeof(Characteristic)))
            {
                tabmean[(int)Char] = tabtotal[(int)Char] / IngredientsList.Count;
            }
            // Return mean characteristics
            return tabmean;
        }
    }
}