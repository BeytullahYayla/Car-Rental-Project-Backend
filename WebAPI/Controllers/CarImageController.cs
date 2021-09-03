using Business.Abstract;
using Core.Utilities.Helpers;
using Entity.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        IFileHelper _fileHelper;
        ICarImageService _carImageService;
        

        public CarImagesController(IFileHelper fileHelper, ICarImageService carImageService)
        {
            _fileHelper = fileHelper;
            _carImageService = carImageService;
        }
        [HttpPost("upload")]

        public IActionResult Upload([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {

            carImage.CarID = 2;
            var result = _carImageService.Add(file, carImage);

            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int id)
        {
            var carImage = _carImageService.GetById(id).Data;
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] int id)
        {
            var carImage = _carImageService.GetById(id).Data;
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallimages")]
        public IActionResult GetAllImages()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}