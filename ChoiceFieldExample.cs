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
 
namespace Multichoicefield
{
 
        public class ChoiceFieldExample
        {
     
        public static readonly string DEST = "results/test/output/choicefield/";
		public static string srcPdf = DEST + "choiceFieldsWithUnnecessaryIEntries.pdf";
        public static string outPdf = DEST + "choiceFieldsSetValueTest.pdf";
 
        public static void Main(String[] args)
          {
           FileInfo file = new FileInfo(DEST);
           file.Directory.Create();
 
            new ChoiceFieldExample().generatePDF();
        }
 
 
        public  void generatePDF()
        {
 
        PdfDocument pdfDocument = new PdfDocument(new PdfReader(srcPdf), new PdfWriter(outPdf));
        PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDocument, false);
        form.GetField("First").SetValue("First");
        form.GetField("Second").SetValue("Second");
        pdfDocument.Close();
         
    }
 
}
    }
