using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 100, ColorId = 22, DailyPrice = 100, Description = "1.6 Benzinli Motor", ModelYear = 2019},
                new Car{Id = 2, BrandId = 100, ColorId = 33, DailyPrice = 120, Description = "1.5 Turbo Dizel", ModelYear = 2019},
                new Car{Id = 3, BrandId = 100, ColorId = 33, DailyPrice = 130, Description = "1.5 Turbo Dizel", ModelYear = 2019},
                new Car{Id = 4, BrandId = 200, ColorId = 11, DailyPrice = 140, Description = "1.6 Benzinli Motor", ModelYear = 2019},
                new Car{Id = 5, BrandId = 200, ColorId = 11, DailyPrice = 160, Description = "2.0 Benzinli Motor", ModelYear = 2019},
                new Car{Id = 6, BrandId = 300, ColorId = 22, DailyPrice = 190, Description = "6+1 Kişilik", ModelYear = 2019}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
