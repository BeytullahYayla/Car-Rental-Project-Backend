using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Payment:IEntity
    {
        public int PaymentID { get; set; }
        public int UserID { get; set; }
        public int CardID { get; set; }
        public string Date { get; set; }
    }
}
