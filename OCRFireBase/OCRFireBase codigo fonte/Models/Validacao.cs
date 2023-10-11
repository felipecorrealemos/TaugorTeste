using System.Text.RegularExpressions;

namespace OCRFireBase.Models
{
    public class Validacao
    {
        public static string ValidaCamposDigitados(string digitacao)
        {
            digitacao = Regex.Replace(digitacao, @"[^\w\d]", "");
            return digitacao;
        }

        public static bool ValidaPasta(string pastaTemp)
        {
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OCRFireBase");
            appDataPath = Path.Combine(appDataPath,pastaTemp);

            if (!Directory.Exists(appDataPath))
            {
                
                Directory.CreateDirectory(appDataPath);
                return true;
            }

            return false;
        }

        public static bool VerificaSeArquivoDisponivel(string caminho)
        {
            try
            {
                using (FileStream stream = File.Open(caminho, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return false;
            }

            return true;
        }

    }
}
