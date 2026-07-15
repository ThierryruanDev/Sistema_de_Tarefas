using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Services
{
    public class GerenciadorTarefas
    {
        private List<Tarefa> tarefas;

        public GerenciadorTarefas()
        {
            tarefas = new List<Tarefa>();
        }

        public void AdicionarTarefa(Tarefa tarefa)
        {
            tarefas.Add(tarefa);
        }

        public void ConcluirTarefa(Guid id)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
                throw new ArgumentException("Tarefa não encontrada.");

            if (tarefa.Concluida)
                throw new InvalidOperationException("Tarefa já foi concluída.");

            tarefa.Concluir();
        }

        public void ListarTodasTarefas()
        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Não há tarefas cadastradas.");
                return;
            }

            foreach (Tarefa tarefa in tarefas)
            {
                tarefa.ExibirInfo();
                Console.WriteLine("----------------------------");
            }
        }

        public void ListarTarefasPendentes()
        {
            var tarefasPendentes = tarefas.Where(t => !t.Concluida).ToList();
            if (tarefasPendentes.Count == 0)
            {
                Console.WriteLine("Não há tarefas pendentes.");
                return;
            }

            foreach (Tarefa tarefa in tarefasPendentes)
            {
                tarefa.ExibirInfo();
                Console.WriteLine("----------------------------");
            }
        }

        public void ListarTarefasConcluidas()
        {
            var tarefasConcluidas = tarefas.Where(t => t.Concluida).ToList();
            if (tarefasConcluidas.Count == 0)
            {
                Console.WriteLine("Não há tarefas concluídas.");
                return;
            }

            foreach (Tarefa tarefa in tarefasConcluidas)
            {
                tarefa.ExibirInfo();
                Console.WriteLine("----------------------------");
            }
        }

        public void RemoverTarefa(Guid id)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null)
                throw new ArgumentException("Tarefa não encontrada.");

            tarefas.Remove(tarefa);
        }
    }
}