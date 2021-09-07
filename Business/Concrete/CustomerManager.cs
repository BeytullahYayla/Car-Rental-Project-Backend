using Business.Abstract;
using Business.BusinnessAspect.Autofac;
using Business.Constraints;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

    
        [ValidationAspect(typeof(CustomerValidator))]
        
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            IResult result = BusinnessRules.Run(CheckIfCustomerExists(customer));
            if (result!=null)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
            return result;
           
        }
        [SecuredOperation("customer.delete,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]

        public IResult Delete(Customer customer)
        {
            IResult result = BusinnessRules.Run(CheckIfCustomerExists(customer));
            if (result==null)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            return result;
                
            
          
            
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);

        }
        [CacheAspect]
        public IDataResult<Customer> GetByUserId(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserID == id), Messages.CustomerListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("customer.update,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        
        public IResult Update(Customer customer)
        {
            IResult result = BusinnessRules.Run(CheckIfCustomerExists(customer));
            if (result==null)
            {

                _customerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            }



            return result;
            
        }
        private IResult CheckIfCustomerExists(Customer customer)
        {
            var result = _customerDal.GetAll(p => p.UserID == customer.UserID).Count;
            if (result==0)
            {
                return new ErrorResult(Messages.CustomerNotExists);
            }
            return new SuccessResult();
        }
    }
}
