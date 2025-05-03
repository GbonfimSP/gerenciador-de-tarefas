using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
