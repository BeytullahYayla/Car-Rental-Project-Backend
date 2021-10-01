using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface ISavedCreditCardService
    {
        IDataResult<List<SavedCreditCard>> GetAll();
        IDataResult<SavedCreditCard> GetById(int id);
        IDataResult<SavedCreditCard> Add(SavedCreditCard addCreditCardDto);
        IResult Update(SavedCreditCard payment);
        IResult Delete(SavedCreditCard payment);
        IDataResult<SavedCreditCard> CheckTheCreditCard(SavedCreditCard paymentDto);
        IDataResult<SavedCreditCard> GetByUser(int userId);
    }
}
