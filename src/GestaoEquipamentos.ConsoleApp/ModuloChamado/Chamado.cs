using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class Chamado
    {
        public int Id;
        public string Titulo;
        public string Descricacao;
        public DateTime DataAbertura;

        public Equipamento EquipamentoSelecionado;

        public Chamado(string titulo, string descricacao, DateTime dataAbertura, Equipamento equipamentoSelecionado)
        {
            Titulo = titulo;
            Descricacao = descricacao;
            DataAbertura = dataAbertura;
            EquipamentoSelecionado = equipamentoSelecionado;
        }
    }
}
