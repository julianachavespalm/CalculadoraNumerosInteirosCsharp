using System;
using System.Collections.Generic;
using System.Globalization;
using Calculadora.Models;

namespace Calculadora.Services
{
    public class CalculadoraInteiros
    {
        private List<string> HistoricoResultados = new List<string>();
        private Formatador valorFormatado;
        public Historico historico;

        public CalculadoraInteiros()
        {
            valorFormatado = new Formatador();
            historico = new Historico();
        }

        public string RealizarOperacaoMatematica(string valor1, string valor2, string operacao)
        {
            double valorConvertido1, valorConvertido2;

            if (TryParseDouble(valor1, out valorConvertido1) && TryParseDouble(valor2, out valorConvertido2))
            {
                string resultadoFormatado = string.Empty;

                try
                {
                    double resultado = CalcularOperacao(valorConvertido1, valorConvertido2, operacao);

                    resultadoFormatado = valorFormatado.ValorFormatado(resultado);

                    historico.AdicionarAoHistorico(resultadoFormatado);
                    return resultadoFormatado;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "Entradas inválidas. São necessários dois números.";
            }
        }

        public string ObterHistoricoResultados()
        {
            return historico.ObterHistoricoResultados();
        }

        private bool TryParseDouble(string valor, out double result)
        {
            return double.TryParse(valor, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("pt-BR"), out result);
        }

        private double CalcularOperacao(double valor1, double valor2, string operacao)
        {
            switch (operacao)
            {
                case "soma":
                case "+":
                    return valor1 + valor2;
                case "subtração":
                case "-":
                    return valor1 - valor2;
                case "multiplicação":
                case "*":
                    return valor1 * valor2;
                case "divisão":
                case "/":
                    if (valor2 == 0)
                    {
                        throw new DivideByZeroException("Não é possível dividir por zero.");
                    }
                    return valor1 / valor2;
                default:
                    throw new ArgumentException("Operação não suportada.");
            }
        }
    }
}