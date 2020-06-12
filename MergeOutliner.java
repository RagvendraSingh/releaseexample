package com.itext.mergeoutliner;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

import com.itextpdf.html2pdf.ConverterProperties;
import com.itextpdf.html2pdf.HtmlConverter;
import com.itextpdf.html2pdf.attach.impl.OutlineHandler;
import com.itextpdf.styledxmlparser.node.IElementNode;

public class MergeOutliner {

	public void manipulatePdf(String htmlSource, String pdfDest, String resourceLoc) throws IOException {
        try {
        // Base URI is required to resolve the path to source files
        ConverterProperties converterProperties = new ConverterProperties().setBaseUri(resourceLoc);
 
        // Create custom outline handler
        Map<String, Integer> priorityMappings = new HashMap<String, Integer>();
        priorityMappings.put("p", 1);
        priorityMappings.put("h1", 2);
        OutlineHandler customOutlineHandler = new CustomOutlineHandler().putAllTagPriorityMappings(priorityMappings);
        customOutlineHandler.setDestinationNamePrefix("custom-prefix-");
        converterProperties.setOutlineHandler(customOutlineHandler);
        HtmlConverter.convertToPdf(new FileInputStream(htmlSource), new FileOutputStream(pdfDest), converterProperties);
        }
        catch(IOException e) {
            e.getMessage();
        }
    }
 
    public class CustomOutlineHandler extends OutlineHandler {
        @Override
        protected String generateUniqueDestinationName(IElementNode element) {
            String destinationName = super.generateUniqueDestinationName(element);
            if ("p".equals(element.name())) {
                destinationName = destinationName.replace(getDestinationNamePrefix(), "paragraph-prefix-");
            }
            return destinationName;
        }
    }
	
}
