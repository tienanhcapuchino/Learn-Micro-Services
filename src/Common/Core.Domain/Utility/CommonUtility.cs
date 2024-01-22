using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Utility
{
    public static class CommonUtility
    {
        public static long ConvertDateTimeToLong(DateTime dateTime)
        {
            return dateTime.Ticks;
        }
        public static  DateTime ConvertLongToDateTime(long value)
        {
            return new DateTime(value);
        }
        public static string GenerateRandomPassword()
        {
            Random random = new Random();
            StringBuilder password = new StringBuilder();

            // Generate at least 6 characters
            int length = random.Next(6, 11); // Random length between 6 and 10 characters

            // Generate random characters
            for (int i = 0; i < length; i++)
            {
                char randomChar = (char)random.Next('A', 'Z' + 1); // ASCII values for uppercase letters
                password.Append(randomChar);
            }

            // Ensure the password includes at least one number
            int randomNumber = random.Next(0, 10);
            password[random.Next(0, length)] = (char)('0' + randomNumber);

            return password.ToString();
        }
    }
}
