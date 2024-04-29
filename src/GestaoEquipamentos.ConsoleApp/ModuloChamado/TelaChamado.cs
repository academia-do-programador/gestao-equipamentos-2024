using GestaoEquipamentos.ConsoleApp.Compartilhado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado : TelaBase
    {
        public RepositorioEquipamento repositorioEquipamento = null;
        public TelaEquipamento telaEquipamento = null;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();
                Console.WriteLine("Visualizando Chamados...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                "Id", "Título", "Equipamento", "Dias em Aberto"
            );

            EntidadeBase[] chamadosCadastrados = repositorio.SelecionarTodos();

            foreach (Chamado chamado in chamadosCadastrados)
            {
                if (chamado == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                    chamado.Id, chamado.Titulo, chamado.EquipamentoSelecionado.Nome, chamado.QuantidadeDiasEmAberto
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaEquipamento.VisualizarRegistros(false);

            bool conseguiuConverter = false;

            int idEquipamento = 0;

            while (!conseguiuConverter)
            {
                Console.Write("Digite o ID do equipamento defeituoso: ");
                conseguiuConverter = int.TryParse(Console.ReadLine(), out idEquipamento);

                if (!conseguiuConverter)
                    Console.WriteLine("Por favor, informe um ID válido!\n");
            }

            Equipamento equipamentoSelecionado = (Equipamento)repositorioEquipamento.SelecionarPorId(idEquipamento);

            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            Chamado novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado);

            return novoChamado;
        }

    }
}
