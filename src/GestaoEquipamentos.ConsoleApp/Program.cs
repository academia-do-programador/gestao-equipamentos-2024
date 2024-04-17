namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static Equipamento[] equipamentos = new Equipamento[100];
        static int contadorEquipamentosCadastrados = 0;

        static void Main(string[] args)
        {
            bool opcaoSairEscolhida = false;

            while(!opcaoSairEscolhida)
            {
                Console.Clear();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("|        Gestão de Equipamentos        |");
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();

                Console.WriteLine("1 - Gerência de Equipamentos");
                Console.WriteLine("2 - Controle de Chamados [Não Disponível]");
                Console.WriteLine("S - Sair");

                Console.WriteLine();

                Console.Write("Escolha uma das opções: ");
                char opcaoEscolhida = Console.ReadLine()[0];

                switch(opcaoEscolhida)
                {
                    case '1': GerenciarEquipamentos(); break;
                    case '2': GerenciarChamados(); break;

                    default: opcaoSairEscolhida = true; break;
                }
            }

            Console.ReadLine();
        }

        static void GerenciarEquipamentos()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Equipamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Equipamento");
            Console.WriteLine("2 - Editar Equipamento");
            Console.WriteLine("3 - Excluir Equipamento");
            Console.WriteLine("4 - Visualizar Equipamentos");

            Console.WriteLine("S - Voltar");

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            switch(operacaoEscolhida)
            {
                case '1': CadastrarEquipamento(); break;
                case '2': break;
                case '3': break;
                case '4': break;

                default: break;
            }

            Console.ReadLine();
        }

        private static void CadastrarEquipamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Equipamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Cadastrando Equipamento...");

            Console.WriteLine();

            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o número de série do equipamento: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Digite o nome do fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            Console.Write("Digite o preço de aquisição do equipamento: R$ ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a data de fabricação do equipamento (formato: dd-MM-aaaa): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento equipamento = new Equipamento(nome, numeroSerie, fabricante, precoAquisicao, dataFabricacao);

            equipamentos[contadorEquipamentosCadastrados++] = equipamento;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();

            Console.WriteLine("O equipamento foi cadastrado com sucesso!");

            Console.ResetColor();

            Console.ReadLine();
        }

        static void GerenciarChamados()
        {

        }
    }
}
