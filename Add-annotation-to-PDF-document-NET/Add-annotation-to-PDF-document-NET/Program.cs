// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.  
PdfDocument document = new PdfDocument();
//Create a new page.  
PdfPage page = document.Pages.Add();
FileStream fontStream = new FileStream("../../../Arial.ttf", FileMode.Open, FileAccess.Read);
PdfFont pdfFont = new PdfTrueTypeFont(fontStream, 14);
//Create a new PDF brush.  
PdfBrush pdfBrush = new PdfSolidBrush(Color.Black);
//Draw text in the new page.  
page.Graphics.DrawString("Text Markup Annotation Demo", pdfFont, pdfBrush, new PointF(150, 10));
string markupText = "Text Markup";
SizeF size = pdfFont.MeasureString(markupText);
RectangleF rectangle = new RectangleF(200, 40, size.Width, size.Height);
page.Graphics.DrawString(markupText, pdfFont, pdfBrush, rectangle);

//Create a PDF text markup annotation.  
PdfTextMarkupAnnotation markupAnnotation = new PdfTextMarkupAnnotation("Markup annotation", "Markup annotation with highlight style", markupText, new PointF(200, 40), pdfFont);
markupAnnotation.TextMarkupColor = new PdfColor(Color.BlueViolet);
markupAnnotation.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight;
//Add this annotation to a new page.  
page.Annotations.Add(markupAnnotation);

//Create file stream. 
using (FileStream outputFileStream = new FileStream("../../../Output.pdf", FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream. 
    document.Save(outputFileStream);
}
