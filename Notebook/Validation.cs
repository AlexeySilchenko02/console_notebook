using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Validation
    {
        public bool Required { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public char[] ValidSymbols { get; set; }

        public Validation(bool required, int minLength, int maxLength, char[] validSymbols)
        {
            this.Required = required;
            this.MinLength = minLength;
            this.MaxLength = maxLength;
            this.ValidSymbols = validSymbols;
        }
        public bool TryValidate(string input, out string output)
        {
            output = null;
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                if (Required)
                {
                    output = "Это поле является обязательным!";
                    return false;
                }
                else
                {
                    output = null;
                    return true;
                }
            }
            if (input.Length < MinLength)
            {
                output = $"Минимальная длина: {MinLength}!";
                return false;
            }

            if (input.Length > MaxLength)
            {
                output = $"Максимальная длина: {MaxLength}!";
                return false;
            }

            input = input.ToLower();
            foreach (var item in input)
            {

                if (!ValidSymbols.Contains(item))
                {
                    output = $"Используйте только: {new string(ValidSymbols)}!";
                    return false;
                }
            }


            return true;
        }
    }
}
