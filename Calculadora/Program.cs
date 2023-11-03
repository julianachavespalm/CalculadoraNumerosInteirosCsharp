using System;
using Calculadora.Models;
using Calculadora.Services;

class Program
{
    static void Main()
    {
        var programLogic = new ProgramLogic();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Calculadora de números inteiros\nJuliana Chaves Palm\n");

            var valor1 = ObterEntrada("Digite o primeiro valor ou 'sair' para encerrar: ");
            if (programLogic.RealizarCalculo(valor1, "", "") == "Saindo...") return;

            var operacao = ObterEntrada("Digite a operação (+, -, *, /): ");
            if (programLogic.RealizarCalculo("", operacao, "") == "Saindo...") return;

            var valor2 = ObterEntrada("Digite o segundo valor: ");
            if (programLogic.RealizarCalculo("", "", valor2) == "Saindo...") return;

            var resultado = programLogic.RealizarCalculo(valor1, operacao, valor2);

            Console.WriteLine(resultado.Contains("Operação não suportada") ? resultado : $"Resultado: {resultado}\n");

            Console.WriteLine("Histórico:");
            Console.WriteLine("Histórico de resultados não suportado no momento.");

            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }
    }

    static string ObterEntrada(string prompt) => Console.ReadLine().ToLower();
}
