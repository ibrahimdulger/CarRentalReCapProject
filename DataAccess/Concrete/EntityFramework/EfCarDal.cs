using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.DTOs;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from a in context.Cars
                             join c in context.Colors on a.ColorId equals c.ColorId
                             join b in context.Brands on a.BrandId equals b.BrandId
                             select new CarDetailsDto
                             {
                                 Id = a.Id,
                                 BrandModel = b.BrandModel,
                                 BrandName =b.BrandName,
                                 ColorName=c.ColorName,
                                 DailyPrice = a.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
