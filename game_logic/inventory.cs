public class Inventory
{
    private List<Ingredients> ingredientsList;

    public Inventory()
    {
        ingredientsList = new List<Ingredients>();
    }

    public void AddIngredient(Ingredients ingredient)
    {
        ingredientsList.Add(ingredient);
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Inventory:");
        foreach (Ingredients ingredient in ingredientsList)
        {
            ingredient.Display();
        }
    }

    public void UseIngredient(string ingredientName)
    {
        // Find the ingredient in the inventory
        Ingredients ingredientToRemove = ingredientsList.Find(i => i.Name == ingredientName);

        // If ingredient is found, remove it from the list
        if (ingredientToRemove != null)
        {
            ingredientsList.Remove(ingredientToRemove);
            Console.WriteLine($"{ingredientName} used and removed from inventory.");
        }
        else
        {
            Console.WriteLine($"Ingredient {ingredientName} not found in inventory.");
        }
    }

}