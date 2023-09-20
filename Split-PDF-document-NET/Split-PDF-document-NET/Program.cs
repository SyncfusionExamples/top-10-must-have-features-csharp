﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

//Load an existing PDF document.
FileStream inputPDFStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputPDFStream, true);
for (int i = 0; i < loadedDocument.Pages.Count; i++)
{
    //Creates a new document.
    PdfDocument document = new PdfDocument();
    //Imports the pages from the loaded document.
    document.ImportPage(loadedDocument, i);
    //Create a File stream. 
    using (var outputFileStream = new FileStream("../../../Output" + i + ".pdf", FileMode.Create, FileAccess.Write))
    {
        //Save the document to stream.
        document.Save(outputFileStream);
    }
}
