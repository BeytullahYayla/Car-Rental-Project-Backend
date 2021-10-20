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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        
       // [SecuredOperation("admin,color.add")]
        public IResult Add(Color color)
        {
            IResult result = BusinnessRules.Run(CheckIfColorExists(color));
            if (result!=null)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
            return result;
        }

       
      //[SecuredOperation("admin,color.delete")]
        public IResult Delete(Color color)
        {

            IResult result = BusinnessRules.Run(CheckIfColorExists(color));
            if (result!=null)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }

            return result;
            
        }
       

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            //return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorsListed);
            if (result.Count < 0)
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorNotExists);
            }
            return new SuccessDataResult<List<Color>>(result, Messages.ColorListed);
        }
        [CacheAspect]

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(color => color.ColorID == id),Messages.ColorListed);
        }

        //[SecuredOperation("admin,car.update")]
        public IResult Update(Color color)
        {

            IResult result = BusinnessRules.Run(CheckIfColorExists(color));
            if (result==null)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            return result;
                
            
            

                
            
        }
        private IResult CheckIfColorExists(Color color)
        {
            var result = _colorDal.GetAll(p=>p.ColorID==color.ColorID).Count;
            if (result==0)
            {
                return new ErrorResult(Messages.ColorNotExists);
            }
            return new SuccessResult();
        }
    }
}
