using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObligatoriskOpgaveOpg4;


namespace ObligatoriskOpgaveOpg4
{
	public class CarsManager
	{
    //Keeps track of ids, in order for all items to have a unique ID
    private static int _nextId = 1;
    //Creates the list of Items and fills it with 3 items to begin with
    //The 3 items is only for testing purposes
    private static readonly List<Cars> Data = new List<Cars>
    {
        new Cars() {Id = _nextId++, Price = 3000, Model = "Opel", LicensePlate = "AA12345"},
        new Cars {Id = _nextId++, Price = 4000, Model = "Mercedes", LicensePlate = "BB12345"},
        new Cars{Id = _nextId++, Price = 5000, Model = "Volkswagen", LicensePlate = "CC12345"}
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
    };

    public List<Cars> GetAll(string modelFilter, int? priceFilter, string? licensePlateFilter)
    {
        List<Cars> result = new List<Cars>(data);
        if (!string.IsNullOrWhiteSpace(modelFilter))
        {
            result = result.FindAll(filterCars =>
                filterCars.Model.Contains(modelFilter, StringComparison.OrdinalIgnoreCase));
        }

        if (priceFilter != null)
        {
            result = result.FindAll(filterCars =>
                filterCars.Price <= priceFilter);
        }

        if (!string.IsNullOrWhiteSpace(licensePlateFilter))
        {
            result = result.FindAll(filterCars =>
                filterCars.LicensePlate.Contains(licensePlateFilter, StringComparison.OrdinalIgnoreCase));
        }

        return result;
    }

    public Cars GetById(int id)
    {
        return data.Find(cars => cars.Id == id);
    }

    public Cars AddCars(Cars newCars)
    {
        newCars.Id = nextId;
        data.Add(newCars);
        return newCars;
    }

    public Cars Delete(int id)
    {
        Cars cars = data.Find(cars => cars.Id == id);
        if (cars == null) return null;
        data.Remove(cars);
        return cars;
    }
}
