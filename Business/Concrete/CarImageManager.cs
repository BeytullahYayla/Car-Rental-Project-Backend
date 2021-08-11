using Business.Abstract;
using Business.Constants;
using Business.Constraints;
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
            var result = BusinnessRules.Run(CheckIfCarImageExists(carImage));
            if (result!=null)
            {
                _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
                _carImageDal.Delete(carImage);
                return new SuccessResult(ImageConstants.ImageDeleted);
            }
            return result;
        }
            

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), ImageConstants.ImageGettedAll);
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            var result = BusinnessRules.Run(ShowDefaultImage(imageId));
            if (result==null)
            {
                return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageID == imageId), ImageConstants.ImageGettedById);
            }
            return new ErrorDataResult<CarImage>("Hata");
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var imageDelete = _carImageDal.Get(c => c.CarImageID == carImage.CarImageID);
            if (imageDelete == null)
            {
                return new ErrorResult("Resim Bulunamadı");
            }
            var updatedFile = _fileHelper.Update(file, imageDelete.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);

            return new SuccessResult(ImageConstants.ImageUpdated);



        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinnessRules.Run(CheckIfCarImageExists(carImage));
            if (result!=null)
            {
                var imageResult = _fileHelper.Upload(file);
                if (!imageResult.Success)
                {
                    return new ErrorResult(imageResult.Message);
                }
                carImage.ImagePath = imageResult.Message;
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(ImageConstants.ImageAdded);
            }
            return result;
            
        }
        
        private IResult CheckIfCarImageExists(CarImage carImage)
        {
            var result = _carImageDal.GetAll(p => p.CarImageID == carImage.CarImageID).Count;
            if (result != 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(ImageConstants.ImageNotExists);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarID == carId),ImageConstants.ImageGettedByCarId);
        }
        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarID == carId).Count;
            if (result<=5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(ImageConstants.ImageLimitExceeded);
        }
        private IResult ShowDefaultImage(int carId)
        {
            try
            {
                string path = @"\images\default.png";
                var result = _carImageDal.GetAll(c => c.CarID == carId).Any();
                if (result)
                {
                    List<CarImage> carImages = new List<CarImage>();
                    carImages.Add(new CarImage { CarID = carId, Date = DateTime.Now, ImagePath = path });
                    return new SuccessDataResult<List<CarImage>>(carImages);
                }
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<CarImage>>("Hata");
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c =>c.CarID == carId).ToList());

        }
    }
}
