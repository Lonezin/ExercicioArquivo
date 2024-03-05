using System.Globalization;
using Atividade_Arquivo;

namespace Curso
{
    class Program
    {
        static void Main (string[] args)
        {
            System.Console.WriteLine("entre com o local do arquivo: ");
            string localDoArquivo = Console.ReadLine(); //$"C:\Users\lonez\Desktop\Aula.csv"
            try
            {
                string[] lines = File.ReadAllLines(localDoArquivo);
                string sourceFolderPath = Path.GetDirectoryName(localDoArquivo);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);
                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string item in lines)
                    {
                        string [] campos = item.Split(",");
                        string name = campos[0];
                        double preco = double.Parse(campos[1],CultureInfo.InvariantCulture);
                        int quantidade = int.Parse(campos[2]);

                        Produto produto = new Produto(name, preco, quantidade);
                        sw.WriteLine(produto.Nome + ", " + produto.ValorTotal().ToString("F2", CultureInfo.InvariantCulture) );
                    }                    
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}