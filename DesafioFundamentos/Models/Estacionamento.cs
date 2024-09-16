namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Método para adicionar um veículo
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            // Adiciona a placa à lista de veículos
            veiculos.Add(placa);
            Console.WriteLine($"Veículo de placa {placa} foi estacionado.");
        }

        // Método para remover um veículo e calcular o valor total a ser pago
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine()!.ToUpper();

            // Verifica se o veículo existe no estacionamento
            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas;
        
                // Captura a quantidade de horas estacionadas e valida o input
                while (!int.TryParse(Console.ReadLine(), out horas) || horas <= 0)
                {
                    Console.WriteLine("Por favor, insira um valor válido para as horas:");
                }

                // Calcula o valor total (preço inicial + preço por hora * horas)
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // Remove o veículo da lista (garantindo a comparação de placas sem distinção de maiúsculas/minúsculas)
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }


        // Método para listar todos os veículos estacionados
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
        
                // Exibe cada veículo estacionado
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
