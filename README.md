# Top 10 Must-Have Features in a C# PDF Library

The Syncfusion&reg; .NET PDF library provides an extensive range of functionalities for seamless handling of PDF creation, manipulation, and management.  Explore this repository to delve into each feature, find implementation examples, and harness the potential of Syncfusion&reg; PDF Library in your applications.Some of the use cases that we will cover in this article include:

* PDF Creation 
* Text Manipulation
* Page management 
* Graphics and images 
* Annotations and forms 
* Security and encryption 
* Digital signatures 
* PDF data extraction 
* Optical Character Recognition (OCR)
* Text-to-PDF and PDF-to-text
* Additional features: PDF/A compliance, watermarks, bookmarks, redaction, compression and TOC. 

Sample name | Description
--- | ---
[Create PDF document](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Create-PDF-document) | Generate a basic PDF document containing text, images, and shapes.
[PDF data extraction](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/PDF-parsing-sample) | Extract text, images, document information, and metadata from an existing PDF document. 
[Text manipulation](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Text-manipulation-in-PDF-NET) | Add text, find text, and extract text in PDF document. 
[Page management](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Page-manipulation-in-PDF-NET) | Manipulate pages within a PDF document by inserting, removing, and rearranging them, as well as merging and splitting the PDF as needed.
[Merge PDF documents](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Merge-PDF-documents-NET) | Merge multiple PDF documents into a single PDF document.
[Split PDF document](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Split-PDF-document-NET) | Split large PDF document into multiple PDF documents. 
[Convert TIFF to PDF](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Convert-TIFF-to-PDF-NET) | Convert TIFF to PDF document. 
[Add annotation to PDF](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Add-annotation-to-PDF-document-NET) | Add annotation to the PDF document. 
[Create PDF form](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Create-PDF-form-NET) | Create a simple form in PDF document. 
[Fill PDF form fields](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Fill_form_fields_in_PDF_NET) | Fill form fields in an existing PDF document. 
[Encrypt PDF document](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Encrypting-PDF-document-NET) | Encrypt PDF document using user password. 
[Decrypt PDF document](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Decrypting-PDF-document-NET) | The decryption process requires the correct password (user or owner) to access the content.  
[Sign PDF document](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Sign-the-PDF-document-NET) | Add digital signature to the PDF document. 
[OCR sample](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/OCR-on-entire-PDF-document) | Convert a entire scanned PDF document into a searchable PDF document. 
[Text to PDF](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Convert-text-to-PDF-file-NET) | Convert a text into the PDF document. 
[PDF to text](https://github.com/SyncfusionExamples/top-10-must-have-features-csharp/tree/master/Convert-PDF-to-text-NET) | Convert the PDF document into text. 

## PDF Creation

Syncfusion&reg; .NET PDF library provides a powerful solution that empowers you to generate PDFs and seamlessly integrate text, images, and diverse elements, infusing vitality into your documents.

```csharp

//Create a new PDF document.
PdfDocument document = new PdfDocument();
//Set the page size.
document.PageSettings.Size = PdfPageSize.A4;
//Add a page to the document.
PdfPage page = document.Pages.Add();
//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;
//Set the font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
//Draw the text.
graphics.DrawString("Adventure Cycle Works", font, PdfBrushes.IndianRed, new Syncfusion.Drawing.PointF(150, 50));
//Load the image from the disk
FileStream imageStream = new FileStream("AdventureCycle.jpg", FileMode.Open, FileAccess.Read);
PdfBitmap image = new PdfBitmap(imageStream);
//Draw the image
graphics.DrawImage(image, new RectangleF(150,100,200,100));
//Initialize PdfPen to draw the polygon
PdfPen pen = new PdfPen(PdfBrushes.Brown, 10f);
//Initialize PdfLinearGradientBrush for drawing the polygon
PdfLinearGradientBrush brush = new PdfLinearGradientBrush(new PointF(10, 100), new PointF(100, 200), new PdfColor(Color.Red), new PdfColor(Color.Green));
//Create the polygon points
PointF p1 = new PointF(10, 100);
PointF p2 = new PointF(10, 200);
PointF p3 = new PointF(100, 100);
PointF p4 = new PointF(100, 200);
PointF p5 = new PointF(55, 150);
PointF[] points = { p1, p2, p3, p4, p5 };
//Draw the polygon on PDF document
page.Graphics.DrawPolygon(pen, brush, points);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);

```

## PDF data extraction 

The Syncfusion&reg; Essential&reg; PDF library provides a comprehensive set of APIs for parsing PDF files. These APIs can be used to extract text, images, metadata, or perform more advanced tasks. 

```csharp

//Load the PDF document.
FileStream docStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read);
//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
//Load the first page.
PdfPageBase firstPage = loadedDocument.Pages[0];
PdfPageBase secondPage = loadedDocument.Pages[1];
//Extract text from first page.
string extractedText = firstPage.ExtractText();
File.WriteAllText("ExtractedText.txt", extractedText);
//Extract images from first page
Stream[] extractedImages = secondPage.ExtractImages();
for (int i = 0; i < extractedImages.Length; i++)
{
    FileStream imageStream = new FileStream("ExtractedImage" + i + ".png", FileMode.Create, FileAccess.Write);
    extractedImages[i].CopyTo(imageStream);
    imageStream.Dispose();
}
//Extracting metadata and document information. 
PdfDocumentInformation documentInformation = loadedDocument.DocumentInformation;
XmpMetadata metadata = loadedDocument.DocumentInformation.XmpMetadata;
 
//Close the document.
loadedDocument.Close(true);

```

## Text manipulation

Text manipulation is a fundamental part of working with PDF documents, whether it involves adding text, finding existing content, extracting information, replace fonts, and font embedding. 

```csharp

//Load the PDF document.
FileStream docStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read);
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
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}
//Close the document.
loadedDocument.Close(true);

```

## Page management 

Syncfusion&reg; provides a comprehensive set of APIs for managing pages in PDF documents. These APIs can be used to add, insert, remove, rotate, and rearrange pages, page splitting, page scaling, page reordering, page numbering, merge, and split PDF documents. 	

```csharp

//Load the PDF document.
FileStream docStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
//Rearrange the page by index. 
loadedDocument.Pages.ReArrange(new int[] { 2, 1, 0 });
//Insert a new page in the beginning of the document.
loadedDocument.Pages.Insert(0);
loadedDocument.Pages[0].Graphics.DrawString("Regular Page", new PdfStandardFont(PdfFontFamily.Helvetica, 20), PdfBrushes.Black, new PointF(0, 0));
//Remove the first page in the PDF document. 
loadedDocument.Pages.RemoveAt(3);
//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}
//Close the document.
loadedDocument.Close(true);

```

## Merge and split PDF documents 

### Merge PDF documents 

Merging PDF files from two different documents into a single, organized file is a handy skill to have. Fortunately, it's an easy process that can be accomplished with just a few simple steps using Syncfusion&reg; .NET PDF library. 

```csharp

// Create a PDF document.
using (PdfDocument finalDocument = new PdfDocument())
{
    // Get the stream from an existing PDF documents.
    using (FileStream firstStream = new FileStream("File1.pdf", FileMode.Open, FileAccess.Read))
    using (FileStream secondStream = new FileStream("File2.pdf", FileMode.Open, FileAccess.Read))
    {
        // Create a PDF stream for merging.
        Stream[] streams = { firstStream, secondStream };
        // Merge PDF documents.
        PdfDocumentBase.Merge(finalDocument, streams);
        // Save the document into a stream.
        using (MemoryStream outputStream = new MemoryStream())
        {
            finalDocument.Save(outputStream);
        }
    }
}

```

### Split PDF document

If you're wondering how to split a PDF file, the process is relatively simple. Here's an example of how to split a PDF document using C#. 

```csharp

// Create the FileStream object. 
using (FileStream inputFileStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read))
{
    // Create a PdfLoadedDocument object from the FileStream object 
    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputFileStream);
    // Iterate over the pages in the PdfLoadedDocument object 
    for (int pageIndex = 0; pageIndex < loadedDocument.PageCount; pageIndex++)
    {
        // Create a new PdfDocument object 
        using (PdfDocument outputDocument = new PdfDocument())
        {
            // Import the page from the PdfLoadedDocument object to the PdfDocument object 
            outputDocument.ImportPage(loadedDocument, pageIndex);
            //Save the document into a filestream object.
            using (FileStream outputFileStream = new FileStream("Output" + pageIndex + ".pdf", FileMode.Create, FileAccess.Write))
            {
                outputDocument.Save(outputFileStream);
            }
        }
    }
}

```

## Graphics and images 

Syncfusion&reg; provides a wide range of robust tools and capabilities for unlocking the complete potential of graphics and images.

**Adding images:** You have the flexibility to insert, resize, and crop images sourced from diverse locations, such as files on your computer or online resources. Additionally, you can perform tasks like image masking, image pagination, image replacement, conversion from multi-page TIFF to PDF, and image removal.
[https://help.syncfusion.com/file-formats/pdf/working-with-images](https://help.syncfusion.com/file-formats/pdf/working-with-images)

**Drawing shapes:** Create custom shapes (Polygon, Line, Curve, Path, Rectangle, Pie, Arc, Bezier, and Ellipse), diagrams, and annotations within your documents. 
[https://help.syncfusion.com/file-formats/pdf/working-with-shapes](https://help.syncfusion.com/file-formats/pdf/working-with-shapes) 

**Vector graphics:** With Syncfusion, you can add vector graphics to your PDFs, ensuring that they maintain their quality and sharpness regardless of the display size. 
[https://help.syncfusion.com/file-formats/pdf/working-with-images#inserting-a-vector-image](https://help.syncfusion.com/file-formats/pdf/working-with-images#inserting-a-vector-image)

**Interactive elements:** Make your PDFs more engaging by adding interactive elements such as buttons and hyperlinks to graphics and images. 
[https://help.syncfusion.com/file-formats/pdf/working-with-hyperlinks](https://help.syncfusion.com/file-formats/pdf/working-with-hyperlinks)

## Annotations and forms 

### Annotations 

Annotations in a PDF document is additional content, notes, or markup that can be included without altering the original content. They serve to provide feedback, comments, or explanations related to specific sections or elements within the document.  

```csharp

//Create a new PDF document. 
PdfDocument document = new PdfDocument();
//Create a new page. 
PdfPage page = document.Pages.Add();
FileStream fontStream = new FileStream("Arial.ttf", FileMode.Open, FileAccess.Read);
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

//Save the PDF document to memory stream. 
MemoryStream stream = new MemoryStream();
document.Save(stream);
//Close the document.  
document.Close(true);

```

### PDF forms 

Interactive PDF forms are widely used for data collection and user input. Syncfusion’ s C# PDF Library provides robust support for creating, filling, and processing interactive PDF forms. 

```csharp

//Create a new PDF document 
PdfDocument document = new PdfDocument(); 
//Add a new page to the PDF document 
PdfPage page = document.Pages.Add(); 
//Set the standard font 
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16); 
//Draw the string       
page.Graphics.DrawString("Job Application", font, PdfBrushes.Black, new PointF(250, 0)); 
font = new PdfStandardFont(PdfFontFamily.Helvetica, 12); 
page.Graphics.DrawString("Name", font, PdfBrushes.Black, new PointF(10, 20)); 
 
//Create a text box field for name 
PdfTextBoxField textBoxField1 = new PdfTextBoxField(page, "Name"); 
textBoxField1.Bounds = new RectangleF(10, 40, 200, 20); 
textBoxField1.ToolTip = "Name"; 
document.Form.Fields.Add(textBoxField1); 
 
page.Graphics.DrawString("Email address", font, PdfBrushes.Black, new PointF(10, 80)); 
//Create a text box field for email address 
PdfTextBoxField textBoxField3 = new PdfTextBoxField(page, "Email address"); 
textBoxField3.Bounds = new RectangleF(10, 100, 200, 20); 
textBoxField3.ToolTip = "Email address"; 
document.Form.Fields.Add(textBoxField3); 
 
page.Graphics.DrawString("Phone", font, PdfBrushes.Black, new PointF(10, 140)); 
//Create a text box field for phone 
PdfTextBoxField textBoxField4 = new PdfTextBoxField(page, "Phone"); 
textBoxField4.Bounds = new RectangleF(10, 160, 200, 20); 
textBoxField4.ToolTip = "Phone"; 
document.Form.Fields.Add(textBoxField4); 
 
page.Graphics.DrawString("Gender", font, PdfBrushes.Black, new PointF(10, 200)); 
//Create radio button for gender 
PdfRadioButtonListField employeesRadioList = new PdfRadioButtonListField(page, "Gender"); 
document.Form.Fields.Add(employeesRadioList); 
page.Graphics.DrawString("Male", font, PdfBrushes.Black, new PointF(40, 220)); 
PdfRadioButtonListItem radioButtonItem1 = new PdfRadioButtonListItem("Male"); 
radioButtonItem1.Bounds = new RectangleF(10, 220, 20, 20); 
page.Graphics.DrawString("Female", font, PdfBrushes.Black, new PointF(140, 220)); 
PdfRadioButtonListItem radioButtonItem2 = new PdfRadioButtonListItem("Female"); 
radioButtonItem2.Bounds = new RectangleF(110, 220, 20, 20); 
employeesRadioList.Items.Add(radioButtonItem1); 
employeesRadioList.Items.Add(radioButtonItem2); 
 
//Create file stream. 
using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) 
{ 
    //Save the PDF document to file stream. 
    document.Save(outputFileStream); 
} 
//Close the document. 
document.Close(true); 

```

## Security and encryption 

PDF encryption involves applying algorithms to render the content of the PDF document unreadable without the correct decryption key. 

```csharp

//Create a new PDF document.
PdfDocument document = new PdfDocument();
//Add a page to the document.
PdfPage page = document.Pages.Add();
//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;

//Create instance of document security.
PdfSecurity security = document.Security;
//Specifies key size, encryption algorithm and user password.
security.KeySize = PdfEncryptionKeySize.Key128Bit;
security.Algorithm = PdfEncryptionAlgorithm.RC4;
security.UserPassword = "password";
//Draw the text.
graphics.DrawString("Encryp PDF with user password and RC4 128bit keysize", new PdfStandardFont(PdfFontFamily.TimesRoman, 20f, PdfFontStyle.Bold), PdfBrushes.Black, new PointF(0, 40));

//Save the document into stream.
MemoryStream stream = new MemoryStream();
document.Save(stream);
//Close the document.
document.Close(true);

```

## Digital Signature 

The digital signature serves to verify the authenticity and integrity of the PDF document, ensuring that the content has not been altered or tampered with since the time of signing. Using Syncfusion' s PDF library, you can create a digital signature by associating it with a valid digital certificate obtained from a trusted certificate authority. 

```csharp

//Creates a new PDF document
PdfDocument document = new PdfDocument();
//Adds a new page
PdfPageBase page = document.Pages.Add();
PdfGraphics graphics = page.Graphics;
//Creates a certificate instance from PFX file with private key
FileStream certificateStream = new FileStream(@"PDF.pfx", FileMode.Open, FileAccess.Read);
PdfCertificate pdfCert = new PdfCertificate(certificateStream, "syncfusion");
//Creates a digital signature
PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");
//Sets an image for signature field
FileStream imageStream = new FileStream(@"logo.png", FileMode.Open, FileAccess.Read);
PdfBitmap signatureImage = new PdfBitmap(imageStream);
//Sets signature information
signature.Bounds = new RectangleF(0, 0, 200, 100);
signature.ContactInfo = "johndoe@owned.us";
signature.LocationInfo = "Honolulu, Hawaii";
signature.Reason = "I am author of this document.";
//Draws the signature image
signature.Appearance.Normal.Graphics.DrawImage(signatureImage, signature.Bounds);
//Create file stream. 
using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDtqF document to file stream. 
    document.Save(outputFileStream);
}

```

## Optical Character Recognition (OCR)

The Syncfusion&reg; .NET Optical Character Recognition (OCR) Library allows users to extract textual information from images, PDF files, or other scanned documents, making the content searchable, editable, and accessible. 

```csharp

//Initialize the OCR processor. 
using (OCRProcessor processor = new OCRProcessor()) 
{ 
    //Load an existing PDF document. 
    FileStream inputPDFstream = new FileStream("Input.pdf", FileMode.Open); 
    PdfLoadedDocument document = new PdfLoadedDocument(inputPDFstream); 
    //Set OCR language. 
    processor.Settings.Language ="deu"; 
    //Perform OCR with input document. 
    processor.PerformOCR(document, "Tessdata/");   
    //Create file stream. 
    using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) 
    { 
        //Save the PDF document to file stream. 
        document.Save(outputFileStream); 
    } 
} 

```

## Text-to-PDF and PDF-to-text 

### Text-to-PDF document

The Syncfusion&reg; library empowers you to convert text into a PDF document, and you can achieve this using the following code example.  

```csharp

//Create a new PDF document.
PdfDocument document = new PdfDocument();
//Add a page to the document.
PdfPage page = document.Pages.Add();
//Create PDF graphics for the page.
PdfGraphics graphics = page.Graphics;
 
//Set the standard font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
//Draw the text.
graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));
 
//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);

```

### PDF-to-text conversion 
With Syncfusion, you can effortlessly extract text from PDF documents by using the following code example. 

```csharp

//Load the PDF document.
FileStream docStream = new FileStream("Input.pdf", FileMode.Open, FileAccess.Read);
//Load the PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
//Load the first page.
PdfPageBase page = loadedDocument.Pages[0];
//Extract text from first page.
string extractedText = page.ExtractText();
File.WriteAllText("ExtractedText.txt", extractedText);
//Close the document.
loadedDocument.Close(true);

```

# How to run the examples
* Download this project to a location in your disk. 
* Open the solution file using Visual Studio. 
* Rebuild the solution to install the required NuGet package. 
* Run the application.

# Resources
*   **Product page:** [Syncfusion&reg; PDF Framework](https://www.syncfusion.com/document-processing/pdf-framework/net)
*   **Documentation page:** [Syncfusion&reg; .NET PDF library](https://help.syncfusion.com/file-formats/pdf/overview)
*   **Online demo:** [Syncfusion&reg; .NET PDF library - Online demos](https://ej2.syncfusion.com/aspnetcore/PDF/CompressExistingPDF#/bootstrap5)
*   **Blog:** [Syncfusion&reg; .NET PDF library - Blog](https://www.syncfusion.com/blogs/category/pdf)
*   **Knowledge Base:** [Syncfusion&reg; .NET PDF library - Knowledge Base](https://www.syncfusion.com/kb/windowsforms/pdf)
*   **EBooks:** [Syncfusion&reg; .NET PDF library - EBooks](https://www.syncfusion.com/succinctly-free-ebooks)
*   **FAQ:** [Syncfusion&reg; .NET PDF library - FAQ](https://www.syncfusion.com/faq/)

# Support and feedback
*   For any other queries, reach our [Syncfusion&reg; support team](https://www.syncfusion.com/support/directtrac/incidents/newincident?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples) or post the queries through the [community forums](https://www.syncfusion.com/forums?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples).
*   Request new feature through [Syncfusion&reg; feedback portal](https://www.syncfusion.com/feedback?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples).

# License
This is a commercial product and requires a paid license for possession or use. Syncfusion’s licensed software, including this component, is subject to the terms and conditions of [Syncfusion's EULA](https://www.syncfusion.com/eula/es/?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples). You can purchase a licnense [here](https://www.syncfusion.com/sales/products?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples) or start a free 30-day trial [here](https://www.syncfusion.com/account/manage-trials/start-trials?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples).

# About Syncfusion
Founded in 2001 and headquartered in Research Triangle Park, N.C., Syncfusion&reg; has more than 26,000+ customers and more than 1 million users, including large financial institutions, Fortune 500 companies, and global IT consultancies.

Today, we provide 1600+ components and frameworks for web ([Blazor](https://www.syncfusion.com/blazor-components?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [ASP.NET Core](https://www.syncfusion.com/aspnet-core-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [ASP.NET MVC](https://www.syncfusion.com/aspnet-mvc-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [ASP.NET WebForms](https://www.syncfusion.com/jquery/aspnet-webforms-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [JavaScript](https://www.syncfusion.com/javascript-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [Angular](https://www.syncfusion.com/angular-ui-components?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [React](https://www.syncfusion.com/react-ui-components?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [Vue](https://www.syncfusion.com/vue-ui-components?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), and [Flutter](https://www.syncfusion.com/flutter-widgets?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples)), mobile ([Xamarin](https://www.syncfusion.com/xamarin-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [Flutter](https://www.syncfusion.com/flutter-widgets?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [UWP](https://www.syncfusion.com/uwp-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), and [JavaScript](https://www.syncfusion.com/javascript-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples)), and desktop development ([WinForms](https://www.syncfusion.com/winforms-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [WPF](https://www.syncfusion.com/wpf-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [WinUI(Preview)](https://www.syncfusion.com/winui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples), [Flutter](https://www.syncfusion.com/flutter-widgets?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples) and [UWP](https://www.syncfusion.com/uwp-ui-controls?utm_source=github&utm_medium=listing&utm_campaign=github-docio-examples)). We provide ready-to-deploy enterprise software for dashboards, reports, data integration, and big data processing. Many customers have saved millions in licensing fees by deploying our software.