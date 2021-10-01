using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entity.DTOs
{
    public class PaymentDto : IDto
    {
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv
        {
            get; set;
        }
    }
}
