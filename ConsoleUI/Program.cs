using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice + " TL");
            }
            Console.WriteLine("------------");

            var car1 = carManager.GetById(2);
            Console.WriteLine("Id: " + car1.Id + " " + car1.ModelYear + " " + " Model" + " " + car1.Description + " " + "Fiyatı: " + car1.DailyPrice + " TL");
        }
    }
}
