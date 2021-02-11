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
            //InitializeDb();

            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("--------Tümünü Listele-----------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice + " TL");
            }
            Console.WriteLine();

            Console.WriteLine("--------Marka ID ile çağırma-----------");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice + " TL");
            }
            Console.WriteLine();


            Console.WriteLine("--------Renk ID ile çağırma-----------");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice + " TL");
            }
            Console.WriteLine();


            Console.WriteLine("---------Araç Detayları--------------");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + car.ModelName + car.ColorName + car.DailyPrice);
            }
            Console.WriteLine();


            //carManager.Update(new Car { Id = 3, BrandId = 200, ColorId = 44, DailyPrice = 150, Description = "Updated Car", ModelYear = 2020 });
            //carManager.Add(new Car { Id = 7, BrandId = 100, ColorId = 22, DailyPrice = 150, Description = "1.5 Benzinli Motor", ModelYear = 2019 });
        }

        static void InitializeDb()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ModelManager modelManager = new ModelManager(new EfModelDal());




            brandManager.Add(new Brand { BrandName = "Ford" }); // 1
            brandManager.Add(new Brand { BrandName = "Fiat" }); // 2
            brandManager.Add(new Brand { BrandName = "Mercedes" }); // 3


            modelManager.Add(new Model { BrandId = 1, Name = "Focus" });
            modelManager.Add(new Model { BrandId = 1, Name = "Fiesta" });
            modelManager.Add(new Model { BrandId = 1, Name = "Mondeo" });

            modelManager.Add(new Model { BrandId = 2, Name = "Egea" });
            modelManager.Add(new Model { BrandId = 2, Name = "Linea" });
            modelManager.Add(new Model { BrandId = 2, Name = "Fiorino" });

            modelManager.Add(new Model { BrandId = 3, Name = "E250" });
            modelManager.Add(new Model { BrandId = 3, Name = "A180" });
            modelManager.Add(new Model { BrandId = 3, Name = "G500" });


            colorManager.Add(new Color { ColorName = "Siyah" }); // 1
            colorManager.Add(new Color { ColorName = "Beyaz" }); // 2
            colorManager.Add(new Color { ColorName = "Kırmızı" }); // 3
            colorManager.Add(new Color { ColorName = "Mavi" }); // 4


            carManager.Add(new Car { BrandId = 1, ModelId = 1, ColorId = 1, DailyPrice = 100, Description = "Sedan", ModelYear = 2019 });
            carManager.Add(new Car { BrandId = 1, ModelId = 2, ColorId = 2, DailyPrice = 120, Description = "Hatcback", ModelYear = 2020 });
            carManager.Add(new Car { BrandId = 1, ModelId = 3, ColorId = 3, DailyPrice = 150, Description = "Sedan", ModelYear = 2020 });
            carManager.Add(new Car { BrandId = 2, ModelId = 4, ColorId = 2, DailyPrice = 120, Description = "Sedan", ModelYear = 2019 });
            carManager.Add(new Car { BrandId = 2, ModelId = 5, ColorId = 3, DailyPrice = 100, Description = "Sedan", ModelYear = 2019 });
            carManager.Add(new Car { BrandId = 2, ModelId = 6, ColorId = 1, DailyPrice = 80, Description = "Panelvan", ModelYear = 2019 });
            carManager.Add(new Car { BrandId = 3, ModelId = 7, ColorId = 4, DailyPrice = 300, Description = "Premium Sedan", ModelYear = 2020 });
            carManager.Add(new Car { BrandId = 3, ModelId = 8, ColorId = 2, DailyPrice = 200, Description = "Hatchback", ModelYear = 2020 });
            carManager.Add(new Car { BrandId = 3, ModelId = 9, ColorId = 1, DailyPrice = 500, Description = "Premium 4x4", ModelYear = 2020 });

        }
    }
}
