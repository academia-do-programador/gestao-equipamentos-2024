using System.Runtime.CompilerServices;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gestao gestao = new Gestao();

            string teste = "";

            Menus menus = new Menus();

            GerenciaChamados chamados = new GerenciaChamados();

            int option = 0;

            while (option != 3)
            {
                menus.MenuInicial();
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
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

                        break;

                    case 2:

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
                        break;
                }
            }
        }
    }
}
