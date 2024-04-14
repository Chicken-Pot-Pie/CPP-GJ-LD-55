using System;
using System.Collections.Generic;

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
    public double GetCharacteristicsMean()
    {
        // Check if there are no ingredients
        if (IngredientsList.Count == 0)
        {
            throw new InvalidOperationException("No ingredients added to the recipe.");
        }

        // Initialize variables to store sum of attributes
        double totalSweet = 0;
        double totalSpicy = 0;
        double totalSour = 0;
        double totalSalty = 0;

        // Sum up attributes of all ingredients
        foreach (var ingredient in IngredientsList)
        {
            totalSweet += ingredient.Sweet;
            totalSpicy += ingredient.Spicy;
            totalSour += ingredient.Sour;
            totalSalty += ingredient.Salty;
        }

        // Compute mean of each attribute
        double meanSweet = totalSweet / IngredientsList.Count;
        double meanSpicy = totalSpicy / IngredientsList.Count;
        double meanSour = totalSour / IngredientsList.Count;
        double meanSalty = totalSalty / IngredientsList.Count;

        // Return mean characteristics
        return (meanSweet, meanSpicy, meanSour, meanSalty);
    }
}