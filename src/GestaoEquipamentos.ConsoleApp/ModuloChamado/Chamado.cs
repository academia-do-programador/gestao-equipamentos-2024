using GestaoEquipamentos.ConsoleApp.Compartilhado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class Chamado : EntidadeBase
    {
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

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Titulo))
            {
                erros[0] = "O título é obrigatório";
                contadorErros++;
            }

            if (string.IsNullOrEmpty(Descricacao))
            {
                erros[1] = "A descrição é obrigatória";
                contadorErros++;
            }

            if (EquipamentoSelecionado == null)
            {
                erros[2] = ("O equipamento é obrigatório");
                contadorErros++;
            }

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}
