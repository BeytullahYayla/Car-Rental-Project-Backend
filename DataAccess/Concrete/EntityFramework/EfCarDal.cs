using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (Context context = new Context())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorID equals co.ColorID
                             join br in context.Brands
                             on ca.BrandID equals br.BrandID
                             select new CarDetailDto
                             {
                                 CarID = ca.CarID,
                                 
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice=ca.DailyPrice,
                                 Description=ca.Description,
                                 ModelYear=ca.ModelYear
                                 
                             
                             };
                return result.ToList();
            }
        }
    }
}
