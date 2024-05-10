using GestaoEquipamentos.ConsoleApp.ModuloChamado;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaEquipamento gestao = new TelaEquipamento();

            Menus menus = new Menus();

            TelaChamado chamados = new TelaChamado();

            int opcao = 0;

            while (opcao != 3)
            {
                opcao = MenuInicial();

                switch (opcao)
                {
                    case 1:
                        GestaoEquipamento(gestao, menus); break;

                    case 2:
                        GestaoChamado(gestao, menus); break;
                }
            }
        }

        private static void GestaoChamado(TelaEquipamento gestao, Menus menus)
        {
            Console.Clear();
            gestao.VerificarItens();
            int optionChamado = 0;

            while (optionChamado != 5)
            {
                if (gestao.VerificarItens() == false)
                {
                    ExibirMensagem("Você não possui nenhum produto cadastrado.", ConsoleColor.Red);
                    break;
                }

                menus.MenuChamado();
                optionChamado = Convert.ToInt32(Console.ReadLine());

                if (optionChamado == 1)
                    gestao.Inserir();

                if (optionChamado == 2)
                    gestao.MostraLista();

                if (optionChamado == 3)
                    gestao.Editar();

                if (optionChamado == 4)
                    gestao.Excluir();
            }


        }

        private static void GestaoEquipamento(TelaEquipamento gestao, Menus menus)
        {
            int opcaoEquipamento = 0;
            while (opcaoEquipamento != 5)
            {
                menus.MenuItens();
                opcaoEquipamento = Convert.ToInt32(Console.ReadLine());

                if (opcaoEquipamento == 1) gestao.Inserir();

                if (opcaoEquipamento == 2) gestao.MostraLista();

                if (opcaoEquipamento == 3) gestao.Editar();

                if (opcaoEquipamento == 4) gestao.Excluir();
            }
        }

        private static int MenuInicial()
        {
            int opcao;
            Console.Clear();
            Console.WriteLine("Gestão de equipamentos \nDigite 1 - Para a gestão dos equipamentos. \nDigite 2 - Para gestão de chamados. \nDigite 3 - Para sair");
            opcao = Convert.ToInt32(Console.ReadLine());
            return opcao;
        }

        public static void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
