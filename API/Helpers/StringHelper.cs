using System;

namespace API.Helpers
{
    public static class StringHelper
    {
        private static readonly Random random = new Random();
        // create an ID for an animal
        // the format of the ID is [xxxxx]
        public static string GenerateAnimalId()
        {
            char[] digits = new char[5];

            for (int i = 0; i < 5; i++)
            {
                digits[i] = (char)(random.Next(10) + '0');
            }

            return new string(digits);
        }
    }
}
