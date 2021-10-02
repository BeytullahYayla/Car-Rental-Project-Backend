using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IDataResult<Rental> GetByCustomerId(int id);

        IDataResult<List<RentalDetailsDto>> GetRentalDetails();
        IDataResult<List<Rental>> GetRentalByCarId(int carId);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IResult Rentalable(Rental rental);
    }
}
