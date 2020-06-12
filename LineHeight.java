import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
 
import com.itextpdf.html2pdf.ConverterProperties;
import com.itextpdf.html2pdf.HtmlConverter;
import com.itextpdf.html2pdf.resolver.font.DefaultFontProvider;
import com.itextpdf.io.font.FontProgram;
import com.itextpdf.io.font.FontProgramFactory;
import com.itextpdf.layout.font.FontProvider;
 
public class LineHeight {
    private static final String SRC = "src/main/resources/input.html";
    private static final String DEST = "src/main/resources/output.pdf";
    private static final String FONT = "src/main/resources/NotoSans-Regular.ttf";
 
    public static void main(String[] args) {
        // TODO Auto-generated method stub
        generatePDF();
 
    }
 
    private static void generatePDF() {
 
        try {
            ConverterProperties properties = new ConverterProperties();
            FontProvider fontProvider = new DefaultFontProvider();
            FontProgram fontProgram = FontProgramFactory.createFont(FONT);
            fontProvider.addFont(fontProgram);
            properties.setFontProvider(fontProvider);
            FileInputStream is = new FileInputStream(SRC);
            HtmlConverter.convertToPdf(is, new FileOutputStream(DEST), properties);
        } catch (IOException e) {
            e.printStackTrace();
        }
 
    }
 
}
