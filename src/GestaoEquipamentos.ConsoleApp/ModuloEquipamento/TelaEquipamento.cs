using GestaoEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    public class TelaEquipamento : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Equipamentos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10}",
                "Id", "Nome", "Fabricante", "Preço", "Data de Fabricação"
            );

            EntidadeBase[] equipamentosCadastrados = repositorio.SelecionarTodos();

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

        protected override EntidadeBase ObterRegistro()
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

        public void RegistrarEquipamentoTeste()
        {
            DateTime dataDoisAnosAtras = DateTime.Now.AddYears(-2);

            Equipamento equipTest = new Equipamento("Notebook", "AEX-120", "Acer", 2000.00m, dataDoisAnosAtras);

            repositorio.Cadastrar(equipTest);
        }
    }
}
