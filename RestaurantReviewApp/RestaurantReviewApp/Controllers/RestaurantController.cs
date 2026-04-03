using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestaurantReviewApp.Models;

namespace RestaurantReviewApp.Controllers;

public class RestaurantController : Controller
{
    private static List<Restaurant> _restaurants = new List<Restaurant>();
    private static int _nextId = 1;

    //Read list of restaurants
    public IActionResult Index()
    {
        return View(_restaurants);
    }

    //Read details of a restaurant
    public IActionResult Details(int id)
    {
        var restaurant = _restaurants.FirstOrDefault(r => r.Id == id);
        if (restaurant == null)
        {
            return NotFound();
        }
        return View(restaurant);
    }

    //Create (GET)
    public IActionResult Create()
    {
        return View();
    }

    // CREATE (POST)
    [HttpPost]
    public IActionResult Create(Restaurant restaurant)
    {
        restaurant.Id = _nextId++;
        _restaurants.Add(restaurant);

        return RedirectToAction("Index");
    }

    //Update (GET)
    public IActionResult Edit(int id)
    {
        var restaurant = _restaurants.FirstOrDefault(r => r.Id == id);
        if (restaurant == null) return NotFound();

        return View(restaurant);
    }

    // UPDATE (POST)
    [HttpPost]
    public IActionResult Edit(Restaurant updatedRestaurant)
    {
        var restaurant = _restaurants.FirstOrDefault(r => r.Id == updatedRestaurant.Id);
        if (restaurant == null) return NotFound();

        restaurant.Name = updatedRestaurant.Name;
        restaurant.Location = updatedRestaurant.Location;
        restaurant.Cuisine = updatedRestaurant.Cuisine;
        restaurant.Rating = updatedRestaurant.Rating;

        return RedirectToAction("Index");
    }

    // Delete (GET)
    public IActionResult Delete(int id)
    {
        var restaurant = _restaurants.FirstOrDefault(r => r.Id == id);
        if (restaurant == null) return NotFound();

        return View(restaurant);
    }

    // Delete (POST)
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var restaurant = _restaurants.FirstOrDefault(r => r.Id == id);
        if (restaurant != null)
        {
            _restaurants.Remove(restaurant);
        }

        return RedirectToAction("Index");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel 
        { 
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
        });
    }

}