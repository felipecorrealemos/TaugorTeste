using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRFireBase.Models
{
    public class Log
    {
        public static void CriarArquivoLog(string caminho, string textoAAdicionar)
        {
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                writer.Write(textoAAdicionar + $" {DateTime.Now.ToString("HH:mm:ss")}" + "\r\n");
            }
        }

        public static void AdicionarLog(string arquivoLog, string textoAAdicionar)
        {
            using (StreamWriter writer = new StreamWriter(arquivoLog, true))
            {
                writer.Write(textoAAdicionar + $" {DateTime.Now.ToString("HH:mm:ss")}" + "\r\n");
            }

        }
    }
}
