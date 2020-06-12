using iText.Html2pdf;
using iText.Html2pdf.Attach.Impl;
using iText.StyledXmlParser.Node;
using System.Collections.Generic;
using System.IO;


namespace MergeOutliner
{
    class MergeOutliner
    {

        public void manipulatePdf(string htmlSource, string pdfDest, string resourceLoc)
        {
            // Base URI is required to resolve the path to source files
            ConverterProperties converterProperties = new ConverterProperties().SetBaseUri(resourceLoc);

            using (var htmlStream = File.OpenRead(htmlSource))
            {
                if (File.Exists(pdfDest))
                {
                    File.Delete(pdfDest);
                }
                using (var pdfStream = File.OpenWrite(pdfDest))
                {
                    IDictionary<string, int?> priorityMappings = new Dictionary<string, int?>();
                    priorityMappings.Add("p", 1);
                    priorityMappings.Add("h1", 2);
                    OutlineHandler customOutlineHandler = new CustomOutlineHandler().PutAllTagPriorityMappings(priorityMappings);
                    customOutlineHandler.SetDestinationNamePrefix("custom-prefix-");
                    converterProperties.SetOutlineHandler(customOutlineHandler);
                    HtmlConverter.ConvertToPdf(htmlStream, pdfStream, converterProperties);
                }
            }

            // Create custom outline handler

        }


        public class CustomOutlineHandler : OutlineHandler
        {

            protected override string GenerateUniqueDestinationName(IElementNode element)
            {
                string destinationName = base.GenerateUniqueDestinationName(element);
                if ("p".Equals(element.Name()))
                {
                    destinationName = destinationName.Replace(GetDestinationNamePrefix(), "paragraph-prefix-");
                }
                return destinationName;
            }
        }

    }
}
