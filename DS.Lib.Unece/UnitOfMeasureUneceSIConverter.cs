using System;

namespace DS.Lib.Unece
{
    public class UnitOfMeasureUneceSIConverter
    {
        private readonly static Rec20Rev17e __rec20_rev17e = new Rec20Rev17e();

        /// <summary>
        /// Returns the SI-Unit-Symbol of the UNECEN-Code. 
        /// Throws <see cref="IndexOutOfRangeException"/>, if not found.
        /// </summary>
        /// <param name="uneceCode"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
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

        /// <summary>
        /// Tries to get the SI-Unit of the UNECE.
        /// No exception will be thrown.
        /// Returns true, if the UNECE-code can be converted. Otherwise false.
        /// </summary>
        /// <param name="uneceCode">The SI-Symbol to find.</param>
        /// <param name="siCode">Output: the converted SI-symbol.</param>
        /// <param name="fallbackUneceCode">The fallback-value, if the symbol is not found. If not provided, the <paramref name="uneceCode"/> will be used.</param>
        /// <returns></returns>
        public static bool TryUneceToSI(string uneceCode, out string siCode, string? fallbackSICode = null)
        {
            if (__rec20_rev17e.UneceToSIMap.TryGetValue(uneceCode, out siCode))
            {
                return true;
            }
            else
            {
                siCode = fallbackSICode ?? uneceCode;
                return false;
            }
        }

        /// <summary>
        /// Returns the UNECE-Unit of the SI-Symbol. 
        /// Throws <see cref="IndexOutOfRangeException"/>, if not found.
        /// </summary>
        /// <param name="siCode"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
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

        /// <summary>
        /// Tries to get the UNECE-Unit of the SI-symbol.
        /// No exception will be thrown.
        /// Returns true, if the SI-symbol can be converted. Otherwise false.
        /// </summary>
        /// <param name="siCode">The SI-Symbol to find.</param>
        /// <param name="uneceCode">Output: the found UNECE-Unit.</param>
        /// <param name="fallbackUneceCode">The fallback-value, if the symbol is not found. If not provided, the <paramref name="siCode"/> will be used.</param>
        /// <returns></returns>
        public static bool TrySIToUnece(string siCode, out string uneceCode, string? fallbackUneceCode = null)
        {
            if (__rec20_rev17e.SIToUneceMap.TryGetValue(siCode, out uneceCode))
            {
                return true;
            }
            else
            {
                uneceCode = fallbackUneceCode ?? siCode;
                return false;
            }
        }
    }
}