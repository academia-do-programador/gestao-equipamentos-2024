using System.Runtime.CompilerServices;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gestao gestao = new Gestao();

            int option = 0;

            while (option != 3)
            {
                gestao.menus.MenuInicial();
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        int optionItem = 0;
                        while (optionItem != 5)
                        {
                            gestao.menus.MenuLista();
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
                        Console.WriteLine("Recurso ainda não disponível");
                        Console.ReadLine();
                        continue;
                }
            }
        }
    }
}
