using System.ComponentModel.Design;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static Equipamento[] equipamentos = new Equipamento[100];
        static int contadorEquipamentosCadastrados = 0;

        static void Main(string[] args)
        {
            Equipamento equipTest = new Equipamento("Notebook", "AEX-120", "Acer", 2000.00m, DateTime.Now);
            equipTest.Id = GeradorId.GerarIdEquipamento();

            equipamentos[contadorEquipamentosCadastrados++] = equipTest;

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

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            switch(operacaoEscolhida)
            {
                case '1': CadastrarEquipamento(); break;
                case '2': EditarEquipamento(); break;
                case '3': ExcluirEquipamento(); break;
                case '4': VisualizarEquipamentos(true); break;

                default: break;
            }
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

            Console.Write("Digite a data de fabricação do equipamento (formato: dd/MM/aaaa): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento equipamento = new Equipamento(nome, numeroSerie, fabricante, precoAquisicao, dataFabricacao);
            equipamento.Id = GeradorId.GerarIdEquipamento();

            equipamentos[contadorEquipamentosCadastrados++] = equipamento;

            ExibirMensagem("O equipamento foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        static void VisualizarEquipamentos(bool exibirTitulo)
        {

            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("|        Gestão de Equipamentos        |");
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();

                Console.WriteLine("Visualizando Equipamentos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10}",
                "Id", "Nome", "Fabricante", "Preço", "Data de Fabricação"
            );

            for (int i = 0; i < equipamentos.Length; i++) 
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10}",
                    e.Id, e.Nome, e.Fabricante, e.PrecoAquisicao, e.DataFabricacao.ToShortDateString() // "17/04/2024"
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        public static void EditarEquipamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Equipamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Editando Equipamento...");

            Console.WriteLine();

            VisualizarEquipamentos(false);

            Console.Write("Digite o ID do equipamento que deseja editar: ");
            int idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!EquipamentoExiste(idEquipamentoEscolhido))
            {
                ExibirMensagem("O equipamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

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

            Equipamento novoEquipamento =
                new Equipamento(nome, numeroSerie, fabricante, precoAquisicao, dataFabricacao);

            novoEquipamento.Id = idEquipamentoEscolhido;

            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null)
                    continue;

                else if (equipamentos[i].Id == idEquipamentoEscolhido)
                {
                    equipamentos[i] = novoEquipamento;
                    break;
                }
            }

            ExibirMensagem("O equipamento foi editado com sucesso!", ConsoleColor.Green);
        }

        public static void ExcluirEquipamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Equipamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Excluindo Equipamento...");

            Console.WriteLine();

            VisualizarEquipamentos(false);

            Console.Write("Digite o ID do equipamento que deseja excluir: ");
            int equipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!EquipamentoExiste(equipamentoEscolhido))
            {
                ExibirMensagem("O equipamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null)
                    continue;

                else if (equipamentos[i].Id == equipamentoEscolhido)
                {
                    equipamentos[i] = null;
                    break;
                }
            }

            ExibirMensagem("O equipamento foi excluído com sucesso!", ConsoleColor.Green);
        }

        public static bool EquipamentoExiste(int idEquipamento)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                else if (e.Id == idEquipamento)
                    return true;
            }

            return false;
        }

        public static Equipamento EncontrarEquipamentoPorId(int idEscolhido)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                if (e.Id == idEscolhido)
                    return e;
            }

            return null;
        }

        static void GerenciarChamados()
        {

        }

        private static void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
