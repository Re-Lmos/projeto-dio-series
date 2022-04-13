using static System.Console;
using CadastroSeries.Classes;
using CadastroSeries.Enum;


namespace CadastroSeries
{

    class Program 
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                    ListarSeries();
                    break;
                    case "2":
                    InserirSerie();
                    break;
                    case "3":
                    AtualizarSeries();
                    break;
                    case "4":
                    ExcluirSeries();
                    break;
                    case "5":
                    VisualizarSeries();
                    break;
                    case "C":
                    Clear();
                    break;
                    default:
                    throw new ArgumentOutOfRangeException();
                        
                }
                opcaoUsuario = ObterOpcaoUsuario();
            
            } 
            WriteLine("\n ##Obrigada por utilizar nossos serviços!##");
            WriteLine();   
        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();
                if (lista.Count == 0)
                {
                    WriteLine(" __________________________________");
                    WriteLine("\n **Nenhuma Série Cadastrada**\n");
                    return;
                }

                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    WriteLine("\n #ID ({0}): {1}  {2}",serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : "\n"));
                }
        }


        private static void InserirSerie()
        {
            WriteLine(" __________________________________");
            WriteLine("\n # INSERIR NOVA SÉRIE #\n");
            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                WriteLine(" ({0}) - {1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Write("\nDigite o número correspondente ao Gênero acima: ");
            int entradaGenero = int.Parse(ReadLine());
            
            Write("Digite o Título da Série: ");
            string entradaTitulo = ReadLine();

            Write("Digite o Ano de Lançamento da Série: ");
            int entradaAno = int.Parse(ReadLine());

            Write("Digite uma Descrição pra Série: ");
            string entradaDescricao = ReadLine();

            Serie novaSerie = new Serie(Id: repositorio.proximoId(),
                                        Genero: (Genero)entradaGenero,
                                        Titulo: entradaTitulo,
                                        Ano: entradaAno,
                                        Descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
            WriteLine("\n **Adicionado com sucesso**");
        }

        private static void AtualizarSeries()
        {
            Write("\nDigite o ID da Série: ");
            int indiceSerie = int.Parse(ReadLine());
            var lista = repositorio.Lista();
            if (lista.Count == 0)
                {
                    WriteLine(" __________________________________");
                    WriteLine("\n **Nenhuma Série Cadastrada**\n");
                    return;
                }


            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                WriteLine(" ({0}) - {1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Write("\n Digite número correspondente ao Gênero acima: ");
            int entradaGenero = int.Parse(ReadLine());

            Write("Digite o Título da Série: ");
            string entradaTitulo = ReadLine();

            Write("Digite o Ano do Início da Série: ");
            int entradaAno = int.Parse(ReadLine());

            Write("Digite a Descrição da Série: ");
            string entradaDescricao = ReadLine();

            Serie atualizaSerie = new Serie(Id: indiceSerie,
                                Genero: (Genero)entradaGenero,
                                Titulo: entradaTitulo,
                                 Ano: entradaAno,
                                Descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
            WriteLine("\n **Atualizado com sucesso**");
        }

        private static void ExcluirSeries()
        {
            Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(ReadLine());
            var lista = repositorio.Lista();
             if (lista.Count == 0)
                {
                    WriteLine(" __________________________________");
                    WriteLine("\n **Nenhuma Série Cadastrada**\n");
                    return;
                }
            repositorio.Exclui(indiceSerie);
            WriteLine("\n **Excluído com sucesso**");

        }

        private static void VisualizarSeries()
        {
            Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(ReadLine());
            var lista = repositorio.Lista();
            if (lista.Count == 0)
                {
                    WriteLine(" __________________________________");
                    WriteLine("\n **Nenhuma Série Cadastrada**\n");
                    return;
                }


            var serie = repositorio.retornaPorId(indiceSerie);
            WriteLine(" __________________________________");
            WriteLine($"\n {serie}");
        }


        private static string ObterOpcaoUsuario()
        {
        WriteLine();
        WriteLine(" ____________SÉRIES DIO____________");
        WriteLine("\n Informe a opção desejada:\n");

        WriteLine(" (1) - Listar Séries Cadastradas");
        WriteLine(" (2) - Inserir Nova Série");
        WriteLine(" (3) - Renomear Série");
        WriteLine(" (4) - Excluir Série");
        WriteLine(" (5) - Visualizar Descrição da Série");
        WriteLine(" (C) - Limpar Tela");
        WriteLine(" (X) - Sair");
        WriteLine();

        string opcaoUsuario = ReadLine().ToUpper();
        WriteLine();
        return opcaoUsuario;
        }


    }   
}
