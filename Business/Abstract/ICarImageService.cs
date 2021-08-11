using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int imageId);
        IResult Add(IFormFile carImages, CarImage carImage);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile carImages, CarImage carImage);
    }
}
