using System;

namespace Repository.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string msj) : base(msj) { }
        
    }
}
