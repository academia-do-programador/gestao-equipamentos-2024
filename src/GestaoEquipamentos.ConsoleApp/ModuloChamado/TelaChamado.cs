using static GestaoEquipamentos.ConsoleApp.TelaEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado
    {
        //atributos chamado
        public Chamado[] chamado = new Chamado[20];

        //atributos de gestão de itens
        public TelaEquipamento gestao = new TelaEquipamento();

        //atributos contador
        public Contador contadorChamado = new Contador();

        public void Inserir()
        {
            Chamado chamado = new Chamado();
            Console.Clear();
            chamado.id = contadorChamado.contador;
            Console.WriteLine("Cadastro de equipamentos!");
            Console.Write("Digite o titulo: ");
            chamado.titulo = Console.ReadLine();
            Console.Write("Digite a descrição: ");
            chamado.descricao = Console.ReadLine();
            gestao.MostraLista();
            Console.Write("Digite o numero do Id do produto do chamado: ");
            chamado.idEquipamento = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a data de criação do chamado: ");
            chamado.dataAbreChamado = Convert.ToDateTime(Console.ReadLine());
            this.chamado[contadorChamado.contador] = chamado;
            contadorChamado.IncrementaContador();

        }
        public void CauculaTempo()
        {

        }

        public void MostraListaChamados()
        {
            Chamado[] showChamados = new Chamado[0];
            Console.Clear();
            Console.WriteLine("Itens da lista");
            Console.WriteLine($"{0,-10} | {1,-15} | {2,-15} | {3,-10} | {4,-10}", "ID", "Titulo", "Descrição", "Id item", "Tempo aberto");
            showChamados = ListaChamados();
            for (int i = 0; i < showChamados.Length; i++)
            {
                Chamado chamados = showChamados[i];
                if (chamados != null)
                    Console.WriteLine("{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10}",
                        chamados.id, chamados.titulo, chamados.descricao, chamados.idEquipamento, chamados.tempoDecorrente.ToShortDateString());
            }
            Console.ReadLine();
        }

        public Chamado[] ListaChamados()
        {
            return chamado;
        }

        public void Editar()
        {
            int id = 0;
            Console.Clear();
            MostraListaChamados();
            Console.WriteLine("Informe o id do produto que deseja editar: ");
            id = Convert.ToInt32(Console.ReadLine());
            Edicao(id);
        }
        public void Edicao(int id)
        {
            Chamado editarChamado = new Chamado();
            Console.Clear();
            editarChamado.id = id;
            Console.WriteLine("Edição de equipamentos!");
            Console.Write("Digite o titulo: ");
            editarChamado.titulo = Console.ReadLine();
            Console.Write("Digite a descrição: ");
            editarChamado.descricao = Console.ReadLine();
            Console.Write("Digite o numero do Id do produto do chamado: ");
            editarChamado.idEquipamento = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a data de criação do chamado: ");
            editarChamado.dataAbreChamado = Convert.ToDateTime(Console.ReadLine());
            chamado[id] = editarChamado;

            chamado.SetValue(editarChamado, id);
        }

        public void TelaExcluirEquipamento()
        {
            int id = 0;
            Console.Clear();
            MostraListaChamados();
            Console.WriteLine("Informe o id do equipamento que deseja excluir: ");
            id = Convert.ToInt32(Console.ReadLine());
            ExcluirEquipamento(id);

            Console.Clear();
            MostraListaChamados();
            Console.ReadLine();
        }

        public void ExcluirEquipamento(int id)
        {
            var lista = chamado.ToList();

            lista.RemoveAt(id);

            chamado = lista.ToArray();
        }
    }

    public class RepositorioChamado
    {

    }

}
