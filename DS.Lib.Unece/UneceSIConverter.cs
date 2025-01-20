using System;

namespace DS.Lib.Unece
{
    public class UneceSIConverter
    {
        private readonly static Rec20Rev17e __rec20_rev17e = new Rec20Rev17e();

        public static string UneceToSI(string uneceCode)
        {
            if (__rec20_rev17e.UneceToSIMap.TryGetValue(uneceCode, out string siCode))
            {
                return siCode;
            }
            else
            {
                throw new IndexOutOfRangeException($"UNECE-Code '{uneceCode}' not found.");
            }
        }

        public static string SIToUnece(string siCode)
        {
            if (__rec20_rev17e.SIToUneceMap.TryGetValue(siCode, out string uneceCodeCode))
            {
                return uneceCodeCode;
            }
            else
            {
                throw new IndexOutOfRangeException($"SI-Code '{siCode}' not found.");
            }
        }

    }
}