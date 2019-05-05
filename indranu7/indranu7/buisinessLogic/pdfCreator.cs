using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using indranu7.models;

namespace indranu7.buisinessLogic
{
    public class pdfCreator
    {

        private Paragraph LVparagraph(string text, bool bold = false)
        {
            string arialPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont arial = BaseFont.CreateFont(arialPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font myFont = new Font(arial, 12, Font.NORMAL);
            Font myFontBold = new Font(arial, 12, Font.BOLD);
            new Chunk("+ĒēŪūĪīĀāŠšĢģĶķĻļČčŅņ=", myFont);

            if (bold) return new Paragraph(text, myFontBold);

            return new Paragraph(text, myFont);
        }


        private void AddReceiptCosts(PdfPTable SplitTable)
        {
            PdfPTable receiptForm = new PdfPTable(4);

            PdfPCell RentHeader = new PdfPCell();
            RentHeader.AddElement(LVparagraph("Īpašuma īre"));
            RentHeader.Colspan = 4;

            PdfPCell RowId = new PdfPCell();
            RowId.AddElement(LVparagraph("#"));

            PdfPCell RowName = new PdfPCell();
            RowName.AddElement(LVparagraph("Nosaukums"));

            PdfPCell RowPeriod = new PdfPCell();
            RowPeriod.AddElement(LVparagraph("Periods"));

            PdfPCell RowCost = new PdfPCell();
            RowCost.AddElement(LVparagraph("Maksa"));

            receiptForm.AddCell(RentHeader);
            receiptForm.AddCell(RowId);
            receiptForm.AddCell(RowPeriod);
            receiptForm.AddCell(RowCost);
            SplitTable.AddCell(receiptForm);
        }


        public Document createPDF(ReceiptModel[] receipts)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1254");
            Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            var output = new FileStream("C:\\Users\\dsilamikelis\\Desktop\\test\\test.pdf", FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);
            string arialPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\arial.ttf";
            try
            {
                doc.Open();
                foreach (var receipt in receipts)
                { 
                    doc.NewPage();
                    PdfPTable SplitTable = new PdfPTable(2);
                    AddReceiptCosts(SplitTable);
                    doc.Add(LVparagraph("TEST"));
                    doc.Add(SplitTable);
                }
            }
            catch
            {

            }
            finally
            {

                doc.Close();
  
            }


            return doc;
        }
    }
}

