using Business.Abstract;
using Business.CCS;
using Business.Constraints;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Businness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ILogger _logger;
        IBrandService _brandService;
        public CarManager(ICarDal carDal, ILogger logger, IBrandService brandService)
        {
            _carDal = carDal;
            _logger = logger;
            _brandService = brandService;
        }



        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        

        public IResult Add(Car car)
        {

            //A brand can include just 10 car

            IResult result = BusinnessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandID), CheckIfBrandLimitExceeded());
            if (result != null)
            {
                return result;

            }


            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);







        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            IResult result = BusinnessRules.Run(CheckIfCarExists(car));
            if (result == null)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }



            return result;




        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        } 
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.BrandID == id), Messages.CarListedByBrand);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.BrandID == id), Messages.CarListedByColor);
        }
        [CacheRemoveAspect("ICarService.Get")]

        public IResult Update(Car car)
        {
            IResult result = BusinnessRules.Run(CheckIfCarExists(car));
            if (result == null)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }




            return result;

        }
        [CacheAspect]

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(car => car.CarID == id), Messages.CarListed);

        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsDto()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListedDetailDto);
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandID)
        {
            var result = _carDal.GetAll(p => p.BrandID == brandID).Count;//We find count of cars
            if (result > 10)
            {
                return new ErrorResult(Messages.BrandCountOfError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfBrandLimitExceeded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.BrandLimitExceeded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarExists(Car car)
        {
            var result = _carDal.GetAll(p => p.CarID == car.CarID).Count;
            if (result != 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice>800)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }
    }
}
