using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class FromBankCreditCard:IEntity
    {
        public int FromBankCreditCardID { get; set; }
        public int UserID { get; set; }
        public byte[] CardNumberSalt { get; set; }
        public byte[] CardNumberHash { get; set; }
        public byte[] ExpirationDateSalt { get; set; }
        public byte[] ExpirationDateHash { get; set; }
        public byte[] CvvSalt { get; set; }
        public byte[] CvvHash { get; set; }

    }
}
