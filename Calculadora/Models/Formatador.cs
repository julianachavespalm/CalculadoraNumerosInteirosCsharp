using System;
using System.Globalization;

namespace Calculadora.Models
{
    public class Formatador
    {
        public string ValorFormatado(double valor) 
        {
            string dataAtual = DateTime.Now.ToString("dd/MM/yyyy");
            string valorFormatado = $"{Math.Round(valor, 0).ToString("N0", new CultureInfo("pt-BR"))} ({dataAtual})";
            return valorFormatado;
        }
    }
}
