using FluentAssertions;
using Moq;

namespace Diamantes.Test;

public class TesClassDiamantes
{
    [Theory(DisplayName = "Deve exibir opções do menu")]
    [InlineData(new string[]{
        "Bem Vindo ao Desafio Diamantes",
        "Escolha um das opções",
        "1 - Exibir um Diamante",
        "2 - Exibir um Triangulo",
        "3 - Exportar exibição em PDF",
        "0 - Sair"
    }, "0")]
    public void TesteSaidaMenu(string[] expected, string entry)
    {
        var instace = new Mock<DesafioDiamantes>();

        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(entry))
            {
                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);
                
                instace.Object.Menu();

                var response = stringWriter.ToString().Trim().Split("\n");

                for (int i = 0; i < expected.Length; i += 1)
                    response[i].Should().Be(expected[i]);
            }
            
        }
    }

    [Theory(DisplayName = "Deve executar o Método menu corretamente")]
    [InlineData(0, "Até Mais :)\n")]
    public void TesteExecutarOpcao(int entry, string expected)
    {
        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            var instace = new DesafioDiamantes();

            instace.Opcao(entry);

            var response = stringWriter.ToString();

            response.Should().Be(expected);
        }
    }

    [Theory(DisplayName = "Deve retornar mensagem inválida, ao passar valor fora das opções")]
    [InlineData(10, "Opção inválida, escolha um dos números do Menu\n")]
    public void TesteExecutarOpcaoInvalida(int entry, string expected)
    {
        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            var instace = new DesafioDiamantes();

            instace.Opcao(entry);

            var response = stringWriter.ToString();

            response.Should().Be(expected);
        }
    }
    
    [Theory(DisplayName = "Deve exibir a saída de ExibirDiamante")]
    [InlineData(
        "Digite a Letra que será o centro do Diamante (pontos mais distante)",
        "E"
    )]
    public void TesteSaidaExibirDiamante(string expected, string entry)
    {
        var instace = new Mock<DesafioDiamantes>();

        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(entry))
            {
                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);
                
                instace.Object.ExibirDiamante();

                var response = stringWriter.ToString().Trim().Split("\n");

                response[0].Should().Be(expected);
            }
            
        }
    }

    [Theory(DisplayName = "Deve exibir a saída de ExibirTriangulo")]
    [InlineData(
        "Digite a letra que será a base do Triangulo",
        "E"
    )]
    public void TesteSaidaExibirTriangulo(string expected, string entry)
    {
        var instace = new Mock<DesafioDiamantes>();

        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(entry))
            {
                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);
                
                instace.Object.ExibirTriangulo();

                var response = stringWriter.ToString().Trim().Split("\n");

                response[0].Should().Be(expected);
            }
            
        }
    }

    [Theory(DisplayName = "Deve exibir mensagem de letra inválida em Exibir Diamante")]
    [InlineData(new string[] {
        "Digite a Letra que será o centro do Diamante (pontos mais distante)",
        "Letra inválida, voltando ao menu",
    }, "12")]
    public void TesteEntradaInvalidaExibirDiamante(string[] expected, string entry)
    {
        var instace = new Mock<DesafioDiamantes>();

        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(entry))
            {
                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);
                
                instace.Object.ExibirDiamante();

                var response = stringWriter.ToString().Trim().Split("\n");

                for (int i = 0; i < expected.Length; i += 1)
                    response[i].Should().Be(expected[i]);
            }
            
        }
    }

    [Theory(DisplayName = "Deve exibir mensagem de letra inválida em ExibirTriangulo")]
    [InlineData(new string[] {
        "Digite a letra que será a base do Triangulo",
        "Letra inválida, voltando ao menu",
    }, "12")]
    public void TesteEntradaInvalidaExibirTriangulo(string[] expected, string entry)
    {
        var instace = new Mock<DesafioDiamantes>();

        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(entry))
            {
                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);
                
                instace.Object.ExibirTriangulo();

                var response = stringWriter.ToString().Trim().Split("\n");

                for (int i = 0; i < expected.Length; i += 1)
                    response[i].Should().Be(expected[i]);
            }
            
        }
    }

    [Theory(DisplayName = "Deve gerar o diamante corretamente")]
    [InlineData(
        "     A\n\n" +
        "    B B\n\n" +
        "   C   C\n\n" +
        "  D     D\n\n" +
        " E       E\n\n" +
        "  D     D\n\n" +
        "   C   C\n\n" +
        "    B B\n\n" +
        "     A",
        'E',
        4
    )]
    public void TesteGerarDiamante(string expected, char letra, int indexLetra)
    {
            var instace = new DesafioDiamantes();

            instace.Forma.Should().BeEmpty();

            instace.GerarDiamante(indexLetra, letra, 0);

            instace.Forma.Should().Be(expected);
    }

    [Theory(DisplayName = "Deve gerar o triangulo corretamente")]
    [InlineData(
        "     A\n" +
        "    B B\n" +
        "   C   C\n" +
        "  D     D\n" +
        " EDCBABCDE",
        'E',
        4
    )]
    public void TesteGerarTriangulo(string expected, char letra, int indexLetra)
    {
            var instace = new DesafioDiamantes();

            instace.Forma.Should().BeEmpty();

            instace.GerarTriangulo(indexLetra, letra, 0);

            instace.Forma.Should().Be(expected);
    }

    [Theory(DisplayName = "Deve exibir mensagem ao chamar EnviarConteudo")]
    [InlineData(new string[] {
        "Deseja enviar o conteúdo exibido por email ? (sim ou não)",
        "Digite o email para qual será enviado o conteúdo exibido"
    },
    new string[] {
        "sim",
        "teste@teste.com"
    })]
    public void TesteSaidaEnviarConteudo(string[] expected, string[] entrys)
    {
        var instace = new Mock<DesafioDiamantes>();

        using(var stringWriter = new StringWriter())
        {
            using(var stringReader = new StringReader(string.Join("\n", entrys)))
            {
                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);

                instace.Object.EnviarConteudo();

                var response = stringWriter.ToString().Trim().Split("\n");

                for (int i = 0; i < expected.Length; i += 1)
                    response[i].Should().Be(expected[i]);
            }
        }
    }

    [Theory(DisplayName = "Deve exibir mensagem de email inválido ao chamar EnviarConteudo")]
    [InlineData(new string[] {
        "Deseja enviar o conteúdo exibido por email ? (sim ou não)",
        "Digite o email para qual será enviado o conteúdo exibido",
        "Email inválido"
    },
    new string[] {
        "sim",
        "teste123"
    })]
    public void TesteEmailInvalidoEnviarConteudo(string[] expected, string[] entrys)
    {
        var instace = new Mock<DesafioDiamantes>();

        using(var stringWriter = new StringWriter())
        {
            using(var stringReader = new StringReader(string.Join("\n", entrys)))
            {
                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);

                instace.Object.EnviarConteudo();

                var response = stringWriter.ToString().Trim().Split("\n");

                for (int i = 0; i < expected.Length; i += 1)
                    response[i].Should().Be(expected[i]);
            }
        }
    }

    [Fact(DisplayName = "Testa se método ExportarPdf não retorna uma exceção")]
    public void TesteExportarParaPdf(){
        using(var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            var instace = new DesafioDiamantes();

            instace.Forma = "A";

            Action act = () => instace.ExportarPdf();

            act.Should().NotThrow<Exception>();
        }
    }

    [Theory(DisplayName = "Testa se método ExportarPdf não retorna uma exceção")]
    [InlineData("Ainda não foi gerado uma forma. Utilize primeiro uma das opções de exibição\n")]
    public void TesteExportarParaPdfSemFormaCriada(string expected){
        using(var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            var instace = new DesafioDiamantes();

            instace.ExportarPdf();

            var response = stringWriter.ToString();

            response.Should().Be(expected);
        }
    }

}
