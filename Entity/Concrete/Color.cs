using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Color :IEntity
    {
        [Key]
        public int ColorID { get; set; }
        public string ColorName { get; set; }
    }
}
