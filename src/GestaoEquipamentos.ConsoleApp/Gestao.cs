namespace GestaoEquipamentos.ConsoleApp
{
    public partial class Gestao
    {
        //atributos 
        public Itens[] itens = new Itens[20];

        //atributo contador
        public Contador contadorGestao = new Contador();

        public void Inserir()
        {
            Itens item = new Itens();
            Console.Clear();
            item.id = contadorGestao.contador;
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
            itens[contadorGestao.contador] = item;
            contadorGestao.IncrementaContador();

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
            var lista = itens.ToList();

            lista.RemoveAt(id);

            itens = lista.ToArray();
        }

        public bool VerificarItens()
        {
            bool auxiliar = false;
            Itens[] produtos = new Itens[0];

            produtos = ListaItens();
            for (int i = 0; i < produtos.Length; i++)
            {
                Itens itens = produtos[i];
                if (itens != null)
                    auxiliar = true;
            }

            return auxiliar;
        }
    }
}