using System.Runtime.CompilerServices;

namespace GestaoEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gestao gestao = new Gestao();
            Itens[] produtos = new Itens[0];
            int option = 0;

            while (option != 3)
            {
                Console.Clear();
                Console.WriteLine("Gestão de equipamentos");
                Console.WriteLine("Digite 1 - Para a gestão dos equipamentos.");
                Console.WriteLine("Digite 2 - Para gestão de chamados.");
                Console.WriteLine("Digite 3 - Para sair");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        int optionItem = 0;
                        while (optionItem != 5)
                        {

                            Console.Clear();
                            Console.WriteLine("Gestão de equipamentos");
                            Console.WriteLine("Digite 1 - Inserir novo item.");
                            Console.WriteLine("Digite 2 - Visualizar itens.");
                            Console.WriteLine("Digite 3 - Editar item.");
                            Console.WriteLine("Digite 4 - Excluir item.");
                            Console.WriteLine("Digite 5 - Para sair");
                            optionItem = Convert.ToInt32(Console.ReadLine());

                            switch (optionItem)
                            {
                                case 1:
                                    gestao.Inserir();
                                break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Itens da lista");
                                    produtos = gestao.ListaItens();
                                    for (int i = 0; i < produtos.Length; i++)
                                    {
                                        Itens itens = produtos[i];
                                        if (itens != null)
                                            Console.WriteLine($"{itens.nome}, {itens.preco}, {itens.numeroSerie}, {itens.dataCriacao}, {itens.fabricante}");
                                    }
                                    Console.ReadLine();
                                    break;
                            }


                        }
                        
                    break;
                    
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Recurso ainda não disponível");
                        Console.ReadLine();
                        continue;
                    break;
                    
                   

                }
                

                Console.ReadLine();
            }
        }
    }

    public class Itens
    {
        public string nome = "";
        public decimal preco;
        public string numeroSerie = "";
        public string dataCriacao = "";
        public string fabricante = "";
    }

    public class Gestao
    {
        //atributos 
        public Itens[] itens = new Itens[100];
        public int contador = 0;

        public void Inserir()
        {
            Itens item = new Itens();
            Console.Clear();
            Console.WriteLine("Cadastro de equipamentos!");
            Console.WriteLine("Digite o nome do item: ");
            item.nome = Console.ReadLine();
            Console.WriteLine("Digite o preço do item: ");
            item.preco = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Digite o numero de série do item: ");
            item.numeroSerie = Console.ReadLine();
            Console.WriteLine("Digite a data de criação do item: ");
            item.dataCriacao = Console.ReadLine();
            Console.WriteLine("Digite o nome do fabricante do item: ");
            item.fabricante = Console.ReadLine();
            itens[contador] = item;
            contador++;
        }

        public Itens[] ListaItens()
        {
            return itens;
        }
    }
}
