using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRFireBase.Models
{
    public class OCR
    {
        public static void ScanDocOCR(string idioma)
        {
            string diretorioAtual = Directory.GetCurrentDirectory();

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = Path.Combine(diretorioAtual, @"OCRConsole\OCRConsole.exe"),
                Arguments = $"\"{diretorioAtual}\" \"{idioma}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi, EnableRaisingEvents = true })
            {
                // Evento para lidar com a saída padrão (stdout) do console
                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        Console.WriteLine($"Saída do Console: {e.Data}");
                    }
                };

                // Evento para lidar com a saída de erro (stderr) do console
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        Console.WriteLine($"Erro do Console: {e.Data}");
                    }
                };

                // Iniciar a leitura assíncrona da saída padrão e de erro
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                // Aguardar o término do processo
                process.WaitForExit();
            }
        }
    }
}
