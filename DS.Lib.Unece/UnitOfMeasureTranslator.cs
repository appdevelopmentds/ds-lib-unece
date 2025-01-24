using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Emit;
using System.Resources;
using System.Text;

namespace DS.Lib.Unece
{
    public static class UnitOfMeasureTranslator
    {
        private static readonly ResourceManager resourceManagerUNECESI = new ResourceManager("DS.Lib.Unece.ResRec20Rev17e-UNECESI", typeof(UnitOfMeasureTranslator).Assembly);
        private static readonly ResourceManager resourceManagerSIUNECE = new ResourceManager("DS.Lib.Unece.ResRec20Rev17e-SIUNECE", typeof(UnitOfMeasureTranslator).Assembly);
        private static readonly Dictionary<string, string> __SItoUNECEoverrides = new Dictionary<string, string>();
        private static readonly Dictionary<string, string> __UNECEtoSIoverrides = new Dictionary<string, string>();

        /// <summary>
        /// Returns the SI-Unit-Symbol of the UNECE-Code. 
        /// Throws <see cref="IndexOutOfRangeException"/>, if not found.
        /// </summary>
        /// <param name="uneceCode"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static string UNECEtoSI(string uneceCode)
        {
            if (TryUNECEtoSI(uneceCode, out string siCode))
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
        public static bool TryUNECEtoSI(string uneceCode, out string siCode, string? fallback = null)
        {
            if (__UNECEtoSIoverrides.TryGetValue(uneceCode, out string? overrideValue))
            {
                siCode = overrideValue;
                return true;
            }
            string? found = resourceManagerUNECESI.GetString(uneceCode);
            if (!String.IsNullOrEmpty(found))
            {
                siCode = found;
                return true;
            }
            else
            {
                siCode = fallback ?? uneceCode;
                return false;
            }
        }


        /// <summary>
        /// Returns the UNECE-Code of the SI-Unit-Symbol. 
        /// Throws <see cref="IndexOutOfRangeException"/>, if not found.
        /// </summary>
        /// <param name="siCode"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static string SItoUNECE(string siCode)
        {
            if (TrySItoUNECE(siCode, out string uneceCode))
            {
                return uneceCode;
            }
            else
            {
                throw new IndexOutOfRangeException($"UNECE-Code '{siCode}' not found.");
            }
        }

        /// <summary>
        /// Tries to get the UNECE-Unit of the SI-symbol.
        /// No exception will be thrown.
        /// Returns true, if the SI-symbol can be converted. Otherwise false.
        /// </summary>
        /// <param name="siCode">The SI-Symbol to find.</param>
        /// <param name="uneceCode">Output: the found UNECE-Unit.</param>
        /// <param name="fallback">The fallback-value, if the symbol is not found. If not provided, the <paramref name="siCode"/> will be used.</param>
        /// <returns></returns>
        public static bool TrySItoUNECE(string siCode, out string uneceCode, string? fallback = null)
        {
            if (__SItoUNECEoverrides.TryGetValue(siCode, out string? overrideValue))
            {
                uneceCode = overrideValue;
                return true;
            }

            string? found = resourceManagerSIUNECE.GetString(siCode);
            if (!String.IsNullOrEmpty(found))
            {
                uneceCode = found;
                return true;
            }
            else
            {
                uneceCode = fallback ?? siCode;
                return false;
            }
        }

        /// <summary>
        /// Overrides a translation between SI and UNECE.
        /// </summary>
        /// <param name="siCode">The SI-symbol to override.</param>
        /// <param name="uneceCode">The overridden result. To remove an override leave this parameter null.</param>
        public static void OverrideSItoUNECETranslation(string siCode, string? uneceCode = null)
        {
            if (uneceCode != null)
                __SItoUNECEoverrides[siCode] = uneceCode;
            else
                __SItoUNECEoverrides.Remove(siCode);
        }

        /// <summary>
        /// Overrides a translation between UNECE and SI.
        /// </summary>
        /// <param name="uneceCode">The UNECE-code to override.</param>
        /// <param name="siCode">The overridden result. To remove an override leave this parameter null.</param>
        public static void OverrideUNECEtoSITranslation(string uneceCode, string? siCode = null)
        {
            if (siCode != null)
                __UNECEtoSIoverrides[uneceCode] = siCode;
            else
                __UNECEtoSIoverrides.Remove(uneceCode);
        }

        /// <summary>
        /// Reset all overrides.
        /// </summary>
        public static void ResetOverrides()
        {
            __SItoUNECEoverrides.Clear();
            __UNECEtoSIoverrides.Clear();
        }
    }
}
