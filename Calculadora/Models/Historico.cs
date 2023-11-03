using System;
using System.Collections.Generic;

namespace Calculadora.Models
{
    public class Historico
    {
        private List<string> HistoricoResultados = new List<string>();

        public void AdicionarAoHistorico(string resultado)
        {
            HistoricoResultados.Insert(0, resultado);

            if (HistoricoResultados.Count > 3)
            {
                HistoricoResultados.RemoveAt(3);
            }
        }

        public string ObterHistoricoResultados()
        {
            return string.Join(Environment.NewLine, HistoricoResultados);
        }
    }
}
