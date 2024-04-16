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
                    break;
                }
            }
        }
    }

    public class Gestao
    {
        //atributos 
        public Itens[] itens = new Itens[100];
        public int contador = 0;

        //atributos menu
        public Menus menus = new Menus();

        public void Inserir()
        {
            Itens item = new Itens();
            Console.Clear();
            item.id = contador;
            Console.WriteLine("Cadastro de equipamentos!");
            Console.Write("Digite o nome do item: ");
            item.nome = Console.ReadLine();
            Console.Write("Digite o preço do item: ");
            item.preco = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Digite o numero de série do item: ");
            item.numeroSerie = Console.ReadLine();
            Console.Write("Digite a data de criação do item: ");
            item.dataCriacao = Console.ReadLine();
            Console.Write("Digite o nome do fabricante do item: ");
            item.fabricante = Console.ReadLine();
            itens[contador] = item;
            contador++;
            
        }

        public void MostraLista()
        {
            Itens[] produtos = new Itens[0];
            Console.Clear();
            Console.WriteLine("Itens da lista");
            Console.WriteLine($"ID | Nome | preco | Numerode Serie | Data de Fabricação | Fabricante");
            produtos = ListaItens();
            for (int i = 0; i < produtos.Length; i++)
            {
                Itens itens = produtos[i];
                if (itens != null)
                    Console.WriteLine($"{itens.id} | {itens.nome} | {itens.preco} | {itens.numeroSerie} | {itens.dataCriacao} | {itens.fabricante}");
            }
        }
        public Itens[] ListaItens()
        {
            return itens;
        }

        public void Editar()
        {
            int id = 0;
            Console.Clear();
            MostraLista();
            Console.WriteLine("Informe o id do produto que deseja editar: ");
            id = Convert.ToInt32(Console.ReadLine());
            Edicao(id);
        }
        public void Edicao(int id)
        {
            Itens item = new Itens();
            Console.Clear();
            item.id = id;
            Console.WriteLine("Edição de equipamentos!");
            Console.Write("Digite o nome do item: ");
            item.nome = Console.ReadLine();
            Console.Write("Digite o preço do item: ");
            item.preco = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Digite o numero de série do item: ");
            item.numeroSerie = Console.ReadLine();
            Console.Write("Digite a data de criação do item: ");
            item.dataCriacao = Console.ReadLine();
            Console.Write("Digite o nome do fabricante do item: ");
            item.fabricante = Console.ReadLine();
            itens[id] = item;

            itens.SetValue(item, id);
        }

        public void Excluir()
        {
            int id = 0;
            Console.Clear();
            MostraLista();
            Console.WriteLine("Informe o id do produto que deseja excluir: ");
            id = Convert.ToInt32(Console.ReadLine());
            Exclusao(id);

            Console.Clear();
            MostraLista();
            Console.ReadLine();
        }

        public void Exclusao(int id)
        {
            Itens[] produtos = new Itens[0];
            int ids = 0;
            var lista = itens.ToList();

            lista.RemoveAt(id);

            itens = lista.ToArray();

            for (int i = 0; i < produtos.Length; i++)
            {
                Itens itens = produtos[i];
                if (itens != null)
                    itens.id = contador; ids++;
            }
        }
    }
}
