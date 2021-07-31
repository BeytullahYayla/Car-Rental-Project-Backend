using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Car:IEntity
    {
        [Key]
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public int ColorID { get; set; }
        public string ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
