using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace StringExtension
{
    public static class Parser
    {
        public static int ToDecimal(this string source, int @base)
        {
            CheckData(source, @base);

            //Constatnts value from base
            string table = "0123456789ABCDEF";
            int rank = 1, result = 0;

            for (var i = source.Length - 1; i >= 0; i--)
            {
                var index = table.IndexOf(source[i].ToString().ToUpper());

                if (index < 0)
                    throw new ArgumentException("Invalid character");

                if ((result += rank * index) > int.MaxValue)
                    throw new ArgumentException();

                rank *= @base;
            }
            
            return result;
        }

        private static void CheckData(string source, int @base)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "String is null");
            }

            if (@base >= 17 || @base <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(@base), "Argument mast be range [2,16]");
            }

            if (source.Length > 31 && @base == 2)
            {
                throw new ArgumentException(nameof(source));
            }
            if (!source.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException(nameof(@base), nameof(source));
            }
            if ((source.Any(char.IsLetter) && @base < 9) )
            {
                throw new ArgumentException(nameof(@base), nameof(source));
            }

            if ((@base < 9 && source.Any(char.IsLetter)))
            {
                throw new ArgumentException(nameof(@base), nameof(source));
            }
            //if ((@base < 9 && source.All(char.IsDigit)))
            //{
            //    foreach (var temp in source)
            //    {
            //        if (int.Parse(temp.ToString()) < @base)
            //        {
            //            throw new ArgumentException();
            //        }
            //    }
            //}

        }
    }
}
