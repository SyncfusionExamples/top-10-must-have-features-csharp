// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using System.Reflection.Metadata;
using Syncfusion.Drawing;

//Load the PDF document.
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
//Get first page from document.
PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;
//Create PDF graphics for the page.
PdfGraphics graphics = loadedPage.Graphics;

//Set the standard font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
//Draw the text.
graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

//Returns page number and rectangle positions of the text maches. 
Dictionary<int, List<Syncfusion.Drawing.RectangleF>> matchRects = new Dictionary<int, List<Syncfusion.Drawing.RectangleF>>();
loadedDocument.FindText("document", out matchRects);
for (int i = 0; i < loadedDocument.Pages.Count; i++)
{
    List<RectangleF> rectCoords = matchRects[i];
    for (int j = 0; j < rectCoords.Count; j++)
    {
        RectangleF bounds = new RectangleF(rectCoords[j].X, rectCoords[j].Y, rectCoords[j].Width, rectCoords[j].Height);
        loadedDocument.Pages[i].Graphics.DrawRectangle(PdfPens.Red, bounds);
    }
}
//Extract text from first page.
string extractedText = loadedPage.ExtractText();

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}
//Close the document.
loadedDocument.Close(true);