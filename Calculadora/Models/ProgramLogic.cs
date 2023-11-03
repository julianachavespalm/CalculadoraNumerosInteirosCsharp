using System;
using System.Collections.Generic;
using System.Linq;
using Calculadora.Services;
using System.Threading.Tasks;

namespace Calculadora.Models
{
    public class ProgramLogic
    {
        private readonly CalculadoraInteiros calculadora;

        public ProgramLogic()
        {
            calculadora = new CalculadoraInteiros();
        }

        public string RealizarCalculo(string valor1, string operacao, string valor2)
        {
            if (DeveSair(valor1) || DeveSair(operacao) || DeveSair(valor2))
            {
                return "Calculadora encerrada.";
            }

            return calculadora.RealizarOperacaoMatematica(valor1, valor2, operacao);
        }

        private bool DeveSair(string entrada)
        {
            return entrada == "sair" || entrada == "s";
        }

        
    }
}