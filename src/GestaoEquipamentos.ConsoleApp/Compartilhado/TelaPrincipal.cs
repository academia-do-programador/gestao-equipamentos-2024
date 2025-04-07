using GestaoEquipamentos.ConsoleApp.ModuloChamado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.Compartilhado
{
    public class TelaPrincipal
    {
        private char opcaoEscolhida;
        private TelaEquipamento telaEquipamento;
        private TelaChamado telaChamado;

        public TelaPrincipal()
        {
            RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();

            telaEquipamento = new TelaEquipamento();
            telaEquipamento.tipoEntidade = "Equipamento";
            telaEquipamento.repositorio = repositorioEquipamento;

            Equipamento equipamento = new Equipamento("Notebook", "AEX-120", "Acer", 2000.00m, DateTime.Now.AddYears(-1));
            repositorioEquipamento.Cadastrar(equipamento);

            RepositorioChamado repositorioChamado = new RepositorioChamado();

            telaChamado = new TelaChamado();
            telaChamado.tipoEntidade = "Chamado";
            telaChamado.repositorio = repositorioChamado;

            telaChamado.repositorioEquipamento = repositorioEquipamento;
            telaChamado.telaEquipamento = telaEquipamento;                        

            repositorioChamado.Cadastrar(new Chamado("Tela quebrada", "A tela do notebook não está ligando", equipamento, DateTime.Now));
        }       

        public void ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Equipamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Gerência de Equipamentos");
            Console.WriteLine("2 - Gerência de Chamados");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            opcaoEscolhida = Console.ReadLine()[0];            
        }

        public TelaBase ObterTela()
        {
            TelaBase tela = null;

            if (opcaoEscolhida == '1')
                tela = telaEquipamento;

            else if (opcaoEscolhida == '2')
                tela = telaChamado;

            return tela;
        }

        public bool OpcaoSairSelecionada()
        {
            return opcaoEscolhida == 'S' || opcaoEscolhida == 's';
        }
    }
}
