using GerenciadorDeTarefas;



List<Tarefa> tarefas = new List<Tarefa>();
Metodos.AdicionarTarefa(tarefas, "Estudar C#", "Estudar o básico do C#.", DateTime.Now.AddDays(2));
Metodos.ExibirTarefass(tarefas);



Metodos.AdicionarTarefa(tarefas, "Estudar C#", "Estudar o básico do C#", DateTime.Now.AddDays(2));
Metodos.ExibirTarefass(tarefas);

