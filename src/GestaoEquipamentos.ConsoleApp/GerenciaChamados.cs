﻿using static GestaoEquipamentos.ConsoleApp.Gestao;

namespace GestaoEquipamentos.ConsoleApp
{
    public class GerenciaChamados
    {
        //atributos chamado
        public Chamados[] chamado = new Chamados[20];

        //atributos de gestão de itens
        public Gestao gestao = new Gestao();

        //atributos contador
        public Contador contadorChamado = new Contador();

        public void Inserir()
        {
            Chamados chamado = new Chamados();
            Console.Clear();
            chamado.idChamado = contadorChamado.contador;
            Console.WriteLine("Cadastro de equipamentos!");
            Console.Write("Digite o titulo: ");
            chamado.titulo = Console.ReadLine();
            Console.Write("Digite a descrição: ");
            chamado.descricao = Console.ReadLine();
            gestao.MostraLista();
            Console.Write("Digite o numero do Id do produto do chamado: ");
            chamado.idEquipamento = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a data de criação do chamado: ");
            chamado.dataAbreChamado = Console.ReadLine();
            this.chamado[contadorChamado.contador] = chamado;
            contadorChamado.IncrementaContador();

        }
        public void CauculaTempo()
        {

        }

        public void MostraListaChamados()
        {
            Chamados[] showChamados = new Chamados[0];
            Console.Clear();
            Console.WriteLine("Itens da lista");
            Console.WriteLine($"ID | Titulo | Descrição | Id item | Data de abertura | Tempo aberto");
            showChamados = ListaChamados();
            for (int i = 0; i < showChamados.Length; i++)
            {
                Chamados chamados = showChamados[i];
                if (chamados != null)
                    Console.WriteLine($"{chamados.idChamado} | {chamados.titulo} | {chamados.descricao} | {chamados.idEquipamento} | {chamados.dataAbreChamado} | {chamados.tempoDecorrente}");
            }
        }

        public Chamados[] ListaChamados()
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
        public void Edicao(int idChamado)
        {
            Chamados editarChamado = new Chamados();
            Console.Clear();
            editarChamado.idChamado = idChamado;
            Console.WriteLine("Edição de equipamentos!");
            Console.Write("Digite o titulo: ");
            editarChamado.titulo = Console.ReadLine();
            Console.Write("Digite a descrição: ");
            editarChamado.descricao = Console.ReadLine();
            Console.Write("Digite o numero do Id do produto do chamado: ");
            editarChamado.idEquipamento = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a data de criação do chamado: ");
            editarChamado.dataAbreChamado = Console.ReadLine();
            chamado[idChamado] = editarChamado;

            chamado.SetValue(editarChamado, idChamado);
        }

        public void Excluir()
        {
            int id = 0;
            Console.Clear();
            MostraListaChamados();
            Console.WriteLine("Informe o id do produto que deseja excluir: ");
            id = Convert.ToInt32(Console.ReadLine());
            Exclusao(id);

            Console.Clear();
            MostraListaChamados();
            Console.ReadLine();
        }

        public void Exclusao(int id)
        {
            var lista = chamado.ToList();

            lista.RemoveAt(id);

            chamado = lista.ToArray();
        }
    }

}
