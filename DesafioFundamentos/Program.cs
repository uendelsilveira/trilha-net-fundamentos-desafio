using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial;
decimal precoPorHora;

// Função auxiliar para obter valores decimais do usuário, com validação
decimal ObterDecimal(string mensagem)
{
    decimal valor;
    Console.WriteLine(mensagem);

    // Loop até que o usuário insira um valor decimal válido
    while (!decimal.TryParse(Console.ReadLine(), out valor) || valor < 0)
    {
        Console.WriteLine("Valor inválido. Por favor, digite um número decimal positivo.");
    }

    return valor;
}

// Função para aguardar interação do usuário entre as opções
void AguardarTecla()
{
    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
}

// Obtém o preço inicial e o preço por hora, com validação de input
precoInicial = ObterDecimal("Digite o preço inicial do estacionamento:");
precoPorHora = ObterDecimal("Agora digite o preço por hora do estacionamento:");

// Instancia a classe Estacionamento com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao;
bool exibirMenu = true;

// Loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("=== Sistema de Estacionamento ===");
    Console.WriteLine("Selecione uma opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            Console.WriteLine("Encerrando o sistema. Obrigado por utilizar!");
            break;

        default:
            Console.WriteLine("Opção inválida. Por favor, escolha uma das opções válidas no menu.");
            break;
    }

    // Aguarda o usuário pressionar uma tecla antes de limpar a tela
    if (opcao != "4")
    {
        AguardarTecla();
    }
}

Console.WriteLine("O programa foi encerrado.");