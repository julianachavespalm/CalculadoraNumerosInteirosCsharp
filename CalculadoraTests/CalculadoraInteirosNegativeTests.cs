using System;
using Xunit;
using Calculadora.Services;

public class CalculadoraInteirosNegativeTests
{
    private CalculadoraInteiros _calculadora;

    public CalculadoraInteirosNegativeTests()
    {
        _calculadora = new CalculadoraInteiros();
    }

    private string ResultadoAtual(string valor1, string valor2, string operacao)
    {
        string resultado = _calculadora.RealizarOperacaoMatematica(valor1, valor2, operacao);
        return resultado;
    }

    private string ResultadoEsperado(string valor)
    {
        string dataAtual = DateTime.Now.ToString("dd/MM/yyyy");
        string entradaInvalida = "Entradas inválidas. São necessários dois números.";
        string divisaoZero = "Não é possível dividir por zero.";
        string operacaoNaoSuportada = "Operação não suportada.";
        if (valor == "entradaInvalida")
        {
            return $"{entradaInvalida}";
        }
        else if (valor == "divisaoZero")
        {
            return $"{divisaoZero}";
        }
        else
            return $"{operacaoNaoSuportada}";
    }

    [Theory]
    [InlineData("soma", "2654", "abc", "entradaInvalida")]
    [InlineData("+", "", "3,5", "entradaInvalida")]
    [InlineData("+", "2652654", "..", "entradaInvalida")]
    [InlineData("soma", "", "0,11111", "entradaInvalida")]
    public void AoRealizarSomaComNumeroInvalidoDeveRetornarMensagemErro(string operacao, string valor1, string valor2, string valorEsperado)
    {
        string resultadoEsperado = ResultadoEsperado(valorEsperado);
        string resultadoAtual = ResultadoAtual(valor1, valor2, operacao);

        Assert.Equal(resultadoEsperado, resultadoAtual);
    }

    [Theory]
    [InlineData("subtração", "2654", "abc", "entradaInvalida")]
    [InlineData("-", "", "3,5", "entradaInvalida")]
    [InlineData("subtração", "156", "..", "entradaInvalida")]
    [InlineData("-", "", "0,11111", "entradaInvalida")]
    public void AoRealizarSubtracaoComNumeroInvalidoDeveRetornarMensagemErro(string operacao, string valor1, string valor2, string valorEsperado)
    {
        string resultadoEsperado = ResultadoEsperado(valorEsperado);
        string resultadoAtual = ResultadoAtual(valor1, valor2, operacao);

        Assert.Equal(resultadoEsperado, resultadoAtual);
    }

    [Theory]
    [InlineData("*", "2654", "abc", "entradaInvalida")]
    [InlineData("multiplicação", "", "3,5", "entradaInvalida")]
    [InlineData("*", "156", "..", "entradaInvalida")]
    [InlineData("multiplicação", "", "0,11111", "entradaInvalida")]
    public void AoRealizarMultiplicaoComNumeroInvalidoDeveRetornarMensagemErro(string operacao, string valor1, string valor2, string valorEsperado)
    {
        string resultadoEsperado = ResultadoEsperado(valorEsperado);
        string resultadoAtual = ResultadoAtual(valor1, valor2, operacao);

        Assert.Equal(resultadoEsperado, resultadoAtual);
    }
    [Theory]
    [InlineData("/", "2654", "abc", "entradaInvalida")]
    [InlineData("/", "", "0", "entradaInvalida")]
    [InlineData("divisão", "0", "0", "divisaoZero")]
    [InlineData("/", "0", "0,11,111", "entradaInvalida")]
    public void AoRealizarDivisaoComNumeroInvalidoDeveRetornarMensagemErro(string operacao, string valor1, string valor2, string valorEsperado)
    {
        string resultadoEsperado = ResultadoEsperado(valorEsperado);
        string resultadoAtual = ResultadoAtual(valor1, valor2, operacao);

        Assert.Equal(resultadoEsperado, resultadoAtual);
    }

    [Theory]
    [InlineData("divisão", "2654", "abc", "")]
    [InlineData("/", "", "0", "")]
    [InlineData("divisão", "0", "0", "")]
    [InlineData("/", "0", "0,11,111", "")]
    public void NaoDeveArmazenarExcecoesNoHistorico(string operacao, string valor1, string valor2, string valorEsperado)
    {

        string resultadoEsperado = valorEsperado;

        ResultadoAtual(valor1, valor2, operacao);
        ResultadoAtual(valor1, valor2, operacao);
        ResultadoAtual(valor1, valor2, operacao);
        ResultadoAtual(valor1, valor2, operacao);

        string resultadoAtual = _calculadora.ObterHistoricoResultados();

        Assert.Equal(resultadoEsperado, resultadoAtual);
    }

    [Theory]
    [InlineData("", "2", "3", "5")]
    [InlineData("ouio", "194,56", "5,4564", "36")]
    [InlineData("gdf", "10000", "0,11111", "1.111")]
    [InlineData("rew5", "2", "3,5", "-2")]
    public void AoRealizarOperacaoNaoSuportadaDeveRetonarMensagemDeErro(string operacao, string valor1, string valor2, string valorEsperado)
    {
        string resultadoEsperado = ResultadoEsperado(valorEsperado);
        string resultadoAtual = ResultadoAtual(valor1, valor2, operacao);

        Assert.Equal(resultadoEsperado, resultadoAtual);
    }

}
