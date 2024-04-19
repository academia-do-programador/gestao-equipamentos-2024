using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp
{
    public partial class TelaEquipamento
    {
        //atributos 
        public Equipamento[] equipamento = new Equipamento[20];

        //atributo contador
        public Contador contadorGestao = new Contador();

        public void Inserir()
        {
            Equipamento novoEquipamento = new Equipamento();
            Console.Clear();
            novoEquipamento.id = contadorGestao.contador;
            Console.WriteLine("Cadastro de equipamentos!");
            Console.Write("Digite o nome do item: ");
            novoEquipamento.nome = Console.ReadLine();
            Console.Write("Digite o preço do item: ");
            novoEquipamento.preco = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Digite o numero de série do item: ");
            novoEquipamento.numeroSerie = Console.ReadLine();
            Console.Write("Digite a data de criação do item: ");
            novoEquipamento.dataCriacao = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Digite o nome do fabricante do item: ");
            novoEquipamento.fabricante = Console.ReadLine();
            equipamento[contadorGestao.contador] = novoEquipamento;
            contadorGestao.IncrementaContador();

        }

        public void MostraLista()
        {
            Equipamento[] produtos = new Equipamento[0];
            Console.Clear();
            Console.WriteLine("Itens da lista");
            Console.WriteLine("{0,-3} | {1,-10} | {2,-5} | {3,-10} | {4,-10} | {5,-10}", "ID", "Nome", "Preço", "Numero de Série", "Data de Criação", "fabricante");
            produtos = ListaItens();
            for (int i = 0; i < produtos.Length; i++)
            {
                Equipamento equipamentos = produtos[i];
                if (equipamentos != null)
                    Console.WriteLine("{0,-3} | {1,-10} | {2,-5} | {3,-10} | {4,-10} | {5,-10}",
                        equipamentos.id, equipamentos.nome, equipamentos.preco, equipamentos.numeroSerie, equipamentos.dataCriacao.ToShortDateString(), equipamentos.fabricante);
            }
            Console.ReadLine();
        }
        public Equipamento[] ListaItens()
        {
            return equipamento;
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
            Equipamento editaEquipamento = new Equipamento();
            Console.Clear();
            editaEquipamento.id = id;
            Console.WriteLine("Edição de equipamentos!");
            Console.Write("Digite o nome do item: ");
            editaEquipamento.nome = Console.ReadLine();
            Console.Write("Digite o preço do item: ");
            editaEquipamento.preco = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Digite o numero de série do item: ");
            editaEquipamento.numeroSerie = Console.ReadLine();
            Console.Write("Digite a data de criação do item: ");
            editaEquipamento.dataCriacao = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Digite o nome do fabricante do item: ");
            editaEquipamento.fabricante = Console.ReadLine();
            equipamento[id] = editaEquipamento;

            equipamento.SetValue(editaEquipamento, id);
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
            var lista = equipamento.ToList();

            lista.RemoveAt(id);

            equipamento = lista.ToArray();
        }

        public bool VerificarItens()
        {
            bool auxiliar = false;
            Equipamento[] produtos = new Equipamento[0];

            produtos = ListaItens();
            for (int i = 0; i < produtos.Length; i++)
            {
                Equipamento itens = produtos[i];
                if (itens != null)
                    auxiliar = true;
            }

            return auxiliar;
        }

        public static void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }
    }
}