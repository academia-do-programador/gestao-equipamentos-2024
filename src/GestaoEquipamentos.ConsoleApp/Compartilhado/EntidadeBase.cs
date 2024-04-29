namespace GestaoEquipamentos.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }

        public abstract string[] Validar();
    }
}
