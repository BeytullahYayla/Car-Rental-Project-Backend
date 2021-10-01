using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
   public class CreditCardHashedDto:IDto
    {
        public int UserId { get; set; }
        public byte[] CardNumberHash { get; set; }
        public byte[] ExpirationDateHash { get; set; }
        public byte[] CvvHash { get; set; }
    }
}
