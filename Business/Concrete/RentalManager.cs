using Business.Abstract;
using Business.Constraints;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Businness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
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

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(rental => rental.CustomerID == id), Messages.RentalListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
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
    }
}
