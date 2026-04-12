using System.Collections.Generic;
using System.Linq;

public class FakeRestaurantService
{
    private List<Restaurant> restaurants = new List<Restaurant>
    {
        new Restaurant { Id = 1, Name = "Pizza Palace", Cuisine = "Italian", Location = "NYC" },
        new Restaurant { Id = 2, Name = "Sushi World", Cuisine = "Japanese", Location = "LA" }
    };

    public List<Restaurant> GetAll() => restaurants;

    public Restaurant GetById(int id) =>
        restaurants.FirstOrDefault(r => r.Id == id);

    public void Add(Restaurant restaurant)
    {
        restaurant.Id = restaurants.Max(r => r.Id) + 1;
        restaurants.Add(restaurant);
    }

    public void Update(Restaurant updated)
    {
        var r = GetById(updated.Id);
        if (r != null)
        {
            r.Name = updated.Name;
            r.Cuisine = updated.Cuisine;
            r.Location = updated.Location;
        }
    }

    public void Delete(int id)
    {
        var r = GetById(id);
        if (r != null)
            restaurants.Remove(r);
    }

    public void AddReview(int restaurantId, Review review)
    {
        var r = GetById(restaurantId);
        if (r != null)
            r.Reviews.Add(review);
    }
}