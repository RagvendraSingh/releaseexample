using System;
using System.Collections.Generic;
using System.IO;
using iText.Forms;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
 
namespace PNGImageHandling
{
        public class FixPNGIssue
        {
     
        public static readonly string DEST = "results/test/output/pngimage/";
 
        public static void Main(String[] args)
          {
           FileInfo file = new FileInfo(DEST);
           file.Directory.Create();
            new FixPNGIssue().generatePDF(DEST);
        }
 
 
        public  void generatePDF(string dest)
        {
 
            string outPdf = dest + "pngoutput.pdf";
 
            PdfDocument pdf = new PdfDocument(new PdfWriter(outPdf));
            var document = new Document(pdf);
            //Update the encoded png image
            string dataSrc = "Update the encoded png image"
            byte[] data = Convert.FromBase64String(dataSrc);
            var image = new Image(ImageDataFactory.Create(data));
            document.Add(image);
            document.Close();
         
    }
 
}
    }
