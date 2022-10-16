using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, Context>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetailsDto(Expression<Func<RentalDetailsDto, bool>> filter = null)
        {
            using (Context context=new Context())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarID equals ca.Id
                             join br in context.Brands
                             on ca.BrandID equals br.Id
                             join cu in context.Customers
                             on re.CustomerID equals cu.Id
                             join us in context.Users
                             on cu.UserID equals us.UserID
                             select new RentalDetailsDto
                             {
                                 RentalID = re.Id,
                                 BrandName = br.BrandName,
                                 CustomerFullName = us.FirstName + " " + us.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate


                             };
                return filter == null
            ? result.ToList()
            : result.Where(filter).ToList();
               
            
            }
        }
    }
}
