// TaskManager.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerApp
{
    public class TaskManager
    {
        private List<Tarefa> listaTarefas = new List<Tarefa>();

        public void AdicionarTarefa()
        {
            Console.Write("Digite o título da tarefa: ");
            string titulo = Console.ReadLine();
            Console.Write("Digite a descrição da tarefa: ");
            string descricao = Console.ReadLine();

            StatusTarefa status = SelecionarStatus();

            Tarefa novaTarefa = new Tarefa(titulo, descricao, status);
            listaTarefas.Add(novaTarefa);
            Console.WriteLine("Tarefa adicionada com sucesso!\n");
        }

        public void ListarTarefas()
        {
            if (!listaTarefas.Any())
            {
                Console.WriteLine("Nenhuma tarefa encontrada.\n");
                return;
            }

            Console.WriteLine("=== Lista de Tarefas ===");
            int contador = 1;
            foreach (var tarefa in listaTarefas)
            {
                Console.WriteLine($"Tarefa {contador}:");
                tarefa.ExibirTarefa();
                contador++;
            }
        }

        public void EditarTarefa()
        {
            ListarTarefas();
            if (!listaTarefas.Any()) return;

            Console.Write("Digite o número da tarefa que deseja editar: ");
            if (int.TryParse(Console.ReadLine(), out int numeroTarefa) && numeroTarefa > 0 && numeroTarefa <= listaTarefas.Count)
            {
                Tarefa tarefa = listaTarefas[numeroTarefa - 1];

                Console.Write("Digite o novo título (deixe vazio para manter o atual): ");
                string novoTitulo = Console.ReadLine();
                Console.Write("Digite a nova descrição (deixe vazio para manter a atual): ");
                string novaDescricao = Console.ReadLine();

                Console.WriteLine("Deseja alterar o status? (s/n): ");
                string alterarStatus = Console.ReadLine();
                StatusTarefa novoStatus = tarefa.Status;

                if (alterarStatus.Equals("s", StringComparison.OrdinalIgnoreCase))
                {
                    novoStatus = SelecionarStatus();
                }

                tarefa.EditarTarefa(novoTitulo, novaDescricao, novoStatus);
                Console.WriteLine("Tarefa editada com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Número de tarefa não existente.\n");
            }
        }

        public void RemoverTarefa()
        {
            ListarTarefas();
            if (!listaTarefas.Any()) return;

            Console.Write("Digite o número da tarefa que deseja remover: ");
            if (int.TryParse(Console.ReadLine(), out int numeroTarefa) && numeroTarefa > 0 && numeroTarefa <= listaTarefas.Count)
            {
                listaTarefas.RemoveAt(numeroTarefa - 1);
                Console.WriteLine("Tarefa removida com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Número de tarefa inválido.\n");
            }
        }

        public void FiltrarTarefasPorStatus()
        {
            StatusTarefa statusFiltro = SelecionarStatus();

            var tarefasFiltradas = listaTarefas.Where(t => t.Status == statusFiltro).ToList();

            if (!tarefasFiltradas.Any())
            {
                Console.WriteLine($"Nenhuma tarefa encontrada com o status '{statusFiltro}'.\n");
                return;
            }

            Console.WriteLine($"=== Lista de Tarefas com Status '{statusFiltro}' ===");
            int contador = 1;
            foreach (var tarefa in tarefasFiltradas)
            {
                Console.WriteLine($"Tarefa {contador}:");
                tarefa.ExibirTarefa();
                contador++;
            }
        }

        public void BuscarPorTitulo()
        {
            Console.Write("Digite o título que deseja buscar: ");
            string buscaTitulo = Console.ReadLine();

            var tarefasFiltradas = listaTarefas
                .Where(t => t.Titulo.Contains(buscaTitulo, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!tarefasFiltradas.Any())
            {
                Console.WriteLine($"Nenhuma tarefa encontrada com o título '{buscaTitulo}'.\n");
                return;
            }

            Console.WriteLine($"=== Lista de Tarefas com Título '{buscaTitulo}' ===");
            int contador = 1;
            foreach (var tarefa in tarefasFiltradas)
            {
                Console.WriteLine($"Tarefa {contador}:");
                tarefa.ExibirTarefa();
                contador++;
            }
        }

        private StatusTarefa SelecionarStatus()
        {
            while (true)
            {
                Console.WriteLine("Escolha o status da tarefa:");
                Console.WriteLine("1. Pendente");
                Console.WriteLine("2. Em Andamento");
                Console.WriteLine("3. Concluída");
                Console.Write("Selecione uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        return StatusTarefa.Pendente;
                    case "2":
                        return StatusTarefa.EmAndamento;
                    case "3":
                        return StatusTarefa.Concluida;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.\n");
                        break;
                }
            }
        }
    }
}
