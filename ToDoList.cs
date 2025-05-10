using System;
class ToDoList
{
    static List<Tuple<int, string>> list = new List<Tuple<int, string>>();
    static int idTarefa = 1;
    static void Main(string[] args) {
        GerenciadorTarefas();
    }

    static void GerenciadorTarefas() {
        Console.Clear();
        Console.WriteLine("Bem-vindo(a) ao sistema que organiza suas listas de tarefas");
        Thread.Sleep(1000);
        Console.WriteLine("");

        Console.WriteLine("Digite sua opção para iniciar uma operação: ");
        Console.WriteLine("[1] - Cadastrar nova Tarefa");
        Console.WriteLine("[2] - Listar Tarefas");
        Console.WriteLine("[3] - Atualizar Tarefa Cadastrada");
        Console.WriteLine("[4] - Excluir Tarefa");
        Console.WriteLine("[5] - Encerrar Programa");
        int opcao = int.Parse(Console.ReadLine());

        switch (opcao) {
            case 1: // Cadastra Tarefa
                Console.Clear();
                CadastrarTarefa();
                break;
            case 2: // Lista Tarefa
                Console.Clear();
                ListaTarefa();
                break;
            case 3: // Atualiza Tarefa
                Console.Clear();
                AtualizaTarefa();
                break;
            case 4: // Exclui Tarefa
                Console.Clear();
                ExcluiTarefa();
                break;
            case 5 :
                Console.Clear();
                EncerrarPrograma();
                break;
            default: // Para entradas inválidas
                Console.WriteLine("Opção inválida. Tente novamente!");
                Thread.Sleep(1500);
                GerenciadorTarefas();
                break;
        }
    }

    static void CadastrarTarefa() {
        Console.Write("Descreva sua tarefa de forma curta e objetiva: ");
        string descricaoTarefa = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(descricaoTarefa)) {
            Console.WriteLine("Entrada inválida. Tente Novamente!");
            Thread.Sleep(1500);
            
            GerenciadorTarefas();
            return;
        }

        list.Add(Tuple.Create(idTarefa, descricaoTarefa));
        idTarefa++;
        Console.WriteLine("Tarefa adicionada a lista com sucesso!");
        Console.WriteLine("Você será encaminhado ao home.");
        Thread.Sleep(1500);

        GerenciadorTarefas();
    }

    static void ListaTarefa() {

        if(list.Count == 0) {
            Console.WriteLine("Ainda sem tarefas. Cadastre uma tarefa para visualizar");
            Thread.Sleep(1500);

            GerenciadorTarefas();
            return;
        }

        Console.WriteLine("Inciando listagem dos elementos...");
        Thread.Sleep(1500);

        foreach((int id, string tarefa) in list) {
            Console.WriteLine($"Tarefa {id}: {tarefa}");
        }

        Console.WriteLine("Listagem completa. Você será redirecionado ao home.");
        Thread.Sleep(2000);

        GerenciadorTarefas();
    }

    static void AtualizaTarefa() {
    }

    static void ExcluiTarefa() {
        if(list.Count == 0) {
            Console.WriteLine("Ainda sem tarefas. Cadastre uma tarefa para excluir");
            Thread.Sleep(1500);

            GerenciadorTarefas();
            return;
        }

        Console.Write("Digite qual o id da tarefa que você deseja excluir: ");
        int idProjeto = int.Parse(Console.ReadLine());

        var tarefaParaRemover = list.FirstOrDefault(t => t.Item1 == idProjeto);
        if(tarefaParaRemover == default) {
            Console.WriteLine("Tarefa não encontrada. Tente novamente.");
            Thread.Sleep(1000);

            ExcluiTarefa();
            return;
        }

        list.Remove(tarefaParaRemover);
        Console.WriteLine("Tarefa removida com sucesso. Você será redirecionado ao home");
        Thread.Sleep(1500);
        GerenciadorTarefas();
    }

    static void EncerrarPrograma() {
        Console.WriteLine("Programa encerrado. Até mais...👋");
    }
}