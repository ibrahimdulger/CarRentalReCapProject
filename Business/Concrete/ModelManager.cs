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
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IResult Add(Model model)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else if (model.Name.Length < 2)
            {
                return new ErrorResult(Messages.ModelNameInvalid);

            }
            _modelDal.Add(model);
            return new SuccessResult(Messages.ModelAdded);
        }

        public IResult Delete(Model model)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _modelDal.Delete(model);
            return new SuccessResult();
        }

        public IDataResult<List<Model>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Model>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }

        public IResult Update(Model model)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else if (model.Name.Length < 2)
            {
                return new ErrorResult(Messages.ModelNameInvalid);

            }
            _modelDal.Update(model);
            return new SuccessResult(Messages.ModelUpdated);
        }
    }
}
