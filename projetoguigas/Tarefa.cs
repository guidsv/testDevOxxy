// Tarefa.cs
using System;

namespace TaskManagerApp
{
    public class Tarefa
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public StatusTarefa Status { get; private set; }

        public Tarefa(string titulo, string descricao, StatusTarefa status)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = DateTime.Now;
            Status = status;
        }

        public void ExibirTarefa()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Descrição: {Descricao}");
            Console.WriteLine($"Data de Criação: {DataCriacao}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine(new string('-', 30));
        }

        public void EditarTarefa(string novoTitulo, string novaDescricao, StatusTarefa novoStatus)
        {
            if (!string.IsNullOrWhiteSpace(novoTitulo))
                Titulo = novoTitulo;

            if (!string.IsNullOrWhiteSpace(novaDescricao))
                Descricao = novaDescricao;

            Status = novoStatus;
        }
    }
}
