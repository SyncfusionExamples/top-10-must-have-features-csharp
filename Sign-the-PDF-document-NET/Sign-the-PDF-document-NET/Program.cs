﻿// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System;
using System.Diagnostics;

//Creates a new PDF document
PdfDocument document = new PdfDocument();
//Adds a new page
PdfPageBase page = document.Pages.Add();
PdfGraphics graphics = page.Graphics;
//Creates a certificate instance from PFX file with private key
FileStream certificateStream = new FileStream(@"../../../PDF.pfx", FileMode.Open, FileAccess.Read);
PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");
//Creates a digital signature
PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");
//Sets an image for signature field
FileStream imageStream = new FileStream(@"../../../logo.png", FileMode.Open, FileAccess.Read);
PdfBitmap signatureImage = new PdfBitmap(imageStream);
//Sets signature information
signature.Bounds = new RectangleF(0, 0, 200, 100);
signature.ContactInfo = "johndoe@owned.us";
signature.LocationInfo = "Honolulu, Hawaii";
signature.Reason = "I am author of this document.";
//Draws the signature image
signature.Appearance.Normal.Graphics.DrawImage(signatureImage, signature.Bounds);
//Create file stream. 
using (FileStream outputFileStream = new FileStream("../../../Output.pdf", FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDtqF document to file stream. 
    document.Save(outputFileStream);
}

