namespace SistemaDeTarefas.Models
{
    public class Tarefa
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Prazo { get; private set; }
        public string Prioridade { get; private set; }
        public bool Concluida { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Tarefa(string titulo, string descricao, DateTime prazo, string prioridade)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            Prazo = prazo;
            Prioridade = prioridade;
            Concluida = false;
            DataCriacao = DateTime.Now;
        }

        public void Concluir() => Concluida = true;

        public void ExibirInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Descrição: {Descricao}");
            Console.WriteLine($"Prazo: {Prazo}");
            Console.WriteLine($"Prioridade: {Prioridade}");
            Console.WriteLine($"Concluída: {(Concluida ? "Sim" : "Não")}");
            Console.WriteLine($"Data de Criação: {DataCriacao}");
        }
    }
}