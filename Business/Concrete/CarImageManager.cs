using Business.Abstract;
using Business.BusinnessAspect.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Businness;
using Core.Utilities.Helpers;

using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService

    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        ICarService _carService;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper, ICarService carService)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
            _carService = carService;
        }
        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(ImageConstants.ImageDeleted);
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), ImageConstants.ImageGettedAll);
        }
        [CacheAspect]

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageID == imageId), ImageConstants.ImageGettedById);
        }
        [CacheRemoveAspect("ICarImageService.Get")]
        [SecuredOperation("carimage.update,admin")]
        public IResult Update(IFormFile carImages, CarImage carImage)
        {
            var result = BusinnessRules.Run(ChechkImageLimit(carImage.CarID));
            if (result.Success)
            {
                carImage.ImagePath = _fileHelper.Update(carImages, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
                _carImageDal.Update(carImage);
                return new SuccessResult(ImageConstants.ImageUpdated);
            }
            return new ErrorResult();

        }
        [CacheRemoveAspect("ICarImageService.Get")]
        [SecuredOperation("carimage.add,admin")]


        public IResult Add(IFormFile carImages, CarImage carImage)
        {

            carImage.ImagePath = _fileHelper.Upload(carImages, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult("Resim başarı ile yüklendi");
        }


        private IResult ChechkImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarID == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(ImageConstants.ImageLimitExceeded);
            }
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = BusinnessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);

            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarID == carId), ImageConstants.ImageGettedByCarId);

        }
        [CacheAspect]
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarID = carId, Date = DateTime.Now, ImagePath = PathConstants.ImagesPath + "DefaultImage.png" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarID == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();

            }
            return new ErrorResult();
        }
    }
}