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
    public class EfSavedCreditCardDal:EfEntityRepositoryBase<SavedCreditCard,Context>,ISavedCreditCardDal
    {
        public SavedCreditCard GetByUser(int userId)
        {
            using (var context = new Context())
            {
                var result = from scc in context.SavedCreditCards
                             where scc.UserID == userId
                             select new SavedCreditCard
                             {
                                 SavedCreditCardID = scc.SavedCreditCardID,
                                 UserID = scc.UserID,
                                 CardNumberHash = scc.CardNumberHash,
                                 CvvHash = scc.CvvHash,
                                 ExpirationDateHash = scc.ExpirationDateHash
                             };


                                 
                return result.FirstOrDefault();
            }
        }
    }
}
