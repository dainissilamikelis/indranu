import * as jsPDF from "jspdf";
import html2Canvas from "html2canvas";

export default function createPDF(receipt) {
  html2Canvas(document.querySelector("#receipt")).then(canvas => {
    receipt.current.appendChild(canvas);
    debugger;
    const imgData = canvas.toDataURL("image/jpg");
    const doc = new jsPDF("landscape", "mm", "a4");
    doc.addImage(imgData, "PNG", 0, 0);
    doc.save("test.pdf");
  });
}
