namespace DesignPatterns;

public class Pizza
{
    public string Name { get; init; } = "";
}

public static class PizzaBuilder
{
    public static Pizza Build(bool tomatoes, bool chicken, bool cheese, bool salami)
    {
        var ingredients = new List<string>();

        if (tomatoes) ingredients.Add("tomatoes");
        if (chicken)  ingredients.Add("chicken");
        if (cheese)   ingredients.Add("cheese");
        if (salami)   ingredients.Add("salami");

        string name = ingredients.Count == 0
            ? "You made a Margherita pizza!"
            : $"You made a pizza with {string.Join(", ", ingredients)}!";

        return new Pizza { Name = name };
    }
}