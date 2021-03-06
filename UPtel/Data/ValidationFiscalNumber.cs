﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPtel.Data
{
    /// <summary>
    /// Validation for the fiscal number
    /// </summary>
    public class ValidationFiscalNumber
    {
        /// <summary>
        /// Method for the validation of the fiscal number
        /// </summary>
        /// <param name="nif"></param>
        /// <returns>True if is valid</returns>
        public static bool ValidateFiscalNumber(string nif)
        {
            
            char firstChar = nif[0];
            if (firstChar.Equals('1')
                || firstChar.Equals('2')
                || firstChar.Equals('3')
                || firstChar.Equals('5')
                || firstChar.Equals('6')
                || firstChar.Equals('8')
                || firstChar.Equals('9'))
            {
                int checkDigit = (Convert.ToInt32(firstChar.ToString()) * 9);
                for (int i = 2; i <= 8; ++i)
                {
                    checkDigit += Convert.ToInt32(nif[i - 1].ToString()) * (10 - i);
                }

                checkDigit = 11 - (checkDigit % 11);
                if (checkDigit >= 10)
                {
                    checkDigit = 0;
                }

                if (checkDigit.ToString() != nif[8].ToString())
                {
                   return false;
                }
            }
            return true;
        }
    }
}
// (!ValidationFiscalNumber.ValidateFiscalNumber(infoUsers.Contribuinte))//chamada do método