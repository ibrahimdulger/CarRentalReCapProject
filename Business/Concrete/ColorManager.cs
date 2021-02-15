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
    public class ColorManager : IColorService
    {
        IColorDal _colordal;

        public ColorManager(IColorDal colordal)
        {
            _colordal = colordal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 3)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            else if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _colordal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _colordal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colordal.GetAll());
        }

        public IResult Update(Color color)
        {
            if (color.ColorName.Length < 3)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            else if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _colordal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
