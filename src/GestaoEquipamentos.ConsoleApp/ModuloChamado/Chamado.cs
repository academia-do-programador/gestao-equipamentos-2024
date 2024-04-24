using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class Chamado
    {
        public int Id { get; set; }
        public string Descricacao { get; set; }
        public string Titulo { get; set; }

        private DateTime dataAbertura;
        public int QuantidadeDiasEmAberto
        {
            get
            {
                DateTime dataHoje = DateTime.Now;

                TimeSpan diferenca = dataHoje.Subtract(dataAbertura);

                int diferencaNumero = diferenca.Days;

                return diferencaNumero;
            }
        }

        public Equipamento EquipamentoSelecionado;

        public Chamado(string titulo, string descricacao, Equipamento equipamentoSelecionado)
        {
            Titulo = titulo;
            Descricacao = descricacao;
            dataAbertura = DateTime.Now;
            EquipamentoSelecionado = equipamentoSelecionado;
        }
    }
}
