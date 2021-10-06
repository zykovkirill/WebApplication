using System;

namespace WebShared.Models
{
   public  interface IVerificatable
    {
        public string Number { get; set; }

        public DateTime VerificationDate { get; set; }
    }
}
