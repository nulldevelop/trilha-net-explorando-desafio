using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Configura a cultura brasileira para valores monetários
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

// Lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Console.WriteLine("=== Cadastro de Hóspedes ===");

Console.Write("Quantos hóspedes deseja cadastrar? ");
int quantidadeHospedes = int.Parse(Console.ReadLine() ?? "0");

// Cadastra cada hóspede
for (int i = 0; i < quantidadeHospedes; i++)
{
    Console.WriteLine($"\nCadastro do hóspede {i + 1}");

    Console.Write("Nome: ");
    string nome = Console.ReadLine() ?? "";

    Pessoa pessoa = new Pessoa(nome: nome);
    hospedes.Add(pessoa);
}

// Configura os dados da suíte
Console.WriteLine("\n=== Dados da Suíte ===");

Console.Write("Digite a capacidade da suíte: ");
int capacidadeSuiteInput = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Digite a quantidade de dias reservados: ");
int diasReservadosInput = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Digite o valor da diária: ");
decimal valorDiariaInput = decimal.Parse(
    Console.ReadLine() ?? "0",
    CultureInfo.GetCultureInfo("pt-BR")
);

// Cria a suíte
Suite suite = new Suite(
    tipoSuite: "Premium",
    capacidade: capacidadeSuiteInput,
    valorDiaria: valorDiariaInput
);

// Cria a reserva
Reserva reserva = new Reserva(diasReservados: diasReservadosInput);

reserva.CadastrarSuite(suite);

// Valida e cadastra os hóspedes
try
{
    reserva.CadastrarHospedes(hospedes);

    Console.WriteLine("\n=== Resumo da Reserva ===");
    Console.WriteLine($"Suíte: Premium");
    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");

    foreach (Pessoa hospede in hospedes)
    {
        Console.WriteLine($"- {hospede.Nome}");
    }

    Console.WriteLine($"Dias reservados: {diasReservadosInput}");
    Console.WriteLine($"Valor total: {reserva.CalcularValorDiaria():C2}");
}
catch (Exception ex)
{
    Console.WriteLine($"\nErro ao cadastrar reserva: {ex.Message}");
}
