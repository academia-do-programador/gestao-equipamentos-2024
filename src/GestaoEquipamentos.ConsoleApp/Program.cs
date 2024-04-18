using System.Runtime.CompilerServices;
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

            if (gestao.VerificarItens())
            {
                while (optionChamado != 5)
                {
                    menus.MenuChamado();
                    optionChamado = Convert.ToInt32(Console.ReadLine());

                    switch (optionChamado)
                    {
                        case 1:
                            gestao.Inserir();
                            break;

                        case 2:
                            gestao.MostraLista();
                            Console.ReadLine();
                            break;

                        case 3:
                            gestao.Editar();
                            break;

                        case 4:
                            gestao.Excluir();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Você não possui nenhum produto cadastrado.");
                Console.ReadLine();
            }
        }

        private static void GestaoEquipamento(TelaEquipamento gestao, Menus menus)
        {
            int optionItem = 0;
            while (optionItem != 5)
            {
                menus.MenuItens();
                optionItem = Convert.ToInt32(Console.ReadLine());

                switch (optionItem)
                {
                    case 1:
                        gestao.Inserir();
                        break;

                    case 2:
                        gestao.MostraLista();
                        Console.ReadLine();
                        break;

                    case 3:
                        gestao.Editar();
                        break;

                    case 4:
                        gestao.Excluir();
                        break;
                }


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

    }
}
