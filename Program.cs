using System;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Services;

namespace SistemaDeTarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenciadorTarefas gerenciador = new GerenciadorTarefas();

            while (true)
            {
                Console.WriteLine("=== Sistema de Tarefas ===");
                Console.WriteLine();
                Console.WriteLine("1. Adicionar Tarefa");
                Console.WriteLine("2. Concluir Tarefa");
                Console.WriteLine("3. Remover Tarefas");
                Console.WriteLine("4. Listar Todas as Tarefas");
                Console.WriteLine("5. Listar Tarefas Pendentes");
                Console.WriteLine("6. Listar Tarefas Concluídas");
                Console.WriteLine("0. Sair");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("Qual o título da tarefa?");
                            string titulo = Console.ReadLine();

                            Console.WriteLine("Qual a descrição da tarefa?");
                            string descricao = Console.ReadLine();

                            Console.WriteLine("Qual o prazo da tarefa? (formato: dd/MM/yyyy)");
                            DateTime prazo = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine("Qual a prioridade da tarefa? (Baixa, Média, Alta)");
                            string prioridade = Console.ReadLine();

                            gerenciador.AdicionarTarefa(new Tarefa(titulo, descricao, prazo, prioridade));
                            Console.WriteLine("Tarefa adicionada com sucesso!");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Formato de data inválido. Certifique-se de digitar a data no formato dd/MM/yyyy.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                        }
                        break;

                    case "2":
                        Console.WriteLine("digite o ID da tarefa que deseja concluir:");
                        try
                        {
                            Guid idConcluir = Guid.Parse(Console.ReadLine());
                            gerenciador.ConcluirTarefa(idConcluir);
                            Console.WriteLine("Tarefa concluída com sucesso!");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("ID inválido. Certifique-se de digitar um GUID válido.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        Console.WriteLine("Digite o ID da tarefa que deseja remover:");
                        try
                        {
                            Guid idRemover = Guid.Parse(Console.ReadLine());
                            gerenciador.RemoverTarefa(idRemover);
                            Console.WriteLine("Tarefa removida com sucesso!");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("ID inválido. Certifique-se de digitar um GUID válido.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "4":
                        gerenciador.ListarTodasTarefas();
                        break;

                    case "5":
                        gerenciador.ListarTarefasPendentes();
                        break;

                    case "6":
                        gerenciador.ListarTarefasConcluidas();
                        break;

                    case "0":
                        Console.WriteLine("Saindo do sistema...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}