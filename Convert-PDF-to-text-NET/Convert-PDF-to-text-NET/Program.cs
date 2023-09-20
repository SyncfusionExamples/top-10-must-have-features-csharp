// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

//Load the PDF document.
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
//Load the first page.
PdfPageBase page = loadedDocument.Pages[0];

//Extract text from first page.
string extractedText = page.ExtractText();
File.WriteAllText("../../../ExtractedText.txt", extractedText);

//Close the document.
loadedDocument.Close(true);
