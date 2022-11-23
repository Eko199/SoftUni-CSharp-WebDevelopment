namespace Telephony.Models
{
    using System;
    using System.Linq;

    using Interfaces;

    public class StationaryPhone : IPhone
    {
        public string Call(string phoneNumber)
        {
            ValidatePhoneNumber(phoneNumber);

            return "Dialing... " + phoneNumber;
        }

        protected void ValidatePhoneNumber(string phoneNumber)
        {
            if (!phoneNumber.All(char.IsDigit))
                throw new ArgumentException("Invalid number!");
        } 
    }
}
