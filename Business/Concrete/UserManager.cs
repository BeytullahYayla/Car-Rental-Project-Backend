﻿using Business.Abstract;
using Business.BusinnessAspect.Autofac;
using Business.Constraints;
using Core.Aspects.Autofac.Caching;
using Core.Entities;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        
        [SecuredOperation("user.add,admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
        [SecuredOperation("user.getclaims,admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }


        [SecuredOperation("user.delete,admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UserCantDeledet);
            }
        }

        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UsersListed);
        }
        [CacheAspect]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(user => user.UserID == id), Messages.UserListed);
        }

        [CacheAspect]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        [SecuredOperation("user.update,admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            try
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.UserCantUpdated);
            }
        }
    }
}
