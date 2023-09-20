// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Xmp;

//Load the PDF document.
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
//Load the first page.
PdfPageBase firstPage = loadedDocument.Pages[0];
PdfPageBase secondPage = loadedDocument.Pages[1];

//Extract text from first page.
string extractedText = firstPage.ExtractText();
File.WriteAllText("../../../ExtractedText.txt", extractedText);

//Extract images from first page
Stream[] extractedImages = secondPage.ExtractImages();
for (int i = 0; i < extractedImages.Length; i++)
{
    FileStream imageStream = new FileStream("../../../ExtractedImage" + i + ".png", FileMode.Create, FileAccess.Write);
    extractedImages[i].CopyTo(imageStream);
    imageStream.Dispose();
}

//Extracting metadata and document information. 
PdfDocumentInformation documentInformation = loadedDocument.DocumentInformation;
XmpMetadata metadata = loadedDocument.DocumentInformation.XmpMetadata;

//Close the document.
loadedDocument.Close(true);