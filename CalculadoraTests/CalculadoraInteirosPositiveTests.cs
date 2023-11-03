using System;
using Xunit;
using Calculadora.Models;
using Calculadora.Services;

public class CalculadoraInteirosPositiveTests
{
    private CalculadoraInteiros _calculadora;
    private ProgramLogic _calculadoraLogic;

    public CalculadoraInteirosPositiveTests()
    {
        _calculadora = new CalculadoraInteiros();
        _calculadoraLogic = new ProgramLogic();
    }

    private string ResultadoAtual(string valor1, string valor2, string operacao)
    {
        string resultado = _calculadora.RealizarOperacaoMatematica(valor1, valor2, operacao);
        return resultado;
    }

    private string ResultadoEsperado(string valor)
    {
        string dataAtual = DateTime.Now.ToString("dd/MM/yyyy");
        return $"{valor} ({dataAtual})";
    }

    // Testes para verificar se, ao somar dois números válidos, o resultado é formatado como uma string no formato "resultado e data (dd/MM/yyyy) da operação"
    [Theory]
    [InlineData("+", "2", "3", "5")]
    [InlineData("soma", "2", "3,5", "6")]
    [InlineData("soma", "1000000", "1000000", "2.000.000")]
    [InlineData("+", "999999,99", "0,01", "1.000.000")]
    public void DeveExibirResultadoDaSomaEData(string operacao, string valor1, string valor2, string valorEsperado)
    {
        string resultadoEsperado = ResultadoEsperado(valorEsperado);
        string resultadoAtual = ResultadoAtual(valor1, valor2, operacao);

        Assert.Equal(resultadoEsperado, resultadoAtual);
    }

    // Testes para verificar se, ao subtrair dois números válidos, o resultado é formatado como uma string no formato "resultado e data (dd/MM/yyyy) da operação"    
    [Theory]
    [InlineData("subtração", "10", "7", "3")]
    [InlineData("-", "100,5", "25,25", "75")]
    [InlineData("-", "999999", "1", "999.998")]
    [InlineData("subtração", "1234567,89", "7654321,09", "-6.419.753")]
    public void DeveExibirResultadoDaSubtracaoEData(string operacao, string valor1, string valor2, string valorEsperado)
    {
        string resultadoEsperado = ResultadoEsperado(valorEsperado);
        string resultadoAtual = ResultadoAtual(valor1, valor2, operacao);

        Assert.Equal(resultadoEsperado, resultadoAtual);
    }

    // Testes para verificar se, ao multiplicar dois números válidos, o resultado é formatado como uma string no formato "resultado e data (dd/MM/yyyy) da operação"    
    [Theory]
    [InlineData("*", "2", "3", "6")]
    [InlineData("multiplicação", "2", "3,5", "7")]
    [InlineData("*", "12,345", "6,789", "84")]
    [InlineData("multiplicação", "987654", "12345", "12.192.588.630")]
    public void DeveExibirResultadoDaMultiplicacaoEData(string operacao, string valor1, string valor2, string valorEsperado)
    {
        string resultadoEsperado = ResultadoEsperado(valorEsperado);
        string resultadoAtual = ResultadoAtual(valor1, valor2, operacao);

        Assert.Equal(resultadoEsperado, resultadoAtual);
    }

    // Testes para verificar se, ao dividir dois números válidos, o resultado é formatado como uma string no formato "resultado e data (dd/MM/yyyy) da operação"    
    [Theory]
    [InlineData("/", "2", "3", "1")]
    [InlineData("divisão", "22,5", "0,5", "45")]
    [InlineData("/", "1000000", "1000", "1.000")]
    [InlineData("divisão", "1234567,89", "123,45", "10.001")]
    public void DeveExibirResultadoDaDivisaoEData(string operacao, string valor1, string valor2, string valorEsperado)
    {
        string resultadoEsperado = ResultadoEsperado(valorEsperado);
        string resultadoAtual = ResultadoAtual(valor1, valor2, operacao);

        Assert.Equal(resultadoEsperado, resultadoAtual);
    }


    [Theory]
    [InlineData("+", "2", "3", "5")]
    [InlineData("divisão", "194,56", "5,4564", "36")]
    [InlineData("*", "10000", "0,11111", "1.111")]
    [InlineData("subtração", "2", "3,5", "-2")]
    public void DeveArmazenarApenasOsUltimosTresResultados(string operacao, string valor1, string valor2, string valorEsperado)
    {

        string resultadoEsperado = $"{ResultadoEsperado(valorEsperado)}{Environment.NewLine}{ResultadoEsperado(valorEsperado)}{Environment.NewLine}{ResultadoEsperado(valorEsperado)}";

        ResultadoAtual(valor1, valor2, operacao);
        ResultadoAtual(valor1, valor2, operacao);
        ResultadoAtual(valor1, valor2, operacao);
        ResultadoAtual(valor1, valor2, operacao);

        string resultadoAtual = _calculadora.historico.ObterHistoricoResultados();

        Assert.Equal(resultadoEsperado, resultadoAtual);

    }
}
