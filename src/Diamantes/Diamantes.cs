using System.Text.RegularExpressions;
public class DesafioDiamantes {

    private readonly List<char> letras = new() {
        'A', 'B', 'C', 'D', 'E', 
        'F', 'G', 'H', 'I', 'J', 
        'K', 'L', 'M', 'N', 'O', 
        'P', 'Q', 'R', 'S', 'T',
        'U', 'V', 'W', 'X', 'Y', 
        'Z' 
    };

    public string Forma { get; set; } = "";

    public void Menu ()
    {
        Console.WriteLine("Bem Vindo ao Desafio Diamantes");
        int opção;
        do
        {
            Console.WriteLine("Escolha um das opções");
            Console.WriteLine("1 - Exibir um Diamante");
            Console.WriteLine("2 - Exibir um Triangulo");
            Console.WriteLine("3 - Exportar exibição em PDF");
            Console.WriteLine("0 - Sair");
            _ = int.TryParse(Console.ReadLine(), out opção);

            Opcao(opção);
        } while (opção != 0);
    }

    public void Opcao(int op)
    {
        switch (op)
        {
            case 1:
                Forma = "";
                ExibirDiamante();
                EnviarConteudo();
                break;
            case 2:
                Forma = "";
                ExibirTriangulo();
                EnviarConteudo();
                break;
            case 3:
                ExportarPdf();
                break;
            case 0:
                Console.WriteLine("Até Mais :)");
                break;
            default:
               Console.WriteLine("Opção inválida, escolha um dos números do Menu");
               break;
        }
    }

    public void ExportarPdf()
    {
        if (Forma == "")
            Console.WriteLine("Ainda não foi gerado uma forma. Utilize primeiro uma das opções de exibição");
        else
        {
            var instace = new ExportPdf();

            instace.ExportarParaPdf(Forma);
        }
    }

    public void EnviarConteudo()
    {
       Console.WriteLine("Deseja enviar o conteúdo exibido por email ? (sim ou não)");
       string? resposta = Console.ReadLine();

       if (resposta!.ToLower().Contains("sim"))
       {

            Console.WriteLine("Digite o email para qual será enviado o conteúdo exibido");
            string? email = Console.ReadLine();

            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); 

            if (regex.IsMatch(email!))
            {
                var instace = new EmailProvider();
                instace.EnviarEmail(email!, "Conteúdo Exibido Desafio Diamantes", Forma);
            }
            else
            {
               Console.WriteLine("Email inválido");
            }
            
       }

    }

    public void ExibirTriangulo()
    {
        Console.WriteLine("Digite a letra que será a base do Triangulo");
        var isALetter = char.TryParse(Console.ReadLine(), out char letra);

        if (!isALetter)
        {
            Console.WriteLine("Letra inválida, voltando ao menu");
        }
        else
        {
            var letraIndex = letras.IndexOf(letra);
            GerarTriangulo(letraIndex, letra, 0);
            Console.WriteLine(Forma);
        }
    }

    public void GerarTriangulo(int letraIndex, char letra, int AtualIndex)
    {
        for (int i = 0; i <= letraIndex; i += 1)
            Forma += " ";
        
        if (letra == 'A')
        {
            Forma += letra;
        }
        else if (letras[AtualIndex] == 'A')
        {
            Forma += letras[AtualIndex] + "\n";;
            GerarTriangulo(letraIndex - 1, letra, AtualIndex + 1);
        }
        else if (letras[AtualIndex] == letra)
        {
            for (int i = AtualIndex; i > 0; i -= 1)
                Forma += letras[i];
            for (int i = 0; i <= AtualIndex; i += 1)
                Forma += letras[i];
        }
        else
        {
            Forma += letras[AtualIndex];
            for (int i = 1; i < AtualIndex * 2; i += 1)
                Forma += " ";
            Forma += letras[AtualIndex] + "\n";;
            GerarTriangulo(letraIndex - 1, letra, AtualIndex + 1);
        }
    }

    public void ExibirDiamante()
    {
        Console.WriteLine("Digite a Letra que será o centro do Diamante (pontos mais distante)");
        var isALetter = char.TryParse(Console.ReadLine(), out char letra);

        if (!isALetter)
        {
            Console.WriteLine("Letra inválida, voltando ao menu");
        }
        else
        {
            var letraIndex = letras.IndexOf(letra);
            GerarDiamante(letraIndex, letra, 0);
            Console.WriteLine(Forma);
        }

    }

    public void GerarDiamante(int letraIndex, char letra, int AtualIndex)
    {
        for (int i = 0; i <= letraIndex; i += 1)
            Forma += " ";
        
        if (letra == 'A')
        {
            Forma += letra;
        }
        else if (letras[AtualIndex] == 'A')
        {
            Forma += letras[AtualIndex] + "\n\n";;
            GerarDiamante(letraIndex - 1, letra, AtualIndex + 1);
        }
        else if (letras[AtualIndex] == letra)
        {
            Forma += letras[AtualIndex];
            for (int i = 1; i < AtualIndex * 2; i += 1)
               Forma += " ";
            Forma += letras[AtualIndex] + "\n\n";
            GerarDiamante(letraIndex + 1, letras[AtualIndex - 1], AtualIndex - 1);
        }
        else
        {
            Forma += letras[AtualIndex];
            for (int i = 1; i < AtualIndex * 2; i += 1)
                Forma += " ";
            Forma += letras[AtualIndex] + "\n\n";;
            GerarDiamante(letraIndex - 1, letra, AtualIndex + 1);
        }
    }
}
