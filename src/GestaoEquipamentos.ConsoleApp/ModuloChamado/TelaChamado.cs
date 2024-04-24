using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado
    {
        RepositorioChamado repositorioChamado = new RepositorioChamado();

        public TelaEquipamento telaEquipamento = null;

        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Chamados            |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Chamado");
            Console.WriteLine("2 - Editar Chamado");
            Console.WriteLine("3 - Excluir Chamado");
            Console.WriteLine("4 - Visualizar Chamados");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public void CadastrarChamado()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Chamados            |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Cadastrando Chamado...");

            Console.WriteLine();

            Chamado novoChamado = ObterChamado();

            string[] erros = novoChamado.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            repositorioChamado.CadastrarChamado(novoChamado);

            Program.ExibirMensagem("O chamado foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void EditarChamado()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Chamados            |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Editando Chamado...");

            VisualizarChamados(false);

            Console.Write("Digite o ID do chamado que deseja editar: ");
            int idChamadoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorioChamado.ExisteChamado(idChamadoEscolhido))
            {
                Program.ExibirMensagem("O chamado mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();

            Chamado novoChamado = ObterChamado();

            string[] erros = novoChamado.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuEditar = repositorioChamado.EditarChamado(idChamadoEscolhido, novoChamado);

            if (!conseguiuEditar)
            {
                Program.ExibirMensagem("Houve um erro durante a edição de chamado", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O chamado foi editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirChamado()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Chamados            |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Excluindo Chamado...");

            Console.WriteLine();

            VisualizarChamados(false);

            Console.Write("Digite o ID do chamado que deseja excluir: ");
            int idChamadoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorioChamado.ExisteChamado(idChamadoEscolhido))
            {
                Program.ExibirMensagem("O chamado mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = repositorioChamado.ExcluirChamado(idChamadoEscolhido);

            if (!conseguiuExcluir)
            {
                Program.ExibirMensagem("Houve um erro durante a exclusão do chamado", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O chamado foi excluído com sucesso!", ConsoleColor.Green);
        }

        private Chamado ObterChamado()
        {
            telaEquipamento.VisualizarEquipamentos(false);

            bool conseguiuConverter = false;

            int idEquipamento = 0;

            while (!conseguiuConverter)
            {
                Console.Write("Digite o ID do equipamento defeituoso: ");
                conseguiuConverter = int.TryParse(Console.ReadLine(), out idEquipamento);

                if (!conseguiuConverter)
                    Console.WriteLine("Por favor, informe um ID válido!\n");
            }

            Equipamento equipamentoSelecionado = (Equipamento)telaEquipamento.repositorio.SelecionarPorId(idEquipamento);

            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            Chamado novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado);

            return novoChamado;
        }

        public void VisualizarChamados(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("|        Gestão de Chamados            |");
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();

                Console.WriteLine("Visualizando Chamados...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                "Id", "Título", "Equipamento", "Dias em Aberto"
            );

            Chamado[] chamadosCadastrados = repositorioChamado.SelecionarChamados();

            for (int i = 0; i < chamadosCadastrados.Length; i++)
            {
                Chamado e = chamadosCadastrados[i];

                if (e == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                    e.Id, e.Titulo, e.EquipamentoSelecionado.Nome, e.QuantidadeDiasEmAberto
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        private void ApresentarErros(string[] erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
                Console.WriteLine(erros[i]);

            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
