using GestaoEquipamentos.ConsoleApp.Compartilhado;
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

            telaEquipamento.RegistrarEquipamentoTeste();

            RepositorioChamado repositorioChamado = new RepositorioChamado();

            TelaChamado telaChamado = new TelaChamado();
            telaChamado.tipoEntidade = "Chamado";
            telaChamado.repositorio = repositorioChamado;

            telaChamado.repositorioEquipamento = repositorioEquipamento;
            telaChamado.telaEquipamento = telaEquipamento;

            telaChamado.RegistrarChamadoTeste();

            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = ObterTela(telaEquipamento, telaChamado, opcaoPrincipalEscolhida);

                char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);
            }

            Console.ReadLine();
        }

        static TelaBase ObterTela(TelaEquipamento telaEquipamento, TelaChamado telaChamado, char opcaoPrincipalEscolhida)
        {
            TelaBase tela = null;

            if (opcaoPrincipalEscolhida == '1')
                tela = telaEquipamento;

            else if (opcaoPrincipalEscolhida == '2')
                tela = telaChamado;

            return tela;
        }
    }
}