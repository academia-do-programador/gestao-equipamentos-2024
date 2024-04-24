using GestaoEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    public class TelaEquipamento
    {
        public RepositorioEquipamento repositorio = new RepositorioEquipamento();

        public TelaEquipamento()
        {
            Equipamento equipTest = new Equipamento("Notebook", "AEX-120", "Acer", 2000.00m, DateTime.Now);

            repositorio.Cadastrar(equipTest);
        }

        public char ApresentarMenu()
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

            return operacaoEscolhida;
        }

        public void CadastrarEquipamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Equipamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Cadastrando Equipamento...");

            Console.WriteLine();

            Equipamento equipamento = ObterEquipamento();

            string[] erros = equipamento.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            repositorio.Cadastrar(equipamento);

            Program.ExibirMensagem("O equipamento foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        private void ApresentarErros(string[] erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
                Console.WriteLine(erros[i]);

            Console.ResetColor();
            Console.ReadLine();
        }

        public void EditarEquipamento()
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

            if (!repositorio.Existe(idEquipamentoEscolhido))
            {
                Program.ExibirMensagem("O equipamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();

            Equipamento equipamento = ObterEquipamento();

            string[] erros = equipamento.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuEditar = repositorio.Editar(idEquipamentoEscolhido, equipamento);

            if (!conseguiuEditar)
            {
                Program.ExibirMensagem("Houve um erro durante a edição de equipamento", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O equipamento foi editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirEquipamento()
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
            int idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.Existe(idEquipamentoEscolhido))
            {
                Program.ExibirMensagem("O equipamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = repositorio.Excluir(idEquipamentoEscolhido);

            if (!conseguiuExcluir)
            {
                Program.ExibirMensagem("Houve um erro durante a exclusão do equipamento", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O equipamento foi excluído com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarEquipamentos(bool exibirTitulo)
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

            Entidade[] equipamentosCadastrados = repositorio.SelecionarTodos();

            // casting / cast
            foreach (Equipamento equip in equipamentosCadastrados)
            {
                if (equip == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10}",
                    equip.Id, equip.Nome, equip.Fabricante, equip.PrecoAquisicao, equip.DataFabricacao.ToShortDateString() // "17/04/2024"
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        private Equipamento ObterEquipamento()
        {
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
            return equipamento;
        }
    }
}
