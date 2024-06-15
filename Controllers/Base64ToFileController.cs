using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace POC.ConverterArquivos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Base64ToFileController : ControllerBase
    {
        private readonly ILogger<HTMLToPDFController> _logger;

        public Base64ToFileController(ILogger<HTMLToPDFController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "ConverterBase64ToFile")]
        public FileResult Converter()
        {
            string base64 = "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MDAxNj4gWzwwMDUwPiA8MDA0Rj4gPDAwNDM+IDwwMDIwPiA8MDA3MD4gPDAwNjE+IDwwMDcyPiA8MDA2Mz4gPDAwNkY+IDwwMDZFPiA8MDA3Nj4gPDAwNjU+IDwwMDc0PiA8MDA3NT4gPDAwNkQ+IDwwMDQ4PiA8MDA1ND4gPDAwNEQ+IDwwMDRDPiA8MDA3MT4gPDAwNjk+IDwwMDJFPiBdCmVuZGJmcmFuZ2UKZW5kY21hcApDTWFwTmFtZSBjdXJyZW50ZGljdCAvQ01hcCBkZWZpbmVyZXNvdXJjZSBwb3AKZW5kCmVuZAoKZW5kc3RyZWFtCmVuZG9iago2IDAgb2JqCjw8IC9UeXBlIC9Gb250Ci9TdWJ0eXBlIC9UeXBlMAovQmFzZUZvbnQgL1RpbWVzTmV3Um9tYW5Ob3JtYWwKL0VuY29kaW5nIC9JZGVudGl0eS1ICi9EZXNjZW5kYW50Rm9udHMgWzE0IDAgUl0KL1RvVW5pY29kZSAxNSAwIFI+PgplbmRvYmoKMiAwIG9iago8PAovVHlwZSAvUGFnZXMKL0tpZHMgClsKNSAwIFIKXQovQ291bnQgMQovUHJvY1NldCBbL1BERiAvVGV4dCAvSW1hZ2VCIC9JbWFnZUNdCj4+CmVuZG9iagp4cmVmCjAgMTcKMDAwMDAwMDAwMCA2NTUzNSBmIAowMDAwMDAwMDA5IDAwMDAwIG4gCjAwMDAwMDg0OTkgMDAwMDAgbiAKMDAwMDAwMDE5NSAwMDAwMCBuIAowMDAwMDAwMjkwIDAwMDAwIG4gCjAwMDAwMDAzNzYgMDAwMDAgbiAKMDAwMDAwODM1NCAwMDAwMCBuIAowMDAwMDAwMzI3IDAwMDAwIG4gCjAwMDAwMDA2ODIgMDAwMDAgbiAKMDAwMDAwMTAzMSAwMDAwMCBuIAowMDAwMDAwNDk2IDAwMDAwIG4gCjAwMDAwMDA2NjIgMDAwMDAgbiAKMDAwMDAwMTA1MCAwMDAwMCBuIAowMDAwMDAxMzEwIDAwMDAwIG4gCjAwMDAwMDc0NzMgMDAwMDAgbiAKMDAwMDAwNzc4NCAwMDAwMCBuIAowMDAwMDA3NDUyIDAwMDAwIG4gCnRyYWlsZXIKPDwKL1NpemUgMTcKL0luZm8gMSAwIFIKL1Jvb3QgNyAwIFIKPj4Kc3RhcnR4cmVmCjg1OTcKJSVFT0YK";

            FileExtensionContentTypeProvider provider = new();
            if (!provider.TryGetContentType("teste.pdf", out string? contentType))
            {
                contentType = "application/octet-stream";
            }

            byte[] arquivo = Convert.FromBase64String(base64);

            return new FileContentResult(arquivo, contentType);
        }
    }
}