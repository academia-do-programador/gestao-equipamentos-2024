using GestaoEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoEquipamentos.ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {       
        TelaPrincipal telaPrincipal = new TelaPrincipal();

        while (true)
        {
            telaPrincipal.ApresentarMenu();

            if (telaPrincipal.OpcaoSairSelecionada())
                break;

            TelaBase tela = telaPrincipal.ObterTela();

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
}