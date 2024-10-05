using System;
using System.Collections.Generic;

namespace taskmanager;

public class Tarefa
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public string Status { get; set; }

    public Tarefa(string titulo, string descricao)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = DateTime.Now;
        Status = "Pendente";
    }

    public void ExibirTarefa()
    {
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Descrição: {Descricao}");
        Console.WriteLine($"Data de Criação: {DataCriacao}");
        Console.WriteLine($"Status: {Status}");
        Console.WriteLine();
    }

    public void EditarTarefa(string novoTitulo, string novaDescricao, string novoStatus)
    {
        Titulo = novoTitulo;
        Descricao = novaDescricao;
        Status = novoStatus;
    }
}

class Program
{
    static List<Tarefa> tarefas = new List<Tarefa>();

    static void Main(string[] args)
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("=== Gerenciador de Tarefas ===");
            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Editar Tarefa");
            Console.WriteLine("4. Remover Tarefa");
            Console.WriteLine("5. Sair");
            Console.Write("Selecione uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarTarefa();
                    break;
                case "2":
                    ListarTarefas();
                    break;
                case "3":
                    EditarTarefa();
                    break;
                case "4":
                    RemoverTarefa();
                    break;
                case "5":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void AdicionarTarefa()
    {
        Console.Write("Digite o título da tarefa: ");
        string titulo = Console.ReadLine();
        Console.Write("Digite a descrição da tarefa: ");
        string descricao = Console.ReadLine();

        Tarefa novaTarefa = new Tarefa(titulo, descricao);
        tarefas.Add(novaTarefa);
        Console.WriteLine("Tarefa adicionada com sucesso!\n");
    }

    static void ListarTarefas()
    {
        if (tarefas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa encontrada.\n");
            return;
        }

        Console.WriteLine("=== Lista de Tarefas ===");
        for (int i = 0; i < tarefas.Count; i++)
        {
            Console.WriteLine($"Tarefa {i + 1}:");
            tarefas[i].ExibirTarefa();
        }
    }

    static void EditarTarefa()
    {
        ListarTarefas();
        if (tarefas.Count == 0) return;

        Console.Write("Digite o número da tarefa que deseja editar: ");
        int numeroTarefa;
        if (int.TryParse(Console.ReadLine(), out numeroTarefa) && numeroTarefa > 0 && numeroTarefa <= tarefas.Count)
        {
            Tarefa tarefa = tarefas[numeroTarefa - 1];

            Console.Write("Digite o novo título: ");
            string novoTitulo = Console.ReadLine();
            Console.Write("Digite a nova descrição: ");
            string novaDescricao = Console.ReadLine();
            Console.WriteLine("Selecione o novo status (Pendente, Em Andamento, Concluída): ");
            string novoStatus = Console.ReadLine();

            tarefa.EditarTarefa(novoTitulo, novaDescricao, novoStatus);
            Console.WriteLine("Tarefa editada com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido.\n");
        }
    }

    static void RemoverTarefa()
    {
        ListarTarefas();
        if (tarefas.Count == 0) return;

        Console.Write("Digite o número da tarefa que deseja remover: ");
        int numeroTarefa;
        if (int.TryParse(Console.ReadLine(), out numeroTarefa) && numeroTarefa > 0 && numeroTarefa <= tarefas.Count)
        {
            tarefas.RemoveAt(numeroTarefa - 1);
            Console.WriteLine("Tarefa removida com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido.\n");
        }
    }
}

