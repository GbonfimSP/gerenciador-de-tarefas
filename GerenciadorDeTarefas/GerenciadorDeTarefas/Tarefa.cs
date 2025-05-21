using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;
using System.Security;



namespace GerenciadorDeTarefas
{
    public class Tarefa
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataDeConclusao { get; set; }
        public bool Concluida { get; set; }

       
    }

    public class Metodos
    {
        public static void AdicionarTarefa(List<Tarefa> tarefas, string titulo, string descricao, DateTime dataConclusao)
        {
            Tarefa novaTarefa = new Tarefa()
            {
                Titulo = titulo,
                Descricao = descricao,
                DataDeConclusao = dataConclusao,
                Concluida = false

            };
            tarefas.Add(novaTarefa);
        }

        public static void ExibirTarefas(List<Tarefa> tarefas)
        {
            foreach (var tarefa in tarefas)
            {
                string dataTexto = tarefa.DataDeConclusao == DateTime.MaxValue
                ? "Sem data"
                : tarefa.DataDeConclusao.ToShortDateString();
                Console.WriteLine($"Titulo: {tarefa.Titulo}, Concluída: {tarefa.Concluida}");
            }
        }

        public static void ConcluirTarefa(List<Tarefa> tarefas, string titulo)
        {
            foreach (var tarefa in tarefas)
            {
                if (tarefa.Titulo.ToLower() == titulo.ToLower())
                {
                    tarefa.Concluida = true;
                    Console.WriteLine($"Tarefa \" {titulo}\" marcada como concluida.");
                    return;
                }
            }
            Console.WriteLine("Tarefa não encontrada.");
        }
        public static void RemoverTarefa(List<Tarefa> tarefas, string titulo)
        {

            tarefas.RemoveAll(t => t.Titulo.ToLower() == titulo.ToLower());
        }

        public static void SalvarTarefas(List<Tarefa> tarefas)
        {
            string caminho = "tarefas.json";
            string json = JsonSerializer.Serialize(tarefas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminho, json);
        }

        public static void CarregarTarefas(List<Tarefa> tarefas,string caminhoArquivo)
        {
            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                tarefas.Clear();
                tarefas.AddRange(JsonSerializer.Deserialize<List<Tarefa>>(json));
            }
            else
            {
                Console.WriteLine("Arquivo de tarefas não encontrado.");
            }
                
        }

        public static void EditarTarefa(List<Tarefa> tarefas, string tituloAntigo)
        {
            var tarefa = tarefas.FirstOrDefault(t => t.Titulo.ToLower() == tituloAntigo.ToLower());
            if(tarefa != null)
            {
                Console.WriteLine("Novo titulo (ou enter para manter o mesmo): ");
                string novoTitulo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoTitulo))
                    tarefa.Titulo = novoTitulo;

                Console.WriteLine("Nova descrição (ou enter para manter a mesma): ");
                string novaDescricao = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novaDescricao))
                    tarefa.Descricao = novaDescricao;

                Console.WriteLine("Nova data ( dd/mm/aaaa) ou enter para manter: ");
                string novaData = Console.ReadLine();
                if (DateTime.TryParse(novaData, out DateTime novaDataConvertida))
                    tarefa.DataDeConclusao = novaDataConvertida;

                Console.WriteLine("Tarefa atualizada com sucesso!!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }
        public static void FiltrarTarefa( List<Tarefa> tarefas, string filtro)
        {
            List<Tarefa> filtradas = filtro.ToLower() switch
            {
                "concluidas" => tarefas.Where(t => t.Concluida).ToList(),
                "pendentes" => tarefas.Where(t => !t.Concluida).ToList(),
                _ => tarefas
            };

            if( filtradas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada com esse filtro.");
            }
            else
            {
                Console.WriteLine($"Tarefas({filtro}):");
                ExibirTarefas(filtradas);
            }
        }

    }
}
