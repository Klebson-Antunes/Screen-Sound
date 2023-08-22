// Screen Sound
string mensagemDeBoasVindas = "Boas Vindas ao Screen Sound";
//List<string> listaBandas = new List<string>() {"Malta", "Dejavu", "Calçinha Preta"};

// Dicionario para registar bandas e notas para as bandas
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Malta", new List<int>());
bandasRegistradas.Add("Evanescence", new List<int>());
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 6, 7, 1});

// Logo da aplicação
void ExibirLogo()
{
    Console.WriteLine(@"
█████████████████████████████████████████████████████████████████████████
█─▄▄▄▄█─▄▄▄─█▄─▄▄▀█▄─▄▄─█▄─▄▄─█▄─▀█▄─▄███─▄▄▄▄█─▄▄─█▄─██─▄█▄─▀█▄─▄█▄─▄▄▀█
█▄▄▄▄─█─███▀██─▄─▄██─▄█▀██─▄█▀██─█▄▀─████▄▄▄▄─█─██─██─██─███─█▄▀─███─██─█
▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▀▀▄▄▀▀▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀");
    Console.WriteLine("\nBoas vindas ao Screen Sound\n");
}


// Menu De Opções
void ExibirOpcoesDoMenu()
{
    Console.Clear();

    ExibirLogo();
    ExibirTituloDaOpcao("Menu de opções");
    Console.WriteLine("1 - Registrar uma banda");
    Console.WriteLine("2 - Exibir todas as bandas");
    Console.WriteLine("3 - Avaliar uma banda");
    Console.WriteLine("4 - Exibir a média das bandas");
    Console.WriteLine("5 - Para sair");

    Console.Write("\nDigite a opção escolhida: ");
    int opcaoEscolhida = Convert.ToInt32(Console.ReadLine()!);

    switch (opcaoEscolhida)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            ExibirTodasAsBandas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            ExibirMediaDasBandas();
            break;
        case 5:
            Console.WriteLine("Volte sempre!");
            break;
        default:
            Console.WriteLine("Opção errada!");
            break;
    }
}


// Registrar uma banda
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Regitrar bandas");
    Console.Write("Digite o nome da Banda: ");
    string nomeBanda = Console.ReadLine()!;

    bandasRegistradas.Add(nomeBanda, new List<int>());

    Console.WriteLine($"Banda '{nomeBanda}' foi adicionada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

// Exibe a lista de bandas
void ExibirTodasAsBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Lista de bandas");
    Console.WriteLine("\nLista de Todas as Bandas: \n");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite Qualque tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

// Exibe o titulo de cada opção
void ExibirTituloDaOpcao(string tituloDaOpcao)
{
    int quantidadeDeCaracter = tituloDaOpcao.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeCaracter, '*');

    Console.WriteLine($"\n{asteriscos}");
    Console.WriteLine(tituloDaOpcao);
    Console.WriteLine($"{asteriscos}\n");
}


// Avaliar banda
void AvaliarUmaBanda()
{ 
    // digite o nome da banda para avaliar
    // verifica se a banda esta na lista , se sim add uma nota a ele
    // se nao volte ao menu principal
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar uma banda");

    Console.Write("Digite o nome da banda que gostaria de avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Que nota a banda {nomeDaBanda} merece: ");
        int nota = Convert.ToInt32(Console.ReadLine()!);

        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} fui atribuida a banda {nomeDaBanda} com sucesso!");
        Thread.Sleep(3000);
        ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine($"Banda {nomeDaBanda} não esta na lista !");
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        ExibirOpcoesDoMenu();
    }

}


void ExibirMediaDasBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir Média de notas das bandas");

    Console.Write("Digite o nome da banda para ver sua média: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        //double media = 0;
        //int somaDasNotas = 0;
        //foreach (int nota in bandasRegistradas[nomeDaBanda])
        //{
        //    somaDasNotas += nota;
        //    media = somaDasNotas / bandasRegistradas[nomeDaBanda].Count;
        //}

        // refatorando

        double media = 0;
        // cria uma lista com as notas
        List<int> notasBandas = bandasRegistradas[nomeDaBanda];
        media = notasBandas.Average(); // o metodo average calcula a media das notas

        Console.WriteLine($"A média das notas da banda {nomeDaBanda} e {media}.");
        Console.WriteLine("\nPrecione qualquer tecla para ir ao menu inicial");
        Console.ReadKey();
        ExibirOpcoesDoMenu();

    }
    else
    {
        Console.WriteLine($"Banda {nomeDaBanda} não esta na lista !");
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        ExibirOpcoesDoMenu();
    }

}

ExibirOpcoesDoMenu();