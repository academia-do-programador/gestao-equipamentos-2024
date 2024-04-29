using GestaoEquipamentos.ConsoleApp.ModuloChamado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();

            TelaEquipamento telaEquipamento = new TelaEquipamento();
            telaEquipamento.tipoEntidade = "Equipamento";
            telaEquipamento.repositorio = repositorioEquipamento;

            telaEquipamento.RegistrarEquipamentosTeste();

            RepositorioChamado repositorioChamado = new RepositorioChamado();

            TelaChamado telaChamado = new TelaChamado();
            telaChamado.tipoEntidade = "Chamado";
            telaChamado.repositorio = repositorioChamado;

            telaChamado.repositorioEquipamento = repositorioEquipamento;
            telaChamado.telaEquipamento = telaEquipamento;

            bool opcaoSairEscolhida = false;

            while (!opcaoSairEscolhida)
            {
                char opcaoPrincipalEscolhida = ApresentarMenuPrincipal();
                char operacaoEscolhida;

                switch (opcaoPrincipalEscolhida)
                {
                    case '1':
                        operacaoEscolhida = telaEquipamento.ApresentarMenu();

                        if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                            break;

                        if (operacaoEscolhida == '1')
                            telaEquipamento.Registrar();

                        else if (operacaoEscolhida == '2')
                            telaEquipamento.Editar();

                        else if (operacaoEscolhida == '3')
                            telaEquipamento.Excluir();

                        else if (operacaoEscolhida == '4')
                            telaEquipamento.VisualizarRegistros(true);

                        break;

                    case '2':
                        operacaoEscolhida = telaChamado.ApresentarMenu();

                        if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                            break;

                        if (operacaoEscolhida == '1')
                            telaChamado.Registrar();

                        if (operacaoEscolhida == '2')
                            telaChamado.Editar();

                        if (operacaoEscolhida == '3')
                            telaChamado.Excluir();

                        else if (operacaoEscolhida == '4')
                            telaChamado.VisualizarRegistros(true);

                        break;

                    default: opcaoSairEscolhida = true; break;
                }
            }

            Console.ReadLine();
        }

        private static char ApresentarMenuPrincipal()
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

            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }

        public static void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
