using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class SavedCreditCard:IEntity
    {
        public int SavedCreditCardID { get; set; }
        public int UserID { get; set; }
        public byte[] CardNumberHash { get; set; }
        public byte[] ExpirationDateHash { get; set; }
        public byte[] CvvHash { get; set; }
    }
}
