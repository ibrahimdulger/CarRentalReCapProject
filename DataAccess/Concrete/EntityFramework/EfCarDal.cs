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
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             join m in context.Models
                             on ca.ModelId equals m.Id
                             select new CarDetailsDto
                             {
                                 Id = ca.Id,
                                 BrandName = br.BrandName,
                                 ModelName = m.Name,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                             };
                return result.ToList();
            }
        }
    }
}
