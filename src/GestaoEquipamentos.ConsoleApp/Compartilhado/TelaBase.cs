namespace GestaoEquipamentos.ConsoleApp.Compartilhado
{
    public abstract class TelaBase
    {
        public string tipoEntidade = "";
        public RepositorioBase repositorio = null;

        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Editar {tipoEntidade}");
            Console.WriteLine($"3 - Excluir {tipoEntidade}");
            Console.WriteLine($"4 - Visualizar {tipoEntidade}s");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            EntidadeBase entidade = ObterRegistro();

            string[] erros = entidade.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                Registrar();
                return;
            }

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void Editar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Editando {tipoEntidade}...");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write($"Digite o ID do {tipoEntidade} que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (repositorio.Existe(id) == false)
            {
                ExibirMensagem($"O {tipoEntidade} mencionado não existe!", ConsoleColor.DarkYellow);
                Editar();
            }

            Console.WriteLine();

            EntidadeBase entidade = ObterRegistro();

            string[] erros = entidade.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                Editar();
                return;
            }

            bool conseguiuEditar = repositorio.Editar(id, entidade);

            if (!conseguiuEditar)
            {
                ExibirMensagem($"Houve um erro durante a edição de {tipoEntidade}", ConsoleColor.Red);
                return;
            }

            ExibirMensagem($"O {tipoEntidade} foi editado com sucesso!", ConsoleColor.Green);
        }

        public void Excluir()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Excluindo {tipoEntidade}...");

            Console.WriteLine();

            VisualizarRegistros(false);

            int id = 0;
            do
            {
                Console.Write($"Digite o ID do {tipoEntidade} que deseja excluir: ");
                id = Convert.ToInt32(Console.ReadLine());

                ExibirMensagem($"O {tipoEntidade} mencionado não existe!", ConsoleColor.DarkYellow);

            } while (repositorio.Existe(id) == false);

            bool conseguiuExcluir = repositorio.Excluir(id);

            if (!conseguiuExcluir)
            {
                ExibirMensagem($"Houve um erro durante a exclusão do {tipoEntidade}", ConsoleColor.Red);
                return;
            }

            ExibirMensagem($"O {tipoEntidade} foi excluído com sucesso!", ConsoleColor.Green);
        }

        public abstract void VisualizarRegistros(bool exibirTitulo);

        protected void ApresentarErros(string[] erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
                Console.WriteLine(erros[i]);

            Console.ResetColor();
            Console.ReadLine();
        }

        protected void ApresentarCabecalho()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Equipamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
        }

        public void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.WriteLine();

            Console.ResetColor();

            Console.ReadLine();
        }

        protected abstract EntidadeBase ObterRegistro();
    }
}
