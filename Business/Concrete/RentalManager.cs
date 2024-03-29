﻿using Business.Abstract;
using Business.BusinnessAspect.Autofac;
using Business.Constraints;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Businness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;


        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("admin")]
        public IResult Add(Rental rental)
        {
            
            IResult result = BusinnessRules.Run(CheckIfRentalExists(rental),IsThatCarDeliveried(rental.RentalID));
            if (result != null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            return result;




        }
        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("admin")]

        public IResult Delete(Rental rental)
        {
            IResult result = BusinnessRules.Run(CheckIfRentalExists(rental));
            if (result == null)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            return result;






        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        [CacheAspect]
        public IDataResult<Rental> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(rental => rental.CustomerID == id), Messages.RentalListed);
        }
        
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("admin")]
        public IResult Update(Rental rental)
        {

            IResult result = BusinnessRules.Run(CheckIfRentalExists(rental));
            if (result == null)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);

            }



            return result;

        }
        private IResult IsThatCarDeliveried(int id)
        {
            var result = _rentalDal.Get(r => r.CarID == id && r.ReturnDate == null); 
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarDeliveryError);
        }
       
        private IResult CheckIfRentalExists(Rental rental)
        {
            var result = _rentalDal.GetAll(p => p.RentalID == rental.RentalID).Count;
            if (result == 0)
            {
                return new ErrorResult(Messages.RentalNotExists);
            }
            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailsDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetailsDto(),"Kiralamalar Basari Ile Getirildi");
        }

        public IDataResult<List<Rental>> GetRentalByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.CarID == carId));
        }

        public IResult Rentalable(Rental rental)
        {
            IResult result = BusinnessRules.Run(DateCheck(rental));
            if (result != null)
            {
                return result;
            }
            return new SuccessResult("Başarılı");
        }
        private IResult DateCheck(Rental entity)
        {
            var rentalalbe = this.GetAll();
            foreach (var rental in rentalalbe.Data)
            {
                if (rental.CarID == entity.CarID)
                {
                    if (entity.RentDate >= rental.RentDate && entity.RentDate <= rental.ReturnDate)
                    {
                        return new ErrorResult("Geçersiz Tarih");
                    }
                    else if (entity.ReturnDate >= rental.RentDate && entity.ReturnDate <= rental.ReturnDate)
                    {
                        return new ErrorResult("Geçersiz Tarih");
                    }
                }
                else
                {
                    return new ErrorResult("CarID de sıkıntı var");
                }
                
            }
            return new SuccessResult();
        }
    }
}
