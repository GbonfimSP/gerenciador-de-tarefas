using GerenciadorDeTarefas;



List<Tarefa> tarefas = new List<Tarefa>();
string caminhoArquivo = "tarefas.json";

//Carregar tarefas ao iniciar.
Metodos.CarregarTarefas(tarefas, caminhoArquivo);
bool continuar = true;

while (continuar)
{
    Console.WriteLine("=== Gerenciador de Tarefas ===");
    Console.WriteLine("[1] Adicionar Tarefa.");
    Console.WriteLine("[2] Exibir Tarefa.");
    Console.WriteLine("[3] Concluir Tarefa.");
    Console.WriteLine("[4] Remover Tarefa.");
    Console.WriteLine("[5] Salvar Tarefas.");
    Console.WriteLine("[6] Filtrar Tarefas.");
    Console.WriteLine("[7] Editar Tarefas.");
    Console.WriteLine("[8] Sair.");
    Console.Write("Escolhar uma opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Clear();
            Console.Write("Digite o Titulo da tarefa: ");
            string titulo = Console.ReadLine();
            Console.Write("Digite a descrição da Tarefa: ");
            string descricao = Console.ReadLine();
            Console.Write("Digite a data de conclusão (AAAA-MM-DD) ou deixe em branco: ");
            string entradaData = Console.ReadLine();
            DateTime dataConclusao;

            if (string.IsNullOrWhiteSpace(entradaData))
            {
                dataConclusao = DateTime.MaxValue; // ou DateTime.Now se preferir
            }
            else
            {
                dataConclusao = DateTime.Parse(entradaData);
            }
            Metodos.AdicionarTarefa(tarefas, titulo, descricao, dataConclusao);
            Console.WriteLine("Tarefa adicionada com sucesso!");
            Console.WriteLine();
            break;

        case "2":
            Console.Clear();
            Metodos.ExibirTarefas(tarefas);
            Console.ReadKey();
            break;

        case "3":
            Console.Clear();
            Console.Write("Digite o titulo da tarefa para concluir: ");
            string tituloConcluir = Console.ReadLine();
            Metodos.ConcluirTarefa(tarefas,tituloConcluir);
            Console.WriteLine("Tarefa concluida com sucesso!");
            Console.WriteLine();
            break;

        case "4":
            Console.Clear();
            Console.Write("Digite o titulo da tarefa para remover: ");
            string tituloRemover = Console.ReadLine();
            Metodos.RemoverTarefa(tarefas,tituloRemover);
            Console.WriteLine("Tarefa removida com sucesso!");
            Console.WriteLine();
            break;

        case "5":
            Console.Clear();
            Metodos.SalvarTarefas(tarefas);
            Console.WriteLine("Tarefa salva com sucessso!");
            Console.WriteLine();
            break;

        case "6":
            Console.Clear();
            Console.WriteLine("Dese ver [todas], [concluidas] ou [pendentes]? ");
            string filtro = Console.ReadLine();
            Metodos.FiltrarTarefa(tarefas, filtro);
            Console.WriteLine();
            break;

        case "7":
            Console.Clear();
            Console.WriteLine("Digite o titulo da tarefa que deseja editar: ");
            string tituloEditar = Console.ReadLine();
            Metodos.EditarTarefa(tarefas, tituloEditar);
            Console.WriteLine();
            break;

        case "8":
            Console.Clear();
            continuar = false;
            break;

        default:
            Console.Clear();
            Console.WriteLine("Opção Invalida!");
            break;
    }
}
Metodos.SalvarTarefas(tarefas);