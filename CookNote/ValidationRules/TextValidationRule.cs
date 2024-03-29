﻿using System.Globalization;
using System.Windows.Controls;

namespace CookNote.ValidationRules
{
    class TextValidationRule : ValidationRule
    {
        public int MinSize { get; set; }
        public int MaxSize { get; set; }
        public string Message { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string objectValue = value as string;

            if (objectValue.Length < MinSize || objectValue.Length > MaxSize){
                return new ValidationResult(false, Message + " " + MinSize + " do " + MaxSize + ".");
            }
            else {
                return new ValidationResult(true, null);
            }
        }
    }
}
