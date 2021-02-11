using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice + " TL");
            }
            Console.WriteLine("--------Marka ID ile çağırma-----------");
            foreach (var car in carManager.GetCarsByBrandId(100))
            {
                Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice + " TL");
            }
            Console.WriteLine("--------Renk ID ile çağırma-----------");
            foreach (var car in carManager.GetCarsByColorId(33))
            {
                Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice + " TL");
            }

            Console.WriteLine("-----------------------");

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + car.BrandModel + car.ColorName + car.DailyPrice);
            }

            //carManager.Update(new Car { Id = 3, BrandId = 200, ColorId = 44, DailyPrice = 150, Description = "Updated Car", ModelYear = 2020 });
            //carManager.Add(new Car { Id = 7, BrandId = 100, ColorId = 22, DailyPrice = 150, Description = "1.5 Benzinli Motor", ModelYear = 2019 });
        }
    }
}
