using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace RecipesApp.ValidationRules
{
    public class MainValidationRule : ValidationRule
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string Message { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string objectValue = value as string;

            int valueValue = 0;
            if (int.TryParse(objectValue, out valueValue)){
                if ((valueValue <= MinValue) || (valueValue > MaxValue)){
                    return new ValidationResult(false, Message + " " + MinValue + " do " + MaxValue + ".");
                }
                else {
                    return new ValidationResult(true, null);
                }
            }
            else {
                return new ValidationResult(false, "Podaj liczbę całkowitą!");
            }
        }
    }
}
