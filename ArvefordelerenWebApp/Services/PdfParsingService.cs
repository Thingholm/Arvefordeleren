using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace ArvefordelerenWebApp.Services;

public static class PdfParsingService
{
    public static string ExtractJsonFromPdf(byte[] pdfBytes)
    {
        using PdfReader pdfReader = new PdfReader(new MemoryStream(pdfBytes));
        using PdfDocument pdfDocument = new PdfDocument(pdfReader);

        StringBuilder content = new StringBuilder();

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