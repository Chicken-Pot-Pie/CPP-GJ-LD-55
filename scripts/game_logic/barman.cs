using System;

namespace hellBarman
{
    public class Barman
    {
        public Inventory BarInventory { get; private set; }

        public Barman()
        {
            BarInventory = new Inventory();
        }

        // Method to add ingredient to the bar inventory
        public void AddToInventory(Ingredients ingredient)
        {
            BarInventory.AddIngredient(ingredient);
        }

        // Method to display the bar inventory
        public void DisplayInventory()
        {
            BarInventory.DisplayInventory();
        }

        // Method to use an ingredient from the bar inventory
        public void UseIngredient(string ingredientName)
        {
            BarInventory.UseIngredient(ingredientName);
        }

        public double Serve(Need need, Recipe recipe)
        {
            // Check if there are no ingredients in the recipe
            if (recipe.IngredientsList.Count == 0)
            {
                throw new InvalidOperationException("No ingredients added to the recipe.");
            }

            // Compute the score based on the difference between recipe characteristics and need characteristics
            double score = need.GetScore(recipe);

            // Use the ingredients from the recipe
            foreach (Ingredients ingredient in recipe.IngredientsList)
            {
                UseIngredient(ingredient.Name);
            }

            return score;
        }
    }
}

