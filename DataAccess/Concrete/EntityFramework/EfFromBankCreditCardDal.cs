using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFromBankCreditCardDal:EfEntityRepositoryBase<FromBankCreditCard,Context>,IFromBankCreditCardDal
    {
        public FromBankCreditCard GetByUser(int userID)
        {
            using (Context context=new Context())
            {
                var result = from c in context.FromBankCreditCards
                             where c.UserID == userID
                             select new FromBankCreditCard
                             {
                                 UserID = c.UserID,
                                 CardNumberHash = c.CardNumberHash,
                                 CardNumberSalt = c.CardNumberSalt,
                                 ExpirationDateHash = c.ExpirationDateHash,
                                 ExpirationDateSalt = c.ExpirationDateSalt,
                                 CvvHash = c.CvvHash,
                                 CvvSalt = c.CvvSalt
                             };
                return result.FirstOrDefault();

            }

        }
    }
}
