﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace indranu7.buisinessLogic
{
    public class pdfCreator
    {
        public Document createPDF()
        {
            Document doc = new Document(PageSize.A4);
            var output = new FileStream("C:\\Users\\dsilamikelis\\Desktop\\test\\test.pdf", FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);
            doc.Open();

            PdfPTable table1 = new PdfPTable(2);
            table1.DefaultCell.Border = 0;
            table1.WidthPercentage = 80;


            PdfPCell cell11 = new PdfPCell();
            cell11.Colspan = 1;
            cell11.AddElement(new Paragraph("ABC Traders Receipt"));

            cell11.AddElement(new Paragraph("Thankyou for shoping at ABC traders,your order details are below"));


            cell11.VerticalAlignment = Element.ALIGN_LEFT;

            PdfPCell cell12 = new PdfPCell();


            cell12.VerticalAlignment = Element.ALIGN_CENTER;


            table1.AddCell(cell11);

            table1.AddCell(cell12);


            PdfPTable table2 = new PdfPTable(3);

            //One row added

            PdfPCell cell21 = new PdfPCell();

            cell21.AddElement(new Paragraph("Photo Type"));

            PdfPCell cell22 = new PdfPCell();

            cell22.AddElement(new Paragraph("No. of Copies"));

            PdfPCell cell23 = new PdfPCell();

            cell23.AddElement(new Paragraph("Amount"));


            table2.AddCell(cell21);

            table2.AddCell(cell22);

            table2.AddCell(cell23);


            //New Row Added

            PdfPCell cell31 = new PdfPCell();

            cell31.AddElement(new Paragraph("Safe"));

            cell31.FixedHeight = 300.0f;

            PdfPCell cell32 = new PdfPCell();

            cell32.AddElement(new Paragraph("2"));

            cell32.FixedHeight = 300.0f;

            PdfPCell cell33 = new PdfPCell();

            cell33.AddElement(new Paragraph("20.00 * " + "2" + " = " + (20 * Convert.ToInt32("2")) + ".00"));

            cell33.FixedHeight = 300.0f;



            table2.AddCell(cell31);

            table2.AddCell(cell32);

            table2.AddCell(cell33);


            PdfPCell cell2A = new PdfPCell(table2);

            cell2A.Colspan = 2;

            table1.AddCell(cell2A);

            PdfPCell cell41 = new PdfPCell();

            cell41.AddElement(new Paragraph("Name : " + "ABC"));

            cell41.AddElement(new Paragraph("Advance : " + "advance"));

            cell41.VerticalAlignment = Element.ALIGN_LEFT;

            PdfPCell cell42 = new PdfPCell();

            cell42.AddElement(new Paragraph("Customer ID : " + "011"));

            cell42.AddElement(new Paragraph("Balance : " + "3993"));

            cell42.VerticalAlignment = Element.ALIGN_RIGHT;


            table1.AddCell(cell41);

            table1.AddCell(cell42);


            doc.Add(table1);

            doc.Close();


            return doc;
        }
    }
}
