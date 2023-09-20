﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Parsing;

//Load an existing PDF document.
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream, "password");
//Change the user password.
loadedDocument.Security.OwnerPassword = string.Empty;

//Create file stream. 
using (FileStream outputFileStream = new FileStream("../../../Output.pdf", FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream. 
    loadedDocument.Save(outputFileStream);
}
