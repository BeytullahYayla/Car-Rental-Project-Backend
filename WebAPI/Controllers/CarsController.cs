using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarsByBrand(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpGet("getbycolorid")]
        //public IActionResult GetByColorId(int id)
        //{
        //    var result = _carService.Get(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
        [HttpGet("getcardetailsbydto")]
        public IActionResult GetDetailsByDto()
        {
            var result = _carService.GetCarDetailsDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycolorid")]
        public IActionResult GetCarByColor(int id)
        {
            var result = _carService.GetCarsByColor(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarsbyfilter")]
        public IActionResult GetCarsByFilter(int brandId,int colorId)
        {
            var result = _carService.GetCarsByFilter(brandId, colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
                
        }
        [HttpGet("getcarsbybrandandcolorname")]
        public IActionResult GetCarsByBrandAndColorName(string brandName,string colorName) {

            var result = _carService.GetCarsByBrandAndColorName(brandName, colorName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarsbybrandname")]
        public IActionResult GetCarsByBrandName(string brandName)
        {

            var result = _carService.GetCarsByBrandName(brandName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarsbycolorname")]
        public IActionResult GetCarsByBrandAndColorName(string colorName)
        {

            var result = _carService.GetCarsByColorName(colorName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
