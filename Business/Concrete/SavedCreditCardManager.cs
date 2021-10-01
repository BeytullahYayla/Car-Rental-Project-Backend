using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SavedCreditCardManager : ISavedCreditCardService
    {
        ISavedCreditCardDal _savedCreditCardDal;
        public SavedCreditCardManager(ISavedCreditCardDal savedCreditCardDal)
        {
            _savedCreditCardDal = savedCreditCardDal;

        }
        public IDataResult<SavedCreditCard> Add(SavedCreditCard addCreditCardDto)
        {
            _savedCreditCardDal.Add(addCreditCardDto);
            return new SuccessDataResult<SavedCreditCard>(addCreditCardDto, "Eklendi");
        }

        public IDataResult<SavedCreditCard> CheckTheCreditCard(SavedCreditCard paymentDto)
        {
            var getCardToCheck = _savedCreditCardDal.Get(p => p.UserID == paymentDto.UserID);

            if (getCardToCheck == null)
            {
                return new ErrorDataResult<SavedCreditCard>(getCardToCheck,"Kullanıcı Bulunamadı");
            }
            else
            {
                var cardNumberStatus = getCardToCheck.CardNumberHash.SequenceEqual(paymentDto.CardNumberHash);
                var expirationDateStatus = getCardToCheck.ExpirationDateHash.SequenceEqual(paymentDto.ExpirationDateHash);
                var CvvStatus = getCardToCheck.CvvHash.SequenceEqual(paymentDto.CvvHash);

                if (!cardNumberStatus || !expirationDateStatus || !CvvStatus)
                {
                    return new ErrorDataResult<SavedCreditCard>(getCardToCheck, "Bu kart sistemde kayıtlı değil");
                }
            }
            return new SuccessDataResult<SavedCreditCard>(getCardToCheck);
        }

        public IResult Delete(SavedCreditCard payment)
        {
            _savedCreditCardDal.Delete(payment);
            return new SuccessResult("Silindi");
        }

        public IDataResult<List<SavedCreditCard>> GetAll()
        {
            return new SuccessDataResult<List<SavedCreditCard>>(_savedCreditCardDal.GetAll());
        }

        public IDataResult<SavedCreditCard> GetById(int id)
        {
            return new SuccessDataResult<SavedCreditCard>(_savedCreditCardDal.Get(p => p.SavedCreditCardID == id));
        }

        public IDataResult<SavedCreditCard> GetByUser(int userId)
        {
            return new SuccessDataResult<SavedCreditCard>(_savedCreditCardDal.GetByUser(userId));
        }

        public IResult Update(SavedCreditCard payment)
        {
            _savedCreditCardDal.Update(payment);
            return new SuccessResult("Guncellendi");
        }
    }
}
