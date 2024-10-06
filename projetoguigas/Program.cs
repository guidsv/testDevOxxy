// Program.cs
using System;

namespace TaskManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager(); //Variável de controle que irá gerenciar as tarefas
            bool sair = false;

            while (!sair)
            {
                MostrarMenu();
                Console.Write("Selecione uma opção: ");
                string opcao = Console.ReadLine(); 
                Console.WriteLine();

                switch (opcao) // Verifica a entrada do usuário de acordo com a opção desejada.
                {
                    case "1":
                        taskManager.AdicionarTarefa();
                        break;
                    case "2":
                        taskManager.ListarTarefas();
                        break;
                    case "3":
                        taskManager.EditarTarefa();
                        break;
                    case "4":
                        taskManager.RemoverTarefa();
                        break;
                    case "5":
                        taskManager.FiltrarTarefasPorStatus();
                        break;
                    case "6":
                        taskManager.BuscarPorTitulo();
                        break;
                    case "7":
                        sair = true;
                        Console.WriteLine("Saindo do Gerenciador de Tarefas. Até logo!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, selecione um número válido.\n");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("=== Gerenciador de Tarefas ===");
            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Editar Tarefa");
            Console.WriteLine("4. Remover Tarefa");
            Console.WriteLine("5. Filtrar Tarefas por Status");
            Console.WriteLine("6. Buscar por Título");
            Console.WriteLine("7. Sair");
            Console.WriteLine(new string('=', 30));
        }
    }
}
