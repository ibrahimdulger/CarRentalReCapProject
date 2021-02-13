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
            //carManager.Update(new Car { Id = 3, BrandId = 2, ModelId = 1, ColorId = 1, DailyPrice = 150, Description = "Updated Car", ModelYear = 2020 });
            //carManager.Add(new Car { BrandId = 1, ModelId = 1, ColorId = 1, DailyPrice = 100, Description = "Silinecek", ModelYear = 2019 });
            //var carToDelete = carManager.GetById(1003);
            //carManager.Delete(carToDelete);

            Console.WriteLine("--------Tümünü Listele-----------");
            ListAll(carManager);
            Console.WriteLine();

            Console.WriteLine("--------Marka ID ile çağırma-----------");
            ListByBrandId(carManager);
            Console.WriteLine();


            Console.WriteLine("--------Renk ID ile çağırma-----------");
            ListByColorId(carManager);
            Console.WriteLine();

            Console.WriteLine("---------Araç Detayları--------------");
            CarDetails(carManager);
            Console.WriteLine();
        }

        private static void ListAll(CarManager carManager)
        {
            var getAllResult = carManager.GetAll();
            if (getAllResult.Success)
            {
                foreach (var car in getAllResult.Data)
                {
                    Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice.ToString("N2") + " TL");
                }
            }
            else
            {
                Console.WriteLine(getAllResult.Message);
            }
        }

        private static void ListByBrandId(CarManager carManager)
        {
            var getCarsByBrandIdResult = carManager.GetCarsByBrandId(1);
            if (getCarsByBrandIdResult.Success)
            {
                foreach (var car in getCarsByBrandIdResult.Data)
                {
                    Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice.ToString("N2") + " TL");
                }
            }
            else
            {
                Console.WriteLine(getCarsByBrandIdResult.Message);
            }
        }

        private static void ListByColorId(CarManager carManager)
        {
            var getCarsByColorIdResult = carManager.GetCarsByColorId(1);

            if (getCarsByColorIdResult.Success)
            {
                foreach (var car in getCarsByColorIdResult.Data)
                {
                    Console.WriteLine(car.ModelYear + " " + " Model" + " " + car.Description + " " + "Fiyatı: " + car.DailyPrice.ToString("N2") + " TL");
                }
            }
            else
            {
                Console.WriteLine(getCarsByColorIdResult.Message);
            }
        }

        private static void CarDetails(CarManager carManager)
        {
            var getCarDetailsResult = carManager.GetCarDetails();
            if (getCarDetailsResult.Success)
            {
                foreach (var car in getCarDetailsResult.Data)
                {
                    Console.WriteLine(car.BrandName + car.ModelName + car.ColorName + car.DailyPrice.ToString("N2"));
                }
            }
            else
            {
                Console.WriteLine(getCarDetailsResult.Message);

            }
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
