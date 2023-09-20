// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Drawing;
using System.Reflection.Metadata;

namespace Page_manipulation_in_PDF_NET
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document.
            FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            //Rearrange the page by index. 
            loadedDocument.Pages.ReArrange(new int[] { 2, 1, 0 });

            //Insert a new page in the beginning of the document.
            loadedDocument.Pages.Insert(0);
            loadedDocument.Pages[0].Graphics.DrawString("Hello World!!!", new PdfStandardFont(PdfFontFamily.Helvetica, 20), PdfBrushes.Black, new PointF(0, 0));

            //Gets the page
            PdfPageBase loadedPage = loadedDocument.Pages[3] as PdfPageBase;
            //Set the rotation for loaded page
            loadedPage.Rotation = PdfPageRotateAngle.RotateAngle90;

            //Remove the first page in the PDF document. 
            loadedDocument.Pages.RemoveAt(2);

            //Create file stream.
            using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
            {
                //Save the PDF document to file stream.
                loadedDocument.Save(outputFileStream);
            }
            //Close the document.
            loadedDocument.Close(true);
        }
    }
}