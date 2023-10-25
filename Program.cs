using System;
using System.Collections.Generic;
using System.Linq;

class Despesa
{
    public string Categoria { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
}

class Program
{
    static List<Despesa> despesas = new List<Despesa>();

    static void Main()
    {
        while (true)
        {
            MostrarMenu();

            string escolha = Console.ReadLine();

            switch (escolha.ToLower())
            {
                case "1":
                    AdicionarDespesa();
                    break;
                case "2":
                    MostrarRelatorioMensal();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("----- Registro de Despesas Pessoais -----");
        Console.WriteLine("1. Adicionar Despesa");
        Console.WriteLine("2. Mostrar Relatório Mensal");
        Console.WriteLine("3. Sair");
        Console.Write("Escolha uma opção: ");
    }

    static void AdicionarDespesa()
    {
        Despesa novaDespesa = new Despesa();

        Console.Write("Categoria: ");
        novaDespesa.Categoria = Console.ReadLine();

        Console.Write("Valor: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
            novaDespesa.Valor = valor;
        }
        else
        {
            Console.WriteLine("Valor inválido. Tente novamente.");
            return;
        }

        novaDespesa.Data = DateTime.Now;

        despesas.Add(novaDespesa);

        Console.WriteLine("Despesa adicionada com sucesso!");
    }

    static void MostrarRelatorioMensal()
    {
        Console.Write("Digite o mês (1 a 12): ");
        if (int.TryParse(Console.ReadLine(), out int mes) && mes >= 1 && mes <= 12)
        {
            var despesasDoMes = despesas.Where(d => d.Data.Month == mes);

            if (despesasDoMes.Any())
            {
                Console.WriteLine($"----- Relatório do Mês {mes} -----");
                foreach (var despesa in despesasDoMes)
                {
                    Console.WriteLine($"Categoria: {despesa.Categoria}, Valor: {despesa.Valor:C}, Data: {despesa.Data.ToShortDateString()}");
                }
                decimal totalDespesas = despesasDoMes.Sum(d => d.Valor);
                Console.WriteLine($"Total de Despesas: {totalDespesas:C}");
            }
            else
            {
                Console.WriteLine("Nenhuma despesa registrada para este mês.");
            }
        }
        else
        {
            Console.WriteLine("Mês inválido. Tente novamente.");
        }
    }
}
