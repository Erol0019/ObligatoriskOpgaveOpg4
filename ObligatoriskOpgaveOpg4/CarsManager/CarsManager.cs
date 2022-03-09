using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObligatoriskOpgaveOpg4;




namespace ObligatoriskOpgaveOpg4.Controllers.Managers
{
    public class CarsManager
    {

        private static int _nextId = 1;

        private static readonly List<Cars> data = new List<Cars>
        {
            new Cars {Id = _nextId++, Price = 3000, Model = "Opel", LicensePlate = "AA12345"},
            new Cars {Id = _nextId++, Price = 4000, Model = "Mercedes", LicensePlate = "BB12345"},
            new Cars {Id = _nextId++, Price = 5000, Model = "Volkswagen", LicensePlate = "CC12345"}
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        };

        public List<Cars> GetAll(string modelFilter, int? priceFilter, string? licenseplateFilter)
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

            if (!string.IsNullOrWhiteSpace(licenseplateFilter))
            {
                result = result.FindAll(filterCars =>
                    filterCars.LicensePlate.Contains(licenseplateFilter, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        public Cars GetById(int id)
        {
            return data.Find(cars => cars.Id == id);
        }

        public Cars AddCars(Cars newCars)
        {
            newCars.Id = _nextId;
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

}