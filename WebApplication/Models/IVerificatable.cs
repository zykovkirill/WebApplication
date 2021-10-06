using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
   public  interface IVerificatable
    {
        public string Number { get; set; }

        public DateTime VerificationDate { get; set; }
    }
}
