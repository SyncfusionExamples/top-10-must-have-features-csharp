// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using System.Reflection.Metadata;

//Creates a PDF document.
PdfDocument finalDocumcent = new PdfDocument();
FileStream inputFileStream1 = new FileStream("../../../File1.pdf", FileMode.Open, FileAccess.Read);
FileStream inputFileStream2 = new FileStream("../../../File2.pdf", FileMode.Open, FileAccess.Read);
//Creates a PDF stream for merging.
Stream[] streams = { inputFileStream1, inputFileStream2 };
//Merges PDFDocument.
PdfDocumentBase.Merge(finalDocumcent, streams);
//Create file stream. 
using (FileStream outputFileStream = new FileStream("../../../Output.pdf", FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream. 
    finalDocumcent.Save(outputFileStream);
}

//Disposes the streams.
inputFileStream1.Dispose();
inputFileStream2.Dispose();

