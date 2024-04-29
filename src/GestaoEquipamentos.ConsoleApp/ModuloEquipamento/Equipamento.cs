using GestaoEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    public class Equipamento : EntidadeBase
    {
        public string Nome { get; set; }
        public string NumeroSerie { get; set; }
        public string Fabricante { get; set; }
        public decimal PrecoAquisicao { get; set; }
        public DateTime DataFabricacao { get; set; }

        public Equipamento(string nome, string numeroSerie, string fabricante, decimal precoAquisicao, DateTime dataFabricacao)
        {
            Nome = nome;
            NumeroSerie = numeroSerie;
            Fabricante = fabricante;
            PrecoAquisicao = precoAquisicao;
            DataFabricacao = dataFabricacao;
        }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (Nome.Length < 3)
                erros[contadorErros++] = "O Nome do Equipamento precisa conter ao menos 3 caracteres";

            if (Fabricante.Length < 3)
                erros[contadorErros++] = "O Fabricante do Equipamento precisa conter ao menos 3 caracteres";

            if (!NumeroSerie.Contains('-'))
                erros[contadorErros++] = "O Número de Série do Equipamento precisa conter o caractere '-'.";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}