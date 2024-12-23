using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ArvefordelerenWebApp.Services;
public static class PdfService
{
    static PdfService()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }
    public static Byte[] GeneratePdfFromJson(string jsonContent)
    {
        return Document.Create(container =>
        {
            container.Page(page => 
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.Content().Padding(1, Unit.Centimetre).Text(jsonContent).FontSize(10);
            });
        }).GeneratePdf();
    }
}