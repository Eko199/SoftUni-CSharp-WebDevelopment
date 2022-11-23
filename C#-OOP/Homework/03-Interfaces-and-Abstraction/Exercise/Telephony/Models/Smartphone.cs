namespace Telephony.Models
{
    using System;
    using System.Linq;

    using Interfaces;

    public class Smartphone : StationaryPhone, ISmartphone
    {
        public new string Call(string phoneNumber)
        {
            ValidatePhoneNumber(phoneNumber);

            return "Calling... " + phoneNumber;
        }

        public string Browse(string url)
        {
            ValidateURL(url);

            return $"Browsing: {url}!";
        }

        private void ValidateURL(string url)
        {
            if (url.Any(char.IsDigit))
                throw new ArgumentException("Invalid URL!");
        }
    }
}
