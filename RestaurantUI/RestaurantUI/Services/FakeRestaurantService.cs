using System.Collections.Generic;
using System.Linq;
namespace RestaurantUI.Services;
using RestaurantUI.Models;

public class FakeRestaurantService
{
    private List<Restaurant> restaurants = new List<Restaurant>
    {
        new Restaurant { Id = 1, Name = "Pizza Palace", Cuisine = "Italian", Location = "NYC" },
        new Restaurant { Id = 2, Name = "Sushi World", Cuisine = "Japanese", Location = "LA" },
        new Restaurant { Id = 3, Name = "Taco Fiesta", Cuisine = "Mexican", Location = "Austin" },
        new Restaurant { Id = 4, Name = "Burger Barn", Cuisine = "American", Location = "Chicago" },
        new Restaurant { Id = 5, Name = "Golden Dragon", Cuisine = "Chinese", Location = "San Francisco" },
        new Restaurant { Id = 6, Name = "Le Petit Bistro", Cuisine = "French", Location = "New Orleans" },
        new Restaurant { Id = 7, Name = "Spice Garden", Cuisine = "Indian", Location = "Houston" },
        new Restaurant { Id = 8, Name = "Olive & Vine", Cuisine = "Mediterranean", Location = "Miami" },
        new Restaurant { Id = 9, Name = "Seoul Kitchen", Cuisine = "Korean", Location = "Seattle" },
        new Restaurant { Id = 10, Name = "The Smoking Pit", Cuisine = "BBQ", Location = "Nashville" }
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