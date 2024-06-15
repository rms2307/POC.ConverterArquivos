using Microsoft.AspNetCore.Mvc;
using WkHtmlToPdfDotNet.Contracts;
using WkHtmlToPdfDotNet;

namespace POC.ConverterArquivos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HTMLToPDFController : ControllerBase
    {
        private readonly ILogger<HTMLToPDFController> _logger;

        public HTMLToPDFController(ILogger<HTMLToPDFController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "ConverterHTMLToPDF")]
        public FileResult Converter()
        {
            IConverter converter = new SynchronizedConverter(new PdfTools());

            string html = "<html><p>POC para converter um HTML em arquivo.</p></html>";

            HtmlToPdfDocument doc = new()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    DocumentTitle = "arquivo-de-teste"
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = html,
                        WebSettings= { DefaultEncoding = "utf-8"}
                    }
                }
            };

            byte[] arquivo = converter.Convert(doc);

            return new FileContentResult(arquivo, "application/pdf");
        }
    }
}
