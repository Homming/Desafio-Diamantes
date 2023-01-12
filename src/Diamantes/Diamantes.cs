
public class Diamantes {

    public void Menu () {
        Console.WriteLine("Bem Vindo ao Desafio Diamantes");
        int opção;
        do {
            Console.WriteLine("Escolha um das opções");
            Console.WriteLine("1 - Exibir um Diamante");
            Console.WriteLine("2 - Exibit um Circulo");
            Console.WriteLine("3 - Exportar exibição em PDF");
            Console.WriteLine("0 - Sair");
            _ = int.TryParse(Console.ReadLine(), out opção);

        } while (opção != 0);
    }

}