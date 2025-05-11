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
        string entrada = Console.ReadLine();

        // Tratamento de erro caso o usuário digite uma entrada diferente do tipo int
        if(!int.TryParse(entrada, out int opcao)) {
            Console.WriteLine("Entrada inválida. Tente novamente e digite um número...");
            Thread.Sleep(1500);
            GerenciadorTarefas();
            return;
        }

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
        Console.WriteLine("Tarefa adicionada a lista com sucesso! O que mais você deseja fazer?");
        Console.WriteLine("[1] - Voltar ao Home");
        Console.WriteLine("[2] - Cadastrar mais tarefas");
        string entrada = Console.ReadLine();

        if(!int.TryParse(entrada, out int opcao)) {
            Console.WriteLine("Entrada inválida. Você será redirecionado ao Home...");
            Thread.Sleep(1500);
            GerenciadorTarefas();
            return;
        }

        switch(opcao) {
            case 1:
                GerenciadorTarefas();
                break;
            case 2:
                CadastrarTarefa();
                break;
            default :
                Console.WriteLine("Entrada inválida. Você será redirecionado ao Home...");
                Thread.Sleep(1500);
                GerenciadorTarefas();
                break;
        }
    }

    static void ListaTarefa() {

        if(list.Count == 0) {
            Console.WriteLine("Ainda sem tarefas. Cadastre uma tarefa para visualizar.");
            Thread.Sleep(1500);

            GerenciadorTarefas();
            return;
        }

        Console.WriteLine("Inciando listagem dos elementos...");
        Thread.Sleep(1500);

        Console.WriteLine(" ");
        foreach((int id, string tarefa) in list) {
            Console.WriteLine($"Tarefa {id}: {tarefa}");
        }

        Console.WriteLine("Listagem completa. O que mais você deseja fazer?");
        Console.WriteLine("[1] - Voltar ao Home");
        Console.WriteLine("[2] - Encerrar programa");
        string entrada = Console.ReadLine();

        if(!int.TryParse(entrada, out int opcao)) {
            Console.WriteLine("Entrada inválida. Você será redirecionado ao Home...");
            Thread.Sleep(1500);
            GerenciadorTarefas();
            return;
        }

        switch(opcao) {
            case 1:
                GerenciadorTarefas();
                break;
            case 2:
                EncerrarPrograma();
                break;
            default:
                Console.WriteLine("Entrada inválida. Você será redirecionado ao Home...");
                Thread.Sleep(1500);
                GerenciadorTarefas();
                break;
        }
    }

    static void AtualizaTarefa() {
        if(list.Count == 0) {
            Console.WriteLine("Ainda sem tarefas. Cadastre uma tarefa para atualizar.");
            Thread.Sleep(1500);

            GerenciadorTarefas();
            return;
        }

        Console.Write("Digite o id da tarefa que você deseja atualizar: ");
        string entrada = Console.ReadLine();

        if(!int.TryParse(entrada, out int idProjeto)) {
            Console.WriteLine("ID inválido. Digite o NÚMERO do ID.");
            Thread.Sleep(1000);
            AtualizaTarefa();
            return;
        }

        int index = list.FindIndex(t => t.Item1 == idProjeto); // Esta variável está armazenando todo o elemento que o id seja: == idProjeto que está dentro de list
        if(index == -1) { // Significa que o id não foi encontrado na list
            Console.WriteLine("Tarefa não encontrada. Tente novamente.");
            Thread.Sleep(1000);

            AtualizaTarefa();
            return;
        }

        Console.Write($"Agora escreva uma nova descrição para a tarefa {idProjeto}: ");
        string novaDescricao = Console.ReadLine();

        //Está pegando a posição que corresponde ao index e sobrescrenvendo a antiga descrição pela nova descrição (mantem o idProjeto)
        list[index] = Tuple.Create(idProjeto, novaDescricao);
        Console.WriteLine("Tarefa atualizada com sucesso!");
        Thread.Sleep(1500);
        GerenciadorTarefas();
    }

    static void ExcluiTarefa() {
        if(list.Count == 0) {
            Console.WriteLine("Ainda sem tarefas. Cadastre uma tarefa para excluir.");
            Thread.Sleep(1500);

            GerenciadorTarefas();
            return;
        }

        Console.Write("Digite o id da tarefa que você deseja excluir: ");
        string entrada = Console.ReadLine();

        if(!int.TryParse(entrada, out int idProjeto)) {
            Console.WriteLine("ID inválido. Digite o NÚMERO do ID.");
            Thread.Sleep(1000);
            ExcluiTarefa();
            return;
        }

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