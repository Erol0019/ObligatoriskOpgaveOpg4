using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;



namespace ObligatoriskOpgaveOpg4

{
    public class Cars
    {
        private int _id;
        private string _model;
        private int _price;
        private string _licensePlate;


        public Cars(int id, string model, int price, string licensePlate)
        {

            Id = id;
            Model = model;
            Price = price;
            LicensePlate = licensePlate;
        }

        public string LicensePlate { get; set; }

        public int Price { get; set; }

        public string Model { get; set; }

        public int Id { get; set; }

        public Cars()
        {

            /* public class Cars
    
             {
                 private int _id;
                 public string _model;
                 public int _price;
                 public string _licenseplate;
             }
             {
                 public int Id { get; set; }
                 public string Model { get; set; }
                 public int Price { get; set; }
                 public string LicensePlate { get; set; }
    
                 public Cars(int id, string model, int price, string licenseplate)
                 {
                     Id = id;
                     Model = model;
                     Price = price;
                     LicensePlate = licenseplate;
                 }
                 public Cars()
                 {
    
                 }
    
                 /*public override string ToString()
                 {
    
                     return $"Id: {Id} - Model: {Model} - Price: {Price} - LicensePlate: {LicensePlate}";
                 }*/
        }
    }
}
