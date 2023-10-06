using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OCRFireBase.Models
{
    public class ValidaCampos
    {
        public static string ValidaCamposDigitados(string digitacao)
        {
            digitacao = Regex.Replace(digitacao, @"[^\w\d]", "");
            return digitacao;
        }
    }
}
