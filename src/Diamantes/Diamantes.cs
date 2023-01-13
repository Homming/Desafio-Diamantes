using System.Linq;
using System.Text.RegularExpressions;

public class Diamantes {

    private readonly List<char> letras = new() {
        'A', 'B', 'C', 'D', 'E', 
        'F', 'G', 'H', 'I', 'J', 
        'K', 'L', 'M', 'N', 'O', 
        'P', 'Q', 'R', 'S', 'T',
        'U', 'V', 'W', 'X', 'Y', 
        'Z' 
    };

    public string conteudo { get; set; } = "";

    public void Menu () {
        Console.WriteLine("Bem Vindo ao Desafio Diamantes");
        int opção;
        do {
            Console.WriteLine("Escolha um das opções");
            Console.WriteLine("1 - Exibir um Diamante");
            Console.WriteLine("2 - Exibir um Circulo");
            Console.WriteLine("3 - Exportar exibição em PDF");
            Console.WriteLine("0 - Sair");
            _ = int.TryParse(Console.ReadLine(), out opção);

            Opcao(opção);
        } while (opção != 0);
    }

    public void Opcao(int op) {
        switch (op) {
            case 1:
                ExibirDiamante();
                EnviarConteudo();
                break;
            case 2:
                //ExibirCirculo();
                break;
            case 3:
                //ExportarPdf();
                break;
            case 0:
                Console.WriteLine("Até Mais :)");
                break;
            default:
               Console.WriteLine("Opção inválida, escolha um dos números do Menu");
               break;
        }
    }

    public void EnviarConteudo() {
       Console.WriteLine("Deseja enviar o conteúdo exibido por email ?");
       string? resposta = Console.ReadLine();

       if (resposta!.ToLower().Contains("sim")) {

            Console.WriteLine("Digite o email para qual será enviado o conteúdo exibido");
            string? email = Console.ReadLine();

            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); 

            if (regex.IsMatch(email)) {
                var instace = new EmailProvider();
                instace.EnviarEmail(email, "Conteúdo Exibido Desafio Diamantes", "teste");
            } else {
               Console.WriteLine("Email inválido");
            }
            
       }

    }

    public void ExibirDiamante() {
        Console.WriteLine("Digite a Letra que será o centro do Diamante (pontos mais distante)");
        var isALetter = char.TryParse(Console.ReadLine(), out char letra);

        if (!isALetter) {
            Console.WriteLine("Letra inválida, voltando ao menu");
        } else {
            var letraIndex = letras.IndexOf(letra);
            imprimirDiamante(letraIndex, letra, 0);
        }

    }

    public void imprimirDiamante(int letraIndex, char letra, int AtualIndex) {
        Console.WriteLine();
        for (int i = 0; i <= letraIndex; i += 1)
            Console.Write(" ");
        
        if (letra == 'A') {
            Console.Write(letra);
            Console.WriteLine();
        }
        else if (letras[AtualIndex] == 'A') {
            Console.Write(letras[AtualIndex]);
            imprimirDiamante(letraIndex - 1, letra, AtualIndex + 1);
        }
        else if (letras[AtualIndex] == letra) {
            Console.Write(letras[AtualIndex]);
            for (int i = 1; i < AtualIndex * 2; i += 1)
                Console.Write(" ");
            Console.Write(letras[AtualIndex]);
            imprimirDiamante(letraIndex + 1, letras[AtualIndex - 1], AtualIndex - 1);
        }
        else {
            Console.Write(letras[AtualIndex]);
            for (int i = 1; i < AtualIndex * 2; i += 1)
                Console.Write(" ");
            Console.Write(letras[AtualIndex]);
            imprimirDiamante(letraIndex - 1, letra, AtualIndex + 1);
        }
    }
}
