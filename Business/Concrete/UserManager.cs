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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User user)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
