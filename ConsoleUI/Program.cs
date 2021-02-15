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


            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var response = rentalManager.Add(new Rental { CarId = 2, CustomerId = 2, RentDate = new DateTime(2021, 02, 16), ReturnDate = new DateTime(2021, 02, 25) });

            Console.WriteLine(response.Message);
        }

        static void InitializeDb()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ModelManager modelManager = new ModelManager(new EfModelDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            userManager.Add(new User { FirstName = "İbrahim", LastName = "Dülger", Email = "iamdulger@gmail.com", Password = "123456" });
            userManager.Add(new User { FirstName = "Kerim", LastName = "Abdul Jabbar", Email = "kerimov@gmail.com", Password = "123456" });
            userManager.Add(new User { FirstName = "Muhammed Ali", LastName = "Clay", Email = "maclay@gmail.com", Password = "123456" });
            userManager.Add(new User { FirstName = "Mahmut", LastName = "Öztürk", Email = "ozturk05@gmail.com", Password = "123456" });
            userManager.Add(new User { FirstName = "Ahmet", LastName = "Yılmaz", Email = "ayilmaz@gmail.com", Password = "123456" });
            userManager.Add(new User { FirstName = "Burcu", LastName = "Kaya", Email = "bkaya@gmail.com", Password = "123456" });

            customerManager.Add(new Customer { UserId = 1, CompanyName = "Dülger Holding" });
            customerManager.Add(new Customer { UserId = 2, CompanyName = "Kerimsport" });
            customerManager.Add(new Customer { UserId = 3, CompanyName = "Ali Boxing" });
            customerManager.Add(new Customer { UserId = 4, CompanyName = "Öztürk Yapı" });
            customerManager.Add(new Customer { UserId = 5, CompanyName = "Ahmet Holding" });
            customerManager.Add(new Customer { UserId = 6, CompanyName = "Fly Labs" });

            rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 02, 10), ReturnDate = new DateTime(2021, 02, 15) });
            rentalManager.Add(new Rental { CarId = 2, CustomerId = 2, RentDate = new DateTime(2021, 02, 10), ReturnDate = new DateTime(2021, 02, 15) });
            rentalManager.Add(new Rental { CarId = 3, CustomerId = 3, RentDate = new DateTime(2021, 02, 10), ReturnDate = new DateTime(2021, 02, 15) });
            rentalManager.Add(new Rental { CarId = 4, CustomerId = 4, RentDate = new DateTime(2021, 02, 10), ReturnDate = new DateTime(2021, 02, 15) });

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
