namespace GestaoEquipamentos.ConsoleApp
{
    public class Menus
    {
        public void MenuInicial()
        {
            Console.Clear();
            Console.WriteLine("Gestão de equipamentos \nDigite 1 - Para a gestão dos equipamentos. \nDigite 2 - Para gestão de chamados. \nDigite 3 - Para sair");
        }

        public void MenuLista()
        {
            Console.Clear();
            Console.WriteLine("Gestão de equipamentos \nDigite 1 - Inserir novo item. \nDigite 2 - Visualizar itens. \nDigite 3 - Editar item. \nDigite 4 - Excluir item. \nDigite 5 - Para sair");
        }
    }
}
