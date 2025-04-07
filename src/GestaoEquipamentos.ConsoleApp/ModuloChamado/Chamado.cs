using GestaoEquipamentos.ConsoleApp.Compartilhado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class Chamado : EntidadeBase
    {
        private DateTime dataAbertura;

        public string Descricacao { get; set; }
        public string Titulo { get; set; }

        public Equipamento EquipamentoSelecionado { get; set; }

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

        public Chamado(string titulo, string descricacao, Equipamento equipamentoSelecionado)
        {
            Titulo = titulo;
            Descricacao = descricacao;
            EquipamentoSelecionado = equipamentoSelecionado;
            dataAbertura = DateTime.Now;
        }

        public Chamado(string titulo, string descricacao, Equipamento equipamentoSelecionado, DateTime dataAbertura)
        {
            Titulo = titulo;
            Descricacao = descricacao;
            EquipamentoSelecionado = equipamentoSelecionado;
            this.dataAbertura = dataAbertura;
        }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Titulo))
                erros[contadorErros++] = "O título é obrigatório";

            if (string.IsNullOrEmpty(Descricacao))
                erros[contadorErros++] = "A descrição é obrigatória";

            if (EquipamentoSelecionado == null)
                erros[contadorErros++] = "O equipamento é obrigatório";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}
