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

                if (opcaoPrincipalEscolhida == '1')
                {                    
                    char operacaoEscolhida = telaEquipamento.ApresentarMenu();

                    if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                        continue;

                    if (operacaoEscolhida == '1')
                        telaEquipamento.Registrar();

                    else if (operacaoEscolhida == '2')
                        telaEquipamento.Editar();

                    else if (operacaoEscolhida == '3')
                        telaEquipamento.Excluir();

                    else if (operacaoEscolhida == '4')
                        telaEquipamento.VisualizarRegistros(true);
                }
                else if (opcaoPrincipalEscolhida == '2')
                {
                    char operacaoEscolhida = telaChamado.ApresentarMenu();

                    if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                        continue;

                    if (operacaoEscolhida == '1')
                        telaChamado.Registrar();

                    else if (operacaoEscolhida == '2')
                        telaChamado.Editar();

                    else if (operacaoEscolhida == '3')
                        telaChamado.Excluir();

                    else if (operacaoEscolhida == '4')
                        telaChamado.VisualizarRegistros(true);
                }             
            }

            Console.ReadLine();
        }      
    }
}