using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace ArvefordelerenWebApp.Services;

public static class PdfParsingService
{
    public static string ExtractJsonFromPdf(byte[] pdfBytes)
    {
        using var pdfReader = new PdfReader(new MemoryStream(pdfBytes));
        using var pdfDocument = new PdfDocument(pdfReader);

        var content = new StringBuilder();

        for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
        {
            var page = pdfDocument.GetPage(i);
            content.Append(PdfTextExtractor.GetTextFromPage(page));
        }

        return content.ToString()
        .Trim()
        .Replace("\r\n","")
        .Replace("\n","");
    }
}