using RestaurantUI_Week6.Models;

public static class DummyData
{
    public static List<Restaurant> Restaurants = new List<Restaurant>
    {
        new Restaurant
        {
            Id = 1,
            Name = "Pasta Palace",
            Cuisine = "Italian",
            Location = "123 Main St",
            Reviews = new List<Review>
            {
                new Review { Id = 1, RestaurantId = 1, ReviewerName = "Alice", Rating = 5, Comment = "Amazing pasta!" },
                new Review { Id = 2, RestaurantId = 1, ReviewerName = "Bob", Rating = 4, Comment = "Great atmosphere." }
            }
        },
        new Restaurant
        {
            Id = 2,
            Name = "Sushi Central",
            Cuisine = "Japanese",
            Location = "456 Elm St",
            Reviews = new List<Review>
            {
                new Review { Id = 3, RestaurantId = 2, ReviewerName = "Charlie", Rating = 5, Comment = "Best sushi in town!" },
                new Review { Id = 4, RestaurantId = 2, ReviewerName = "Dave", Rating = 3, Comment = "Good but a bit pricey." }
            }
        }
    };
}