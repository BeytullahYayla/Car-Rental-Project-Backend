using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserOperationClaim
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int OperationClaimID { get; set; }
    }
}
