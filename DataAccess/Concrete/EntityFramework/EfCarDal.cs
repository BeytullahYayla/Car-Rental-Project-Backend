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
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorID equals co.Id
                             join br in context.Brands
                             on ca.BrandID equals br.Id


                             select new CarDetailDto
                             {
                                 CarID = ca.Id,
                                 BrandID = ca.BrandID,
                                 ColorID = ca.ColorID,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description,
                                 ModelYear = ca.ModelYear,
                                 CarImages = (from i in context.CarImages where (ca.Id == i.CarID) select i.ImagePath).FirstOrDefault()
                             };
                return filter == null
             ? result.ToList()
             : result.Where(filter).ToList();
            };




              


            }
        }
    }

