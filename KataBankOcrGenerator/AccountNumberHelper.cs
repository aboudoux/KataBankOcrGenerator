using System;
using KataBankOcrGenerator.Exceptions;

namespace KataBankOcrGenerator
{
    public static class AccountNumberHelper
    {
        public static int GetRandomValidAccountNumber()
        {
            var r = new Random(Guid.NewGuid().GetHashCode());
            while (true)
            {
                try
                {
                    var randomNumberWithoutKey = r.Next(1, 99999999);
                    return int.Parse(CreateNumberWithControlKey(randomNumberWithoutKey));
                }
                catch (IncorrectKeyComputation)
                {                    
                }
            }
        }

        public static string CreateNumberWithControlKey(int number)
        {
            string lowNumber = number.ToString("00000000");
            var checksum = 0;
            for (int i = 0, j = 9; i < 8; i++, j--)
                checksum += (int) char.GetNumericValue(lowNumber[i]) * j;
            var key = 11 - (checksum%11);            
            if (key == 11)
                key = 0;
            if (key == 10)
                throw new IncorrectKeyComputation();
            return lowNumber + key;
        }

        public static bool IsValid(int accountNumber)
        {
            string number = accountNumber.ToString("000000000");

            var checksum = 0;
            for (int i = 0, j = 9; i < 9; i++, j--)
                checksum += (int)char.GetNumericValue(number[i])*j;
            return checksum%11 == 0;
        }
    }
}