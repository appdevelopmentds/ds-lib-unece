using System;

namespace DS.Lib.Unece
{
    public class UneceSIConverter
    {
        private readonly static Rec20Rev17e rec20Rev17E = new Rec20Rev17e();

        public static string UneceToSI(string uneceCode)
        {
            if (rec20Rev17E.UneceToSIMap.TryGetValue(uneceCode, out string siCode))
            {
                return siCode;
            }
            else
            {
                throw new IndexOutOfRangeException($"UNECE-Code '{uneceCode}' not found.");
            }
        }
    }
}