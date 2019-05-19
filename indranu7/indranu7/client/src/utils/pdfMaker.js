import * as jsPDF from "jspdf";
import html2Canvas from 'html2canvas';

export default function createPDF(receipt) {
  html2Canvas(document.querySelector('#receipt')).then(canvas => {
    receipt.current.appendChild(canvas);
    const imgData = canvas.toDataURL('image/png');
    const doc = new jsPDF({
      orientation: "Landscape",
    });
    doc.addImage(imgData, "PNG", 0, 0);
    doc.save("test.pdf");
  })

}