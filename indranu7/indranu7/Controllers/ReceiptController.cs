using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using indranu7.models;
using indranu7.buisinessLogic;
using System.IO;
using iTextSharp.text.pdf;

namespace indranu7.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        [HttpGet]
        [ActionName("getReceiptFields")]
        public ActionResult<ReceiptFormModel> GetReceiptFields()
        {
            return formatMetadata.GetReceiptFields();
        }

        [HttpPost]
        [EnableCors("AllowMyOrigin")]
        [ActionName("getReciepts")]
        public ReceiptModel[] Post([FromBody] FieldModel[] inputFields)
        {
            return formatMetadata.GetReceipts(inputFields);
        }

        [HttpGet]
        [ActionName("getPDF")]
        public IActionResult GetPDFs()
        {
            var pdf = new pdfCreator();
            var doc = pdf.createPDF();
            var stream = new FileStream("C:\\Users\\dsilamikelis\\Desktop\\test\\test.pdf", FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }

    }
}