using System;
using System.Linq;
using System.Numerics;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static BigInteger GetFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(MessageConstants.NeagtiveNumbersNotAllowed, nameof(n));
            }

            if (n == 0 || n == 1)
            {
                return 1;
            }

            BigInteger result = 1;

            for (int i = 2; i <= n; i++)
                result *= i;

            return result;
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items == null || items.Length == 0)
                return MessageConstants.Empty;

            if (items.Length == 1)
                return items[0];

            return FormatHelper.FormatItems(items);
        }

        public static class FormatHelper
        {
            public static string FormatItems(string[] items)
            {
                if (items.Length == 2)
                    return FormatTwoItems(items[0], items[1]);

                return $"{string.Join(MessageConstants.Separator, items.Take(items.Length - 1))}{MessageConstants.And}{items.Last()}";
            }
            public static string FormatTwoItems(string item1, string item2)
            {
                return $"{item1}{MessageConstants.And}{item2}";
            }

        }
    }
}