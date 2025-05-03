using GerenciadorDeTarefas;



List<Tarefa> tarefas = new List<Tarefa>();
Metodos.AdicionarTarefa(tarefas, "Estudar C#", "Estudar o básico do C#.", DateTime.Now.AddDays(2));
Metodos.ExibirTarefas(tarefas);

// Concluir uma tarefa
Metodos.ConcluirTarefa(tarefas, "Estudar C#");

// Verificar se foi concluída
Metodos.ExibirTarefas(tarefas);

Metodos.RemoverTarefa(tarefas, "Estudar C#");
Console.WriteLine("2");
Metodos.ExibirTarefas(tarefas);
