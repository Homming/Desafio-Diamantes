using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class ExportPdf {

    private Document _doc { get; set; }

    public ExportPdf() {
        _doc = new Document(PageSize.A4);
        _doc.SetMargins(40, 40, 40, 80);
        _doc.AddCreationDate();
    }

    public void ExportarParaPdf(string dados) {
        try {
            
            string filePath = $"./files/desafio{DateTime.Now.ToString("s")}.pdf";
            PdfWriter writer = PdfWriter.GetInstance(_doc, new FileStream(filePath, FileMode.Create));
           
            _doc.Open();

            Paragraph text = new("", new Font(Font.NORMAL, 14))
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };

            text.Add(dados);

            _doc.Add(text);

        } catch (Exception e) {
            Console.WriteLine(e.Message);
        } finally {
            _doc.Close();
        }
        

    }
}