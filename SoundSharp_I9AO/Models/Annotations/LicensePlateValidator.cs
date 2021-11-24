using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoundSharp_I9AO.Models.Annotations
{
    public class BirthdateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime birthdate = (DateTime)value;
            if(birthdate > DateTime.Now)
            {
                ErrorMessage = "Birthdate cannot be in the future";
                return false;
            }
            return true;
        }
    }
    public class LicensePlateValidator : ValidationAttribute
    {
        
        public override bool IsValid(object value)
        {

            bool isValid = false;
            // Source: https://regex101.com/library/pFehol
            Regex regEx1 = new Regex(@"/(\w{2}-\d{2}-\d{2})|(\d{2}-\d{2}-\w{2})|(\d{2}-\w{2}-\d{2})|(\w{2}-\d{2}-\w{2})|(\w{2}-\w{2}-\d{2})|(\d{2}-\w{2}-\w{2})|(\d{2}-\w{3}-\d{1})|(\d{1}-\w{3}-\d{2})|(\w{2}-\d{3}-\w{1})|(\w{1}-\d{3}-\w{2})|(\w{3}-\d{2}-\w{1})|(\d{1}-\w{2}-\d{3})/gm");
            ErrorMessage = "Invalid format for license plate";
            // Source: https://www.rdw.nl/particulier/voertuigen/auto/de-kentekenplaat/cijfers-en-letters-op-de-kentekenplaat
            isValid = regEx1.IsMatch(value.ToString());
            if (value.ToString().ToUpper().Contains("A") ||
                value.ToString().ToUpper().Contains("E") ||
                value.ToString().ToUpper().Contains("Q") ||
                value.ToString().ToUpper().Contains("C") ||
                value.ToString().ToUpper().Contains("I") ||
                value.ToString().ToUpper().Contains("O") ||
                value.ToString().ToUpper().Contains("U") ||
                value.ToString().ToUpper().Contains("SS") ||
                value.ToString().ToUpper().Contains("GVD") ||
                value.ToString().ToUpper().Contains("KKK") ||
                value.ToString().ToUpper().Contains("LPF") ||
                value.ToString().ToUpper().Contains("KVT") ||
                value.ToString().ToUpper().Contains("NSB") ||
                value.ToString().ToUpper().Contains("PKK") ||
                value.ToString().ToUpper().Contains("SD") ||
                value.ToString().ToUpper().Contains("PVV") ||
                value.ToString().ToUpper().Contains("VVD") ||
                value.ToString().ToUpper().Contains("SGP")) 
            {
                isValid = false;
                ErrorMessage = "Illegal characters in license plate";
            }
            return isValid;
        }

    }
}
