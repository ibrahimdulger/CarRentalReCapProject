using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var rentals = GetByCarId(rental.CarId).Data;
            foreach (var rented in rentals)
            {
                if (rented.ReturnDate > rental.RentDate || rental.ReturnDate <= rental.RentDate)
                {
                    return new ErrorResult(Messages.RentDateControl);
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(x => x.CarId == carId));
        }

        public IResult Update(Rental rental)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
