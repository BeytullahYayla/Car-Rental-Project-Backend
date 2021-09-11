using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        
        

       
        IDataResult<List<CarDetailDto>> GetCarDetailsDto();
        IDataResult<List<CarDetailDto>> GetCarsByBrand(int id);

        IDataResult<List<CarDetailDto>> GetCarsByColor(int id);
        IResult Add(Car car);
        IResult Delete(Car car);

        IResult Update(Car car);
        IResult AddTransactionalTest(Car car);

    }
}
