using System;
using System.IO;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Font;
using iText.Layout.Font;


namespace LineHeightProperty
{
    public class LineHeight
    {

        public static readonly string DEST = "results/test/output/lineheight/output.pdf";
        public static readonly string SRC = "results/test/output/lineheight/input.html";
        //Font directory path
        public static readonly string FONT = "results/test/font/lineheight/NotoSans-Regular.ttf";

        public static void Main(String[] args)
        {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();

            generatePDF();
        }


        public static void generatePDF()
        {
            // Base URI is required to resolve the path to source files
            ConverterProperties converterProperties = new ConverterProperties();

            using (var htmlStream = File.OpenRead(SRC))
            {
                if (File.Exists(DEST))
                {
                    File.Delete(DEST);
                }
                using (var pdfStream = File.OpenWrite(DEST))
                {
                    FontProvider fontProvider = new DefaultFontProvider();
                    FontProgram fontProgram = FontProgramFactory.CreateFont(FONT);
                    fontProvider.AddFont(fontProgram);
                    converterProperties.SetFontProvider(fontProvider);
                    HtmlConverter.ConvertToPdf(htmlStream, pdfStream, converterProperties);
                }
            }


        }

    }
}
